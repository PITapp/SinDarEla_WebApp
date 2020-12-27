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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterTaetigkeitenArtens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterTaetigkeitenArtens")]
  public partial class MitarbeiterTaetigkeitenArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterTaetigkeitenArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterTaetigkeitenArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> GetMitarbeiterTaetigkeitenArtens()
    {
      var items = this.context.MitarbeiterTaetigkeitenArtens.AsQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten>();
      this.OnMitarbeiterTaetigkeitenArtensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterTaetigkeitenArtensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterTaetigkeitenArtID}")]
    public SingleResult<MitarbeiterTaetigkeitenArten> GetMitarbeiterTaetigkeitenArten(int key)
    {
        var items = this.context.MitarbeiterTaetigkeitenArtens.Where(i=>i.MitarbeiterTaetigkeitenArtID == key);
        this.OnMitarbeiterTaetigkeitenArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterTaetigkeitenArtensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> items);

    partial void OnMitarbeiterTaetigkeitenArtenDeleted(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);

    [HttpDelete("{MitarbeiterTaetigkeitenArtID}")]
    public IActionResult DeleteMitarbeiterTaetigkeitenArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterTaetigkeitenArtens
                .Where(i => i.MitarbeiterTaetigkeitenArtID == key)
                .Include(i => i.MitarbeiterTaetigkeitens)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterTaetigkeitenArtenDeleted(itemToDelete);
            this.context.MitarbeiterTaetigkeitenArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterTaetigkeitenArtenUpdated(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);

    [HttpPut("{MitarbeiterTaetigkeitenArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterTaetigkeitenArten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterTaetigkeitenArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterTaetigkeitenArtID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterTaetigkeitenArtenUpdated(newItem);
            this.context.MitarbeiterTaetigkeitenArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterTaetigkeitenArtens.Where(i => i.MitarbeiterTaetigkeitenArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterTaetigkeitenArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterTaetigkeitenArten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterTaetigkeitenArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterTaetigkeitenArtens.Where(i => i.MitarbeiterTaetigkeitenArtID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterTaetigkeitenArtenUpdated(itemToUpdate);
            this.context.MitarbeiterTaetigkeitenArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterTaetigkeitenArtens.Where(i => i.MitarbeiterTaetigkeitenArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterTaetigkeitenArtenCreated(Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterTaetigkeitenArten item)
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

            this.OnMitarbeiterTaetigkeitenArtenCreated(item);
            this.context.MitarbeiterTaetigkeitenArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/MitarbeiterTaetigkeitenArtens/{item.MitarbeiterTaetigkeitenArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
