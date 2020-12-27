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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenLeistungenBescheideStatuses")]
  [Route("mvc/odata/dbSinDarEla/KundenLeistungenBescheideStatuses")]
  public partial class KundenLeistungenBescheideStatusesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenLeistungenBescheideStatusesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBescheideStatuses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBescheideStatus> GetKundenLeistungenBescheideStatuses()
    {
      var items = this.context.KundenLeistungenBescheideStatuses.AsQueryable<Models.DbSinDarEla.KundenLeistungenBescheideStatus>();
      this.OnKundenLeistungenBescheideStatusesRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBescheideStatusesRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBescheideStatus> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{StatusCode}")]
    public SingleResult<KundenLeistungenBescheideStatus> GetKundenLeistungenBescheideStatus(string key)
    {
        var items = this.context.KundenLeistungenBescheideStatuses.Where(i=>i.StatusCode == key);
        this.OnKundenLeistungenBescheideStatusesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenLeistungenBescheideStatusesGet(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBescheideStatus> items);

    partial void OnKundenLeistungenBescheideStatusDeleted(Models.DbSinDarEla.KundenLeistungenBescheideStatus item);

    [HttpDelete("{StatusCode}")]
    public IActionResult DeleteKundenLeistungenBescheideStatus(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenLeistungenBescheideStatuses
                .Where(i => i.StatusCode == key)
                .Include(i => i.KundenLeistungenBescheides)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenLeistungenBescheideStatusDeleted(itemToDelete);
            this.context.KundenLeistungenBescheideStatuses.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideStatusUpdated(Models.DbSinDarEla.KundenLeistungenBescheideStatus item);

    [HttpPut("{StatusCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBescheideStatus(string key, [FromBody]Models.DbSinDarEla.KundenLeistungenBescheideStatus newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.StatusCode != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBescheideStatusUpdated(newItem);
            this.context.KundenLeistungenBescheideStatuses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheideStatuses.Where(i => i.StatusCode == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{StatusCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBescheideStatus(string key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBescheideStatus> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenLeistungenBescheideStatuses.Where(i => i.StatusCode == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenLeistungenBescheideStatusUpdated(itemToUpdate);
            this.context.KundenLeistungenBescheideStatuses.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheideStatuses.Where(i => i.StatusCode == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideStatusCreated(Models.DbSinDarEla.KundenLeistungenBescheideStatus item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBescheideStatus item)
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

            this.OnKundenLeistungenBescheideStatusCreated(item);
            this.context.KundenLeistungenBescheideStatuses.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/KundenLeistungenBescheideStatuses/{item.StatusCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
