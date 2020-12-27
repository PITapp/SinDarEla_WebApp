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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenLeistungenBetreuerArtens")]
  [Route("mvc/odata/dbSinDarEla/KundenLeistungenBetreuerArtens")]
  public partial class KundenLeistungenBetreuerArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenLeistungenBetreuerArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBetreuerArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBetreuerArten> GetKundenLeistungenBetreuerArtens()
    {
      var items = this.context.KundenLeistungenBetreuerArtens.AsQueryable<Models.DbSinDarEla.KundenLeistungenBetreuerArten>();
      this.OnKundenLeistungenBetreuerArtensRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBetreuerArtensRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBetreuerArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungenBetreuerArtID}")]
    public SingleResult<KundenLeistungenBetreuerArten> GetKundenLeistungenBetreuerArten(int key)
    {
        var items = this.context.KundenLeistungenBetreuerArtens.Where(i=>i.KundenLeistungenBetreuerArtID == key);
        this.OnKundenLeistungenBetreuerArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenLeistungenBetreuerArtensGet(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBetreuerArten> items);

    partial void OnKundenLeistungenBetreuerArtenDeleted(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);

    [HttpDelete("{KundenLeistungenBetreuerArtID}")]
    public IActionResult DeleteKundenLeistungenBetreuerArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenLeistungenBetreuerArtens
                .Where(i => i.KundenLeistungenBetreuerArtID == key)
                .Include(i => i.KundenLeistungenBetreuers)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenLeistungenBetreuerArtenDeleted(itemToDelete);
            this.context.KundenLeistungenBetreuerArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBetreuerArtenUpdated(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);

    [HttpPut("{KundenLeistungenBetreuerArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBetreuerArten(int key, [FromBody]Models.DbSinDarEla.KundenLeistungenBetreuerArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungenBetreuerArtID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBetreuerArtenUpdated(newItem);
            this.context.KundenLeistungenBetreuerArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBetreuerArtens.Where(i => i.KundenLeistungenBetreuerArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenLeistungenBetreuerArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBetreuerArten(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBetreuerArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenLeistungenBetreuerArtens.Where(i => i.KundenLeistungenBetreuerArtID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenLeistungenBetreuerArtenUpdated(itemToUpdate);
            this.context.KundenLeistungenBetreuerArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBetreuerArtens.Where(i => i.KundenLeistungenBetreuerArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBetreuerArtenCreated(Models.DbSinDarEla.KundenLeistungenBetreuerArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBetreuerArten item)
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

            this.OnKundenLeistungenBetreuerArtenCreated(item);
            this.context.KundenLeistungenBetreuerArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/KundenLeistungenBetreuerArtens/{item.KundenLeistungenBetreuerArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
