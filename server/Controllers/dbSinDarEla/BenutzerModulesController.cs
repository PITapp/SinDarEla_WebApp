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

  [ODataRoutePrefix("odata/dbSinDarEla/BenutzerModules")]
  [Route("mvc/odata/dbSinDarEla/BenutzerModules")]
  public partial class BenutzerModulesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public BenutzerModulesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BenutzerModules
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BenutzerModule> GetBenutzerModules()
    {
      var items = this.context.BenutzerModules.AsQueryable<Models.DbSinDarEla.BenutzerModule>();
      this.OnBenutzerModulesRead(ref items);

      return items;
    }

    partial void OnBenutzerModulesRead(ref IQueryable<Models.DbSinDarEla.BenutzerModule> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BenutzerModuleID}")]
    public SingleResult<BenutzerModule> GetBenutzerModule(int key)
    {
        var items = this.context.BenutzerModules.Where(i=>i.BenutzerModuleID == key);
        this.OnBenutzerModulesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBenutzerModulesGet(ref IQueryable<Models.DbSinDarEla.BenutzerModule> items);

    partial void OnBenutzerModuleDeleted(Models.DbSinDarEla.BenutzerModule item);

    [HttpDelete("{BenutzerModuleID}")]
    public IActionResult DeleteBenutzerModule(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.BenutzerModules
                .Where(i => i.BenutzerModuleID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBenutzerModuleDeleted(itemToDelete);
            this.context.BenutzerModules.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerModuleUpdated(Models.DbSinDarEla.BenutzerModule item);

    [HttpPut("{BenutzerModuleID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBenutzerModule(int key, [FromBody]Models.DbSinDarEla.BenutzerModule newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BenutzerModuleID != key))
            {
                return BadRequest();
            }

            this.OnBenutzerModuleUpdated(newItem);
            this.context.BenutzerModules.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerModules.Where(i => i.BenutzerModuleID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,Module");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{BenutzerModuleID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBenutzerModule(int key, [FromBody]Delta<Models.DbSinDarEla.BenutzerModule> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.BenutzerModules.Where(i => i.BenutzerModuleID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBenutzerModuleUpdated(itemToUpdate);
            this.context.BenutzerModules.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerModules.Where(i => i.BenutzerModuleID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,Module");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerModuleCreated(Models.DbSinDarEla.BenutzerModule item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BenutzerModule item)
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

            this.OnBenutzerModuleCreated(item);
            this.context.BenutzerModules.Add(item);
            this.context.SaveChanges();

            var key = item.BenutzerModuleID;

            var itemToReturn = this.context.BenutzerModules.Where(i => i.BenutzerModuleID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Benutzer,Module");

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
