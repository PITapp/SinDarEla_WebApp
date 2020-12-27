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

  [ODataRoutePrefix("odata/dbSinDarEla/Debuggs")]
  [Route("mvc/odata/dbSinDarEla/Debuggs")]
  public partial class DebuggsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public DebuggsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Debuggs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Debugg> GetDebuggs()
    {
      var items = this.context.Debuggs.AsQueryable<Models.DbSinDarEla.Debugg>();
      this.OnDebuggsRead(ref items);

      return items;
    }

    partial void OnDebuggsRead(ref IQueryable<Models.DbSinDarEla.Debugg> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{DebuggID}")]
    public SingleResult<Debugg> GetDebugg(int key)
    {
        var items = this.context.Debuggs.Where(i=>i.DebuggID == key);
        this.OnDebuggsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnDebuggsGet(ref IQueryable<Models.DbSinDarEla.Debugg> items);

    partial void OnDebuggDeleted(Models.DbSinDarEla.Debugg item);

    [HttpDelete("{DebuggID}")]
    public IActionResult DeleteDebugg(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Debuggs
                .Where(i => i.DebuggID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnDebuggDeleted(itemToDelete);
            this.context.Debuggs.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDebuggUpdated(Models.DbSinDarEla.Debugg item);

    [HttpPut("{DebuggID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDebugg(int key, [FromBody]Models.DbSinDarEla.Debugg newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DebuggID != key))
            {
                return BadRequest();
            }

            this.OnDebuggUpdated(newItem);
            this.context.Debuggs.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Debuggs.Where(i => i.DebuggID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{DebuggID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDebugg(int key, [FromBody]Delta<Models.DbSinDarEla.Debugg> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Debuggs.Where(i => i.DebuggID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnDebuggUpdated(itemToUpdate);
            this.context.Debuggs.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Debuggs.Where(i => i.DebuggID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDebuggCreated(Models.DbSinDarEla.Debugg item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Debugg item)
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

            this.OnDebuggCreated(item);
            this.context.Debuggs.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/Debuggs/{item.DebuggID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
