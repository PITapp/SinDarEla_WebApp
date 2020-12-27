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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterArtens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterArtens")]
  public partial class MitarbeiterArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterArten> GetMitarbeiterArtens()
    {
      var items = this.context.MitarbeiterArtens.AsQueryable<Models.DbSinDarEla.MitarbeiterArten>();
      this.OnMitarbeiterArtensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterArtensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterArtID}")]
    public SingleResult<MitarbeiterArten> GetMitarbeiterArten(int key)
    {
        var items = this.context.MitarbeiterArtens.Where(i=>i.MitarbeiterArtID == key);
        this.OnMitarbeiterArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterArtensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterArten> items);

    partial void OnMitarbeiterArtenDeleted(Models.DbSinDarEla.MitarbeiterArten item);

    [HttpDelete("{MitarbeiterArtID}")]
    public IActionResult DeleteMitarbeiterArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterArtens
                .Where(i => i.MitarbeiterArtID == key)
                .Include(i => i.Mitarbeiters)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterArtenDeleted(itemToDelete);
            this.context.MitarbeiterArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterArtenUpdated(Models.DbSinDarEla.MitarbeiterArten item);

    [HttpPut("{MitarbeiterArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterArten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterArtID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterArtenUpdated(newItem);
            this.context.MitarbeiterArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterArtens.Where(i => i.MitarbeiterArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterArten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterArtens.Where(i => i.MitarbeiterArtID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterArtenUpdated(itemToUpdate);
            this.context.MitarbeiterArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterArtens.Where(i => i.MitarbeiterArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterArtenCreated(Models.DbSinDarEla.MitarbeiterArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterArten item)
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

            this.OnMitarbeiterArtenCreated(item);
            this.context.MitarbeiterArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/MitarbeiterArtens/{item.MitarbeiterArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
