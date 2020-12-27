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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenStatuses")]
  [Route("mvc/odata/dbSinDarEla/KundenStatuses")]
  public partial class KundenStatusesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenStatusesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenStatuses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenStatus> GetKundenStatuses()
    {
      var items = this.context.KundenStatuses.AsQueryable<Models.DbSinDarEla.KundenStatus>();
      this.OnKundenStatusesRead(ref items);

      return items;
    }

    partial void OnKundenStatusesRead(ref IQueryable<Models.DbSinDarEla.KundenStatus> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenStatusID}")]
    public SingleResult<KundenStatus> GetKundenStatus(int key)
    {
        var items = this.context.KundenStatuses.Where(i=>i.KundenStatusID == key);
        this.OnKundenStatusesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenStatusesGet(ref IQueryable<Models.DbSinDarEla.KundenStatus> items);

    partial void OnKundenStatusDeleted(Models.DbSinDarEla.KundenStatus item);

    [HttpDelete("{KundenStatusID}")]
    public IActionResult DeleteKundenStatus(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenStatuses
                .Where(i => i.KundenStatusID == key)
                .Include(i => i.Kundens)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenStatusDeleted(itemToDelete);
            this.context.KundenStatuses.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenStatusUpdated(Models.DbSinDarEla.KundenStatus item);

    [HttpPut("{KundenStatusID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenStatus(int key, [FromBody]Models.DbSinDarEla.KundenStatus newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenStatusID != key))
            {
                return BadRequest();
            }

            this.OnKundenStatusUpdated(newItem);
            this.context.KundenStatuses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenStatuses.Where(i => i.KundenStatusID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenStatusID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenStatus(int key, [FromBody]Delta<Models.DbSinDarEla.KundenStatus> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenStatuses.Where(i => i.KundenStatusID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenStatusUpdated(itemToUpdate);
            this.context.KundenStatuses.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenStatuses.Where(i => i.KundenStatusID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenStatusCreated(Models.DbSinDarEla.KundenStatus item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenStatus item)
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

            this.OnKundenStatusCreated(item);
            this.context.KundenStatuses.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/KundenStatuses/{item.KundenStatusID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
