using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNet.OData.Query;



namespace SinDarEla.Controllers.DbSinDarEla
{
  using Models;
  using Data;
  using Models.DbSinDarEla;

  [ODataRoutePrefix("odata/dbSinDarEla/Aufgabens")]
  [Route("mvc/odata/dbSinDarEla/Aufgabens")]
  public partial class AufgabensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public AufgabensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Aufgabens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Aufgaben> GetAufgabens()
    {
      var items = this.context.Aufgabens.AsQueryable<Models.DbSinDarEla.Aufgaben>();
      this.OnAufgabensRead(ref items);

      return items;
    }

    partial void OnAufgabensRead(ref IQueryable<Models.DbSinDarEla.Aufgaben> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AufgabeID}")]
    public SingleResult<Aufgaben> GetAufgaben(int key)
    {
        var items = this.context.Aufgabens.Where(i=>i.AufgabeID == key);
        this.OnAufgabensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnAufgabensGet(ref IQueryable<Models.DbSinDarEla.Aufgaben> items);

    partial void OnAufgabenDeleted(Models.DbSinDarEla.Aufgaben item);

    [HttpDelete("{AufgabeID}")]
    public IActionResult DeleteAufgaben(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Aufgabens
                .Where(i => i.AufgabeID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnAufgabenDeleted(itemToDelete);
            this.context.Aufgabens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAufgabenUpdated(Models.DbSinDarEla.Aufgaben item);

    [HttpPut("{AufgabeID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAufgaben(int key, [FromBody]Models.DbSinDarEla.Aufgaben newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AufgabeID != key))
            {
                return BadRequest();
            }

            this.OnAufgabenUpdated(newItem);
            this.context.Aufgabens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Aufgabens.Where(i => i.AufgabeID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Base1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{AufgabeID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAufgaben(int key, [FromBody]Delta<Models.DbSinDarEla.Aufgaben> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Aufgabens.Where(i => i.AufgabeID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnAufgabenUpdated(itemToUpdate);
            this.context.Aufgabens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Aufgabens.Where(i => i.AufgabeID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Base1");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAufgabenCreated(Models.DbSinDarEla.Aufgaben item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Aufgaben item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAufgabenCreated(item);
            this.context.Aufgabens.Add(item);
            this.context.SaveChanges();

            var key = item.AufgabeID;

            var itemToReturn = this.context.Aufgabens.Where(i => i.AufgabeID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,Base1");

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
