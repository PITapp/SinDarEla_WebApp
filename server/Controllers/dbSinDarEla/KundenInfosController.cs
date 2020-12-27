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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenInfos")]
  [Route("mvc/odata/dbSinDarEla/KundenInfos")]
  public partial class KundenInfosController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenInfosController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenInfos
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenInfo> GetKundenInfos()
    {
      var items = this.context.KundenInfos.AsQueryable<Models.DbSinDarEla.KundenInfo>();
      this.OnKundenInfosRead(ref items);

      return items;
    }

    partial void OnKundenInfosRead(ref IQueryable<Models.DbSinDarEla.KundenInfo> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenInfoID}")]
    public SingleResult<KundenInfo> GetKundenInfo(int key)
    {
        var items = this.context.KundenInfos.Where(i=>i.KundenInfoID == key);
        this.OnKundenInfosGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenInfosGet(ref IQueryable<Models.DbSinDarEla.KundenInfo> items);

    partial void OnKundenInfoDeleted(Models.DbSinDarEla.KundenInfo item);

    [HttpDelete("{KundenInfoID}")]
    public IActionResult DeleteKundenInfo(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenInfos
                .Where(i => i.KundenInfoID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenInfoDeleted(itemToDelete);
            this.context.KundenInfos.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenInfoUpdated(Models.DbSinDarEla.KundenInfo item);

    [HttpPut("{KundenInfoID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenInfo(int key, [FromBody]Models.DbSinDarEla.KundenInfo newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenInfoID != key))
            {
                return BadRequest();
            }

            this.OnKundenInfoUpdated(newItem);
            this.context.KundenInfos.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenInfos.Where(i => i.KundenInfoID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenInfoID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenInfo(int key, [FromBody]Delta<Models.DbSinDarEla.KundenInfo> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenInfos.Where(i => i.KundenInfoID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenInfoUpdated(itemToUpdate);
            this.context.KundenInfos.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenInfos.Where(i => i.KundenInfoID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenInfoCreated(Models.DbSinDarEla.KundenInfo item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenInfo item)
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

            this.OnKundenInfoCreated(item);
            this.context.KundenInfos.Add(item);
            this.context.SaveChanges();

            var key = item.KundenInfoID;

            var itemToReturn = this.context.KundenInfos.Where(i => i.KundenInfoID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Kunden");

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
