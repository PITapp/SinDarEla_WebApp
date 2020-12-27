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

  [ODataRoutePrefix("odata/dbSinDarEla/RegelnAbwesenheitens")]
  [Route("mvc/odata/dbSinDarEla/RegelnAbwesenheitens")]
  public partial class RegelnAbwesenheitensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public RegelnAbwesenheitensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/RegelnAbwesenheitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.RegelnAbwesenheiten> GetRegelnAbwesenheitens()
    {
      var items = this.context.RegelnAbwesenheitens.AsQueryable<Models.DbSinDarEla.RegelnAbwesenheiten>();
      this.OnRegelnAbwesenheitensRead(ref items);

      return items;
    }

    partial void OnRegelnAbwesenheitensRead(ref IQueryable<Models.DbSinDarEla.RegelnAbwesenheiten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{RegelnAbwesenheitenID}")]
    public SingleResult<RegelnAbwesenheiten> GetRegelnAbwesenheiten(int key)
    {
        var items = this.context.RegelnAbwesenheitens.Where(i=>i.RegelnAbwesenheitenID == key);
        this.OnRegelnAbwesenheitensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnRegelnAbwesenheitensGet(ref IQueryable<Models.DbSinDarEla.RegelnAbwesenheiten> items);

    partial void OnRegelnAbwesenheitenDeleted(Models.DbSinDarEla.RegelnAbwesenheiten item);

    [HttpDelete("{RegelnAbwesenheitenID}")]
    public IActionResult DeleteRegelnAbwesenheiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.RegelnAbwesenheitens
                .Where(i => i.RegelnAbwesenheitenID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnRegelnAbwesenheitenDeleted(itemToDelete);
            this.context.RegelnAbwesenheitens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnRegelnAbwesenheitenUpdated(Models.DbSinDarEla.RegelnAbwesenheiten item);

    [HttpPut("{RegelnAbwesenheitenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutRegelnAbwesenheiten(int key, [FromBody]Models.DbSinDarEla.RegelnAbwesenheiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.RegelnAbwesenheitenID != key))
            {
                return BadRequest();
            }

            this.OnRegelnAbwesenheitenUpdated(newItem);
            this.context.RegelnAbwesenheitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.RegelnAbwesenheitens.Where(i => i.RegelnAbwesenheitenID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{RegelnAbwesenheitenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchRegelnAbwesenheiten(int key, [FromBody]Delta<Models.DbSinDarEla.RegelnAbwesenheiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.RegelnAbwesenheitens.Where(i => i.RegelnAbwesenheitenID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnRegelnAbwesenheitenUpdated(itemToUpdate);
            this.context.RegelnAbwesenheitens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.RegelnAbwesenheitens.Where(i => i.RegelnAbwesenheitenID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnRegelnAbwesenheitenCreated(Models.DbSinDarEla.RegelnAbwesenheiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.RegelnAbwesenheiten item)
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

            this.OnRegelnAbwesenheitenCreated(item);
            this.context.RegelnAbwesenheitens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/RegelnAbwesenheitens/{item.RegelnAbwesenheitenID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
