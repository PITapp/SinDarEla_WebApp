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

  [ODataRoutePrefix("odata/dbSinDarEla/EreignisseTeilnehmers")]
  [Route("mvc/odata/dbSinDarEla/EreignisseTeilnehmers")]
  public partial class EreignisseTeilnehmersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public EreignisseTeilnehmersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/EreignisseTeilnehmers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.EreignisseTeilnehmer> GetEreignisseTeilnehmers()
    {
      var items = this.context.EreignisseTeilnehmers.AsQueryable<Models.DbSinDarEla.EreignisseTeilnehmer>();
      this.OnEreignisseTeilnehmersRead(ref items);

      return items;
    }

    partial void OnEreignisseTeilnehmersRead(ref IQueryable<Models.DbSinDarEla.EreignisseTeilnehmer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisseTeilnehmerID}")]
    public SingleResult<EreignisseTeilnehmer> GetEreignisseTeilnehmer(int key)
    {
        var items = this.context.EreignisseTeilnehmers.Where(i=>i.EreignisseTeilnehmerID == key);
        this.OnEreignisseTeilnehmersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnEreignisseTeilnehmersGet(ref IQueryable<Models.DbSinDarEla.EreignisseTeilnehmer> items);

    partial void OnEreignisseTeilnehmerDeleted(Models.DbSinDarEla.EreignisseTeilnehmer item);

    [HttpDelete("{EreignisseTeilnehmerID}")]
    public IActionResult DeleteEreignisseTeilnehmer(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.EreignisseTeilnehmers
                .Where(i => i.EreignisseTeilnehmerID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnEreignisseTeilnehmerDeleted(itemToDelete);
            this.context.EreignisseTeilnehmers.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseTeilnehmerUpdated(Models.DbSinDarEla.EreignisseTeilnehmer item);

    [HttpPut("{EreignisseTeilnehmerID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisseTeilnehmer(int key, [FromBody]Models.DbSinDarEla.EreignisseTeilnehmer newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.EreignisseTeilnehmerID != key))
            {
                return BadRequest();
            }

            this.OnEreignisseTeilnehmerUpdated(newItem);
            this.context.EreignisseTeilnehmers.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseTeilnehmers.Where(i => i.EreignisseTeilnehmerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Ereignisse,EreignisseTeilnehmerStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{EreignisseTeilnehmerID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisseTeilnehmer(int key, [FromBody]Delta<Models.DbSinDarEla.EreignisseTeilnehmer> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.EreignisseTeilnehmers.Where(i => i.EreignisseTeilnehmerID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnEreignisseTeilnehmerUpdated(itemToUpdate);
            this.context.EreignisseTeilnehmers.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseTeilnehmers.Where(i => i.EreignisseTeilnehmerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Ereignisse,EreignisseTeilnehmerStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseTeilnehmerCreated(Models.DbSinDarEla.EreignisseTeilnehmer item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.EreignisseTeilnehmer item)
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

            this.OnEreignisseTeilnehmerCreated(item);
            this.context.EreignisseTeilnehmers.Add(item);
            this.context.SaveChanges();

            var key = item.EreignisseTeilnehmerID;

            var itemToReturn = this.context.EreignisseTeilnehmers.Where(i => i.EreignisseTeilnehmerID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,Ereignisse,EreignisseTeilnehmerStatus");

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
