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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenLeistungenBescheides")]
  [Route("mvc/odata/dbSinDarEla/KundenLeistungenBescheides")]
  public partial class KundenLeistungenBescheidesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenLeistungenBescheidesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBescheides
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBescheide> GetKundenLeistungenBescheides()
    {
      var items = this.context.KundenLeistungenBescheides.AsQueryable<Models.DbSinDarEla.KundenLeistungenBescheide>();
      this.OnKundenLeistungenBescheidesRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBescheidesRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBescheide> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungenBescheidID}")]
    public SingleResult<KundenLeistungenBescheide> GetKundenLeistungenBescheide(int key)
    {
        var items = this.context.KundenLeistungenBescheides.Where(i=>i.KundenLeistungenBescheidID == key);
        this.OnKundenLeistungenBescheidesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenLeistungenBescheidesGet(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBescheide> items);

    partial void OnKundenLeistungenBescheideDeleted(Models.DbSinDarEla.KundenLeistungenBescheide item);

    [HttpDelete("{KundenLeistungenBescheidID}")]
    public IActionResult DeleteKundenLeistungenBescheide(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenLeistungenBescheides
                .Where(i => i.KundenLeistungenBescheidID == key)
                .Include(i => i.KundenLeistungenBescheideKontingentes)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenLeistungenBescheideDeleted(itemToDelete);
            this.context.KundenLeistungenBescheides.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideUpdated(Models.DbSinDarEla.KundenLeistungenBescheide item);

    [HttpPut("{KundenLeistungenBescheidID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBescheide(int key, [FromBody]Models.DbSinDarEla.KundenLeistungenBescheide newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungenBescheidID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBescheideUpdated(newItem);
            this.context.KundenLeistungenBescheides.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheides.Where(i => i.KundenLeistungenBescheidID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "KundenKontakte,KundenLeistungen,KundenLeistungenBescheideStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenLeistungenBescheidID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBescheide(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBescheide> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenLeistungenBescheides.Where(i => i.KundenLeistungenBescheidID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenLeistungenBescheideUpdated(itemToUpdate);
            this.context.KundenLeistungenBescheides.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheides.Where(i => i.KundenLeistungenBescheidID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "KundenKontakte,KundenLeistungen,KundenLeistungenBescheideStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideCreated(Models.DbSinDarEla.KundenLeistungenBescheide item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBescheide item)
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

            this.OnKundenLeistungenBescheideCreated(item);
            this.context.KundenLeistungenBescheides.Add(item);
            this.context.SaveChanges();

            var key = item.KundenLeistungenBescheidID;

            var itemToReturn = this.context.KundenLeistungenBescheides.Where(i => i.KundenLeistungenBescheidID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "KundenKontakte,KundenLeistungen,KundenLeistungenBescheideStatus");

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
