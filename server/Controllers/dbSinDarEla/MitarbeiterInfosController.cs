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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterInfos")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterInfos")]
  public partial class MitarbeiterInfosController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterInfosController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterInfos
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterInfo> GetMitarbeiterInfos()
    {
      var items = this.context.MitarbeiterInfos.AsQueryable<Models.DbSinDarEla.MitarbeiterInfo>();
      this.OnMitarbeiterInfosRead(ref items);

      return items;
    }

    partial void OnMitarbeiterInfosRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterInfo> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterInfoID}")]
    public SingleResult<MitarbeiterInfo> GetMitarbeiterInfo(int key)
    {
        var items = this.context.MitarbeiterInfos.Where(i=>i.MitarbeiterInfoID == key);
        this.OnMitarbeiterInfosGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterInfosGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterInfo> items);

    partial void OnMitarbeiterInfoDeleted(Models.DbSinDarEla.MitarbeiterInfo item);

    [HttpDelete("{MitarbeiterInfoID}")]
    public IActionResult DeleteMitarbeiterInfo(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterInfos
                .Where(i => i.MitarbeiterInfoID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterInfoDeleted(itemToDelete);
            this.context.MitarbeiterInfos.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterInfoUpdated(Models.DbSinDarEla.MitarbeiterInfo item);

    [HttpPut("{MitarbeiterInfoID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterInfo(int key, [FromBody]Models.DbSinDarEla.MitarbeiterInfo newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterInfoID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterInfoUpdated(newItem);
            this.context.MitarbeiterInfos.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterInfos.Where(i => i.MitarbeiterInfoID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterInfoID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterInfo(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterInfo> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterInfos.Where(i => i.MitarbeiterInfoID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterInfoUpdated(itemToUpdate);
            this.context.MitarbeiterInfos.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterInfos.Where(i => i.MitarbeiterInfoID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterInfoCreated(Models.DbSinDarEla.MitarbeiterInfo item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterInfo item)
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

            this.OnMitarbeiterInfoCreated(item);
            this.context.MitarbeiterInfos.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterInfoID;

            var itemToReturn = this.context.MitarbeiterInfos.Where(i => i.MitarbeiterInfoID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");

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
