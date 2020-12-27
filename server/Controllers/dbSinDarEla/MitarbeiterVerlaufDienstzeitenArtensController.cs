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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens")]
  public partial class MitarbeiterVerlaufDienstzeitenArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterVerlaufDienstzeitenArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> GetMitarbeiterVerlaufDienstzeitenArtens()
    {
      var items = this.context.MitarbeiterVerlaufDienstzeitenArtens.AsQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten>();
      this.OnMitarbeiterVerlaufDienstzeitenArtensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterVerlaufDienstzeitenArtensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterVerlaufDienstzeitenArtID}")]
    public SingleResult<MitarbeiterVerlaufDienstzeitenArten> GetMitarbeiterVerlaufDienstzeitenArten(int key)
    {
        var items = this.context.MitarbeiterVerlaufDienstzeitenArtens.Where(i=>i.MitarbeiterVerlaufDienstzeitenArtID == key);
        this.OnMitarbeiterVerlaufDienstzeitenArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterVerlaufDienstzeitenArtensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> items);

    partial void OnMitarbeiterVerlaufDienstzeitenArtenDeleted(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);

    [HttpDelete("{MitarbeiterVerlaufDienstzeitenArtID}")]
    public IActionResult DeleteMitarbeiterVerlaufDienstzeitenArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterVerlaufDienstzeitenArtens
                .Where(i => i.MitarbeiterVerlaufDienstzeitenArtID == key)
                .Include(i => i.MitarbeiterVerlaufDienstzeitens)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterVerlaufDienstzeitenArtenDeleted(itemToDelete);
            this.context.MitarbeiterVerlaufDienstzeitenArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufDienstzeitenArtenUpdated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);

    [HttpPut("{MitarbeiterVerlaufDienstzeitenArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterVerlaufDienstzeitenArten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterVerlaufDienstzeitenArtID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufDienstzeitenArtenUpdated(newItem);
            this.context.MitarbeiterVerlaufDienstzeitenArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitenArtens.Where(i => i.MitarbeiterVerlaufDienstzeitenArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterVerlaufDienstzeitenArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterVerlaufDienstzeitenArten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterVerlaufDienstzeitenArtens.Where(i => i.MitarbeiterVerlaufDienstzeitenArtID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterVerlaufDienstzeitenArtenUpdated(itemToUpdate);
            this.context.MitarbeiterVerlaufDienstzeitenArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitenArtens.Where(i => i.MitarbeiterVerlaufDienstzeitenArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufDienstzeitenArtenCreated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterVerlaufDienstzeitenArten item)
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

            this.OnMitarbeiterVerlaufDienstzeitenArtenCreated(item);
            this.context.MitarbeiterVerlaufDienstzeitenArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/MitarbeiterVerlaufDienstzeitenArtens/{item.MitarbeiterVerlaufDienstzeitenArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
