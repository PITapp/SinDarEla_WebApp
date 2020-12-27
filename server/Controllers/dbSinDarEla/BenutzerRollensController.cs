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

  [ODataRoutePrefix("odata/dbSinDarEla/BenutzerRollens")]
  [Route("mvc/odata/dbSinDarEla/BenutzerRollens")]
  public partial class BenutzerRollensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public BenutzerRollensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BenutzerRollens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BenutzerRollen> GetBenutzerRollens()
    {
      var items = this.context.BenutzerRollens.AsQueryable<Models.DbSinDarEla.BenutzerRollen>();
      this.OnBenutzerRollensRead(ref items);

      return items;
    }

    partial void OnBenutzerRollensRead(ref IQueryable<Models.DbSinDarEla.BenutzerRollen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BenutzerRolleID}")]
    public SingleResult<BenutzerRollen> GetBenutzerRollen(int key)
    {
        var items = this.context.BenutzerRollens.Where(i=>i.BenutzerRolleID == key);
        this.OnBenutzerRollensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBenutzerRollensGet(ref IQueryable<Models.DbSinDarEla.BenutzerRollen> items);

    partial void OnBenutzerRollenDeleted(Models.DbSinDarEla.BenutzerRollen item);

    [HttpDelete("{BenutzerRolleID}")]
    public IActionResult DeleteBenutzerRollen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.BenutzerRollens
                .Where(i => i.BenutzerRolleID == key)
                .Include(i => i.Benutzers)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBenutzerRollenDeleted(itemToDelete);
            this.context.BenutzerRollens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerRollenUpdated(Models.DbSinDarEla.BenutzerRollen item);

    [HttpPut("{BenutzerRolleID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBenutzerRollen(int key, [FromBody]Models.DbSinDarEla.BenutzerRollen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BenutzerRolleID != key))
            {
                return BadRequest();
            }

            this.OnBenutzerRollenUpdated(newItem);
            this.context.BenutzerRollens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerRollens.Where(i => i.BenutzerRolleID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{BenutzerRolleID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBenutzerRollen(int key, [FromBody]Delta<Models.DbSinDarEla.BenutzerRollen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.BenutzerRollens.Where(i => i.BenutzerRolleID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBenutzerRollenUpdated(itemToUpdate);
            this.context.BenutzerRollens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.BenutzerRollens.Where(i => i.BenutzerRolleID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBenutzerRollenCreated(Models.DbSinDarEla.BenutzerRollen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BenutzerRollen item)
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

            this.OnBenutzerRollenCreated(item);
            this.context.BenutzerRollens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/BenutzerRollens/{item.BenutzerRolleID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
