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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterTaetigkeitens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterTaetigkeitens")]
  public partial class MitarbeiterTaetigkeitensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterTaetigkeitensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterTaetigkeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterTaetigkeiten> GetMitarbeiterTaetigkeitens()
    {
      var items = this.context.MitarbeiterTaetigkeitens.AsQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeiten>();
      this.OnMitarbeiterTaetigkeitensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterTaetigkeitensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeiten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterTaetigkeitenID}")]
    public SingleResult<MitarbeiterTaetigkeiten> GetMitarbeiterTaetigkeiten(int key)
    {
        var items = this.context.MitarbeiterTaetigkeitens.Where(i=>i.MitarbeiterTaetigkeitenID == key);
        this.OnMitarbeiterTaetigkeitensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterTaetigkeitensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeiten> items);

    partial void OnMitarbeiterTaetigkeitenDeleted(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);

    [HttpDelete("{MitarbeiterTaetigkeitenID}")]
    public IActionResult DeleteMitarbeiterTaetigkeiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterTaetigkeitens
                .Where(i => i.MitarbeiterTaetigkeitenID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterTaetigkeitenDeleted(itemToDelete);
            this.context.MitarbeiterTaetigkeitens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterTaetigkeitenUpdated(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);

    [HttpPut("{MitarbeiterTaetigkeitenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterTaetigkeiten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterTaetigkeiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterTaetigkeitenID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterTaetigkeitenUpdated(newItem);
            this.context.MitarbeiterTaetigkeitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterTaetigkeitens.Where(i => i.MitarbeiterTaetigkeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterTaetigkeitenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterTaetigkeitenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterTaetigkeiten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterTaetigkeiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterTaetigkeitens.Where(i => i.MitarbeiterTaetigkeitenID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterTaetigkeitenUpdated(itemToUpdate);
            this.context.MitarbeiterTaetigkeitens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterTaetigkeitens.Where(i => i.MitarbeiterTaetigkeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterTaetigkeitenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterTaetigkeitenCreated(Models.DbSinDarEla.MitarbeiterTaetigkeiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterTaetigkeiten item)
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

            this.OnMitarbeiterTaetigkeitenCreated(item);
            this.context.MitarbeiterTaetigkeitens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterTaetigkeitenID;

            var itemToReturn = this.context.MitarbeiterTaetigkeitens.Where(i => i.MitarbeiterTaetigkeitenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterTaetigkeitenArten");

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
