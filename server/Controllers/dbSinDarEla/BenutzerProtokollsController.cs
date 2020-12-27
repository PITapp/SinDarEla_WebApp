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

  [ODataRoutePrefix("odata/dbSinDarEla/BenutzerProtokolls")]
  [Route("mvc/odata/dbSinDarEla/BenutzerProtokolls")]
  public partial class BenutzerProtokollsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public BenutzerProtokollsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BenutzerProtokolls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BenutzerProtokoll> GetBenutzerProtokolls()
    {
      var items = this.context.BenutzerProtokolls.AsQueryable<Models.DbSinDarEla.BenutzerProtokoll>();
      this.OnBenutzerProtokollsRead(ref items);

      return items;
    }

    partial void OnBenutzerProtokollsRead(ref IQueryable<Models.DbSinDarEla.BenutzerProtokoll> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BenutzerProtokollID}")]
    public SingleResult<BenutzerProtokoll> GetBenutzerProtokoll(int key)
    {
        var items = this.context.BenutzerProtokolls.Where(i=>i.BenutzerProtokollID == key);
        this.OnBenutzerProtokollsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBenutzerProtokollsGet(ref IQueryable<Models.DbSinDarEla.BenutzerProtokoll> items);

    partial void OnBenutzerProtokollDeleted(Models.DbSinDarEla.BenutzerProtokoll item);

    [HttpDelete("{BenutzerProtokollID}")]
    public IActionResult DeleteBenutzerProtokoll(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.BenutzerProtokolls
                .Where(i => i.BenutzerProtokollID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBenutzerProtokollDeleted(itemToDelete);
            this.context.BenutzerProtokolls.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerProtokollUpdated(Models.DbSinDarEla.BenutzerProtokoll item);

    [HttpPut("{BenutzerProtokollID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBenutzerProtokoll(int key, [FromBody]Models.DbSinDarEla.BenutzerProtokoll newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BenutzerProtokollID != key))
            {
                return BadRequest();
            }

            this.OnBenutzerProtokollUpdated(newItem);
            this.context.BenutzerProtokolls.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerProtokolls.Where(i => i.BenutzerProtokollID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{BenutzerProtokollID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBenutzerProtokoll(int key, [FromBody]Delta<Models.DbSinDarEla.BenutzerProtokoll> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.BenutzerProtokolls.Where(i => i.BenutzerProtokollID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBenutzerProtokollUpdated(itemToUpdate);
            this.context.BenutzerProtokolls.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerProtokolls.Where(i => i.BenutzerProtokollID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerProtokollCreated(Models.DbSinDarEla.BenutzerProtokoll item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BenutzerProtokoll item)
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

            this.OnBenutzerProtokollCreated(item);
            this.context.BenutzerProtokolls.Add(item);
            this.context.SaveChanges();

            var key = item.BenutzerProtokollID;

            var itemToReturn = this.context.BenutzerProtokolls.Where(i => i.BenutzerProtokollID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer");

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
