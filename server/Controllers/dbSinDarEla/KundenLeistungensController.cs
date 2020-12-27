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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenLeistungens")]
  [Route("mvc/odata/dbSinDarEla/KundenLeistungens")]
  public partial class KundenLeistungensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenLeistungensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungen> GetKundenLeistungens()
    {
      var items = this.context.KundenLeistungens.AsQueryable<Models.DbSinDarEla.KundenLeistungen>();
      this.OnKundenLeistungensRead(ref items);

      return items;
    }

    partial void OnKundenLeistungensRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungID}")]
    public SingleResult<KundenLeistungen> GetKundenLeistungen(int key)
    {
        var items = this.context.KundenLeistungens.Where(i=>i.KundenLeistungID == key);
        this.OnKundenLeistungensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenLeistungensGet(ref IQueryable<Models.DbSinDarEla.KundenLeistungen> items);

    partial void OnKundenLeistungenDeleted(Models.DbSinDarEla.KundenLeistungen item);

    [HttpDelete("{KundenLeistungID}")]
    public IActionResult DeleteKundenLeistungen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenLeistungens
                .Where(i => i.KundenLeistungID == key)
                .Include(i => i.KundenLeistungenBescheides)
                .Include(i => i.KundenLeistungenBetreuers)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenLeistungenDeleted(itemToDelete);
            this.context.KundenLeistungens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenUpdated(Models.DbSinDarEla.KundenLeistungen item);

    [HttpPut("{KundenLeistungID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungen(int key, [FromBody]Models.DbSinDarEla.KundenLeistungen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenUpdated(newItem);
            this.context.KundenLeistungens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungens.Where(i => i.KundenLeistungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenLeistungID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungen(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenLeistungens.Where(i => i.KundenLeistungID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenLeistungenUpdated(itemToUpdate);
            this.context.KundenLeistungens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungens.Where(i => i.KundenLeistungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenCreated(Models.DbSinDarEla.KundenLeistungen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungen item)
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

            this.OnKundenLeistungenCreated(item);
            this.context.KundenLeistungens.Add(item);
            this.context.SaveChanges();

            var key = item.KundenLeistungID;

            var itemToReturn = this.context.KundenLeistungens.Where(i => i.KundenLeistungID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");

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
