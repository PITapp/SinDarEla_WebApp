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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterStatuses")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterStatuses")]
  public partial class MitarbeiterStatusesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterStatusesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterStatuses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterStatus> GetMitarbeiterStatuses()
    {
      var items = this.context.MitarbeiterStatuses.AsQueryable<Models.DbSinDarEla.MitarbeiterStatus>();
      this.OnMitarbeiterStatusesRead(ref items);

      return items;
    }

    partial void OnMitarbeiterStatusesRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterStatus> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterStatusID}")]
    public SingleResult<MitarbeiterStatus> GetMitarbeiterStatus(int key)
    {
        var items = this.context.MitarbeiterStatuses.Where(i=>i.MitarbeiterStatusID == key);
        this.OnMitarbeiterStatusesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterStatusesGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterStatus> items);

    partial void OnMitarbeiterStatusDeleted(Models.DbSinDarEla.MitarbeiterStatus item);

    [HttpDelete("{MitarbeiterStatusID}")]
    public IActionResult DeleteMitarbeiterStatus(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterStatuses
                .Where(i => i.MitarbeiterStatusID == key)
                .Include(i => i.Mitarbeiters)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterStatusDeleted(itemToDelete);
            this.context.MitarbeiterStatuses.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterStatusUpdated(Models.DbSinDarEla.MitarbeiterStatus item);

    [HttpPut("{MitarbeiterStatusID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterStatus(int key, [FromBody]Models.DbSinDarEla.MitarbeiterStatus newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterStatusID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterStatusUpdated(newItem);
            this.context.MitarbeiterStatuses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterStatuses.Where(i => i.MitarbeiterStatusID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterStatusID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterStatus(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterStatus> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterStatuses.Where(i => i.MitarbeiterStatusID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterStatusUpdated(itemToUpdate);
            this.context.MitarbeiterStatuses.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterStatuses.Where(i => i.MitarbeiterStatusID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterStatusCreated(Models.DbSinDarEla.MitarbeiterStatus item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterStatus item)
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

            this.OnMitarbeiterStatusCreated(item);
            this.context.MitarbeiterStatuses.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/MitarbeiterStatuses/{item.MitarbeiterStatusID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
