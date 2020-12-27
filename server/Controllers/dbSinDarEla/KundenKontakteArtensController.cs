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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenKontakteArtens")]
  [Route("mvc/odata/dbSinDarEla/KundenKontakteArtens")]
  public partial class KundenKontakteArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenKontakteArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenKontakteArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenKontakteArten> GetKundenKontakteArtens()
    {
      var items = this.context.KundenKontakteArtens.AsQueryable<Models.DbSinDarEla.KundenKontakteArten>();
      this.OnKundenKontakteArtensRead(ref items);

      return items;
    }

    partial void OnKundenKontakteArtensRead(ref IQueryable<Models.DbSinDarEla.KundenKontakteArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenKontaktArtID}")]
    public SingleResult<KundenKontakteArten> GetKundenKontakteArten(int key)
    {
        var items = this.context.KundenKontakteArtens.Where(i=>i.KundenKontaktArtID == key);
        this.OnKundenKontakteArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenKontakteArtensGet(ref IQueryable<Models.DbSinDarEla.KundenKontakteArten> items);

    partial void OnKundenKontakteArtenDeleted(Models.DbSinDarEla.KundenKontakteArten item);

    [HttpDelete("{KundenKontaktArtID}")]
    public IActionResult DeleteKundenKontakteArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenKontakteArtens
                .Where(i => i.KundenKontaktArtID == key)
                .Include(i => i.KundenKontaktes)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenKontakteArtenDeleted(itemToDelete);
            this.context.KundenKontakteArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenKontakteArtenUpdated(Models.DbSinDarEla.KundenKontakteArten item);

    [HttpPut("{KundenKontaktArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenKontakteArten(int key, [FromBody]Models.DbSinDarEla.KundenKontakteArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenKontaktArtID != key))
            {
                return BadRequest();
            }

            this.OnKundenKontakteArtenUpdated(newItem);
            this.context.KundenKontakteArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenKontakteArtens.Where(i => i.KundenKontaktArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenKontaktArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenKontakteArten(int key, [FromBody]Delta<Models.DbSinDarEla.KundenKontakteArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenKontakteArtens.Where(i => i.KundenKontaktArtID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenKontakteArtenUpdated(itemToUpdate);
            this.context.KundenKontakteArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenKontakteArtens.Where(i => i.KundenKontaktArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenKontakteArtenCreated(Models.DbSinDarEla.KundenKontakteArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenKontakteArten item)
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

            this.OnKundenKontakteArtenCreated(item);
            this.context.KundenKontakteArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/KundenKontakteArtens/{item.KundenKontaktArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
