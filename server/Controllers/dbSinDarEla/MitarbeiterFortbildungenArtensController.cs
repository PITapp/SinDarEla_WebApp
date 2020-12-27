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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterFortbildungenArtens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterFortbildungenArtens")]
  public partial class MitarbeiterFortbildungenArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterFortbildungenArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterFortbildungenArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterFortbildungenArten> GetMitarbeiterFortbildungenArtens()
    {
      var items = this.context.MitarbeiterFortbildungenArtens.AsQueryable<Models.DbSinDarEla.MitarbeiterFortbildungenArten>();
      this.OnMitarbeiterFortbildungenArtensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterFortbildungenArtensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterFortbildungenArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{FortbildungArtID}")]
    public SingleResult<MitarbeiterFortbildungenArten> GetMitarbeiterFortbildungenArten(int key)
    {
        var items = this.context.MitarbeiterFortbildungenArtens.Where(i=>i.FortbildungArtID == key);
        this.OnMitarbeiterFortbildungenArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterFortbildungenArtensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterFortbildungenArten> items);

    partial void OnMitarbeiterFortbildungenArtenDeleted(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);

    [HttpDelete("{FortbildungArtID}")]
    public IActionResult DeleteMitarbeiterFortbildungenArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterFortbildungenArtens
                .Where(i => i.FortbildungArtID == key)
                .Include(i => i.MitarbeiterFortbildungens)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterFortbildungenArtenDeleted(itemToDelete);
            this.context.MitarbeiterFortbildungenArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFortbildungenArtenUpdated(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);

    [HttpPut("{FortbildungArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterFortbildungenArten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterFortbildungenArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.FortbildungArtID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterFortbildungenArtenUpdated(newItem);
            this.context.MitarbeiterFortbildungenArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFortbildungenArtens.Where(i => i.FortbildungArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{FortbildungArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterFortbildungenArten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterFortbildungenArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterFortbildungenArtens.Where(i => i.FortbildungArtID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterFortbildungenArtenUpdated(itemToUpdate);
            this.context.MitarbeiterFortbildungenArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFortbildungenArtens.Where(i => i.FortbildungArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFortbildungenArtenCreated(Models.DbSinDarEla.MitarbeiterFortbildungenArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterFortbildungenArten item)
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

            this.OnMitarbeiterFortbildungenArtenCreated(item);
            this.context.MitarbeiterFortbildungenArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/MitarbeiterFortbildungenArtens/{item.FortbildungArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
