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

  [ODataRoutePrefix("odata/dbSinDarEla/Modules")]
  [Route("mvc/odata/dbSinDarEla/Modules")]
  public partial class ModulesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public ModulesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Modules
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Module> GetModules()
    {
      var items = this.context.Modules.AsQueryable<Models.DbSinDarEla.Module>();
      this.OnModulesRead(ref items);

      return items;
    }

    partial void OnModulesRead(ref IQueryable<Models.DbSinDarEla.Module> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ModulID}")]
    public SingleResult<Module> GetModule(int key)
    {
        var items = this.context.Modules.Where(i=>i.ModulID == key);
        this.OnModulesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnModulesGet(ref IQueryable<Models.DbSinDarEla.Module> items);

    partial void OnModuleDeleted(Models.DbSinDarEla.Module item);

    [HttpDelete("{ModulID}")]
    public IActionResult DeleteModule(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Modules
                .Where(i => i.ModulID == key)
                .Include(i => i.BenutzerModules)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnModuleDeleted(itemToDelete);
            this.context.Modules.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnModuleUpdated(Models.DbSinDarEla.Module item);

    [HttpPut("{ModulID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutModule(int key, [FromBody]Models.DbSinDarEla.Module newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.ModulID != key))
            {
                return BadRequest();
            }

            this.OnModuleUpdated(newItem);
            this.context.Modules.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Modules.Where(i => i.ModulID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{ModulID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchModule(int key, [FromBody]Delta<Models.DbSinDarEla.Module> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Modules.Where(i => i.ModulID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnModuleUpdated(itemToUpdate);
            this.context.Modules.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Modules.Where(i => i.ModulID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnModuleCreated(Models.DbSinDarEla.Module item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Module item)
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

            this.OnModuleCreated(item);
            this.context.Modules.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/Modules/{item.ModulID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
