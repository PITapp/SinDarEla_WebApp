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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenLeistungArtens")]
  [Route("mvc/odata/dbSinDarEla/KundenLeistungArtens")]
  public partial class KundenLeistungArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenLeistungArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungArten> GetKundenLeistungArtens()
    {
      var items = this.context.KundenLeistungArtens.AsQueryable<Models.DbSinDarEla.KundenLeistungArten>();
      this.OnKundenLeistungArtensRead(ref items);

      return items;
    }

    partial void OnKundenLeistungArtensRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungArtID}")]
    public SingleResult<KundenLeistungArten> GetKundenLeistungArten(int key)
    {
        var items = this.context.KundenLeistungArtens.Where(i=>i.KundenLeistungArtID == key);
        this.OnKundenLeistungArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenLeistungArtensGet(ref IQueryable<Models.DbSinDarEla.KundenLeistungArten> items);

    partial void OnKundenLeistungArtenDeleted(Models.DbSinDarEla.KundenLeistungArten item);

    [HttpDelete("{KundenLeistungArtID}")]
    public IActionResult DeleteKundenLeistungArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenLeistungArtens
                .Where(i => i.KundenLeistungArtID == key)
                .Include(i => i.AbrechnungKundenReststundens)
                .Include(i => i.Ereignisses)
                .Include(i => i.KundenLeistungens)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenLeistungArtenDeleted(itemToDelete);
            this.context.KundenLeistungArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungArtenUpdated(Models.DbSinDarEla.KundenLeistungArten item);

    [HttpPut("{KundenLeistungArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungArten(int key, [FromBody]Models.DbSinDarEla.KundenLeistungArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungArtID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungArtenUpdated(newItem);
            this.context.KundenLeistungArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungArtens.Where(i => i.KundenLeistungArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenLeistungArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungArten(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenLeistungArtens.Where(i => i.KundenLeistungArtID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenLeistungArtenUpdated(itemToUpdate);
            this.context.KundenLeistungArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungArtens.Where(i => i.KundenLeistungArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungArtenCreated(Models.DbSinDarEla.KundenLeistungArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungArten item)
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

            this.OnKundenLeistungArtenCreated(item);
            this.context.KundenLeistungArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/KundenLeistungArtens/{item.KundenLeistungArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
