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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenKontaktes")]
  [Route("mvc/odata/dbSinDarEla/KundenKontaktes")]
  public partial class KundenKontaktesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenKontaktesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenKontaktes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenKontakte> GetKundenKontaktes()
    {
      var items = this.context.KundenKontaktes.AsQueryable<Models.DbSinDarEla.KundenKontakte>();
      this.OnKundenKontaktesRead(ref items);

      return items;
    }

    partial void OnKundenKontaktesRead(ref IQueryable<Models.DbSinDarEla.KundenKontakte> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenKontaktID}")]
    public SingleResult<KundenKontakte> GetKundenKontakte(int key)
    {
        var items = this.context.KundenKontaktes.Where(i=>i.KundenKontaktID == key);
        this.OnKundenKontaktesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenKontaktesGet(ref IQueryable<Models.DbSinDarEla.KundenKontakte> items);

    partial void OnKundenKontakteDeleted(Models.DbSinDarEla.KundenKontakte item);

    [HttpDelete("{KundenKontaktID}")]
    public IActionResult DeleteKundenKontakte(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenKontaktes
                .Where(i => i.KundenKontaktID == key)
                .Include(i => i.KundenLeistungenBescheides)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenKontakteDeleted(itemToDelete);
            this.context.KundenKontaktes.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenKontakteUpdated(Models.DbSinDarEla.KundenKontakte item);

    [HttpPut("{KundenKontaktID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenKontakte(int key, [FromBody]Models.DbSinDarEla.KundenKontakte newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenKontaktID != key))
            {
                return BadRequest();
            }

            this.OnKundenKontakteUpdated(newItem);
            this.context.KundenKontaktes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenKontaktes.Where(i => i.KundenKontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Kunden,KundenKontakteArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenKontaktID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenKontakte(int key, [FromBody]Delta<Models.DbSinDarEla.KundenKontakte> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenKontaktes.Where(i => i.KundenKontaktID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenKontakteUpdated(itemToUpdate);
            this.context.KundenKontaktes.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenKontaktes.Where(i => i.KundenKontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Kunden,KundenKontakteArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenKontakteCreated(Models.DbSinDarEla.KundenKontakte item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenKontakte item)
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

            this.OnKundenKontakteCreated(item);
            this.context.KundenKontaktes.Add(item);
            this.context.SaveChanges();

            var key = item.KundenKontaktID;

            var itemToReturn = this.context.KundenKontaktes.Where(i => i.KundenKontaktID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,Kunden,KundenKontakteArten");

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
