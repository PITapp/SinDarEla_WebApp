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

  [ODataRoutePrefix("odata/dbSinDarEla/EreignisseTeilnehmerStatuses")]
  [Route("mvc/odata/dbSinDarEla/EreignisseTeilnehmerStatuses")]
  public partial class EreignisseTeilnehmerStatusesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public EreignisseTeilnehmerStatusesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/EreignisseTeilnehmerStatuses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.EreignisseTeilnehmerStatus> GetEreignisseTeilnehmerStatuses()
    {
      var items = this.context.EreignisseTeilnehmerStatuses.AsQueryable<Models.DbSinDarEla.EreignisseTeilnehmerStatus>();
      this.OnEreignisseTeilnehmerStatusesRead(ref items);

      return items;
    }

    partial void OnEreignisseTeilnehmerStatusesRead(ref IQueryable<Models.DbSinDarEla.EreignisseTeilnehmerStatus> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{StatusCode}")]
    public SingleResult<EreignisseTeilnehmerStatus> GetEreignisseTeilnehmerStatus(string key)
    {
        var items = this.context.EreignisseTeilnehmerStatuses.Where(i=>i.StatusCode == key);
        this.OnEreignisseTeilnehmerStatusesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnEreignisseTeilnehmerStatusesGet(ref IQueryable<Models.DbSinDarEla.EreignisseTeilnehmerStatus> items);

    partial void OnEreignisseTeilnehmerStatusDeleted(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);

    [HttpDelete("{StatusCode}")]
    public IActionResult DeleteEreignisseTeilnehmerStatus(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.EreignisseTeilnehmerStatuses
                .Where(i => i.StatusCode == key)
                .Include(i => i.EreignisseTeilnehmers)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnEreignisseTeilnehmerStatusDeleted(itemToDelete);
            this.context.EreignisseTeilnehmerStatuses.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseTeilnehmerStatusUpdated(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);

    [HttpPut("{StatusCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisseTeilnehmerStatus(string key, [FromBody]Models.DbSinDarEla.EreignisseTeilnehmerStatus newItem)
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

            this.OnEreignisseTeilnehmerStatusUpdated(newItem);
            this.context.EreignisseTeilnehmerStatuses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseTeilnehmerStatuses.Where(i => i.StatusCode == key);
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
    public IActionResult PatchEreignisseTeilnehmerStatus(string key, [FromBody]Delta<Models.DbSinDarEla.EreignisseTeilnehmerStatus> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.EreignisseTeilnehmerStatuses.Where(i => i.StatusCode == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnEreignisseTeilnehmerStatusUpdated(itemToUpdate);
            this.context.EreignisseTeilnehmerStatuses.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseTeilnehmerStatuses.Where(i => i.StatusCode == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseTeilnehmerStatusCreated(Models.DbSinDarEla.EreignisseTeilnehmerStatus item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.EreignisseTeilnehmerStatus item)
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

            this.OnEreignisseTeilnehmerStatusCreated(item);
            this.context.EreignisseTeilnehmerStatuses.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/EreignisseTeilnehmerStatuses/{item.StatusCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
