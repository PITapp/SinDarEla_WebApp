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

  [ODataRoutePrefix("odata/dbSinDarEla/Kundens")]
  [Route("mvc/odata/dbSinDarEla/Kundens")]
  public partial class KundensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Kundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Kunden> GetKundens()
    {
      var items = this.context.Kundens.AsQueryable<Models.DbSinDarEla.Kunden>();
      this.OnKundensRead(ref items);

      return items;
    }

    partial void OnKundensRead(ref IQueryable<Models.DbSinDarEla.Kunden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenID}")]
    public SingleResult<Kunden> GetKunden(int key)
    {
        var items = this.context.Kundens.Where(i=>i.KundenID == key);
        this.OnKundensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundensGet(ref IQueryable<Models.DbSinDarEla.Kunden> items);

    partial void OnKundenDeleted(Models.DbSinDarEla.Kunden item);

    [HttpDelete("{KundenID}")]
    public IActionResult DeleteKunden(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Kundens
                .Where(i => i.KundenID == key)
                .Include(i => i.AbrechnungKundenReststundens)
                .Include(i => i.Dokumentes)
                .Include(i => i.Ereignisses)
                .Include(i => i.KundenInfos)
                .Include(i => i.KundenKontaktes)
                .Include(i => i.KundenLeistungens)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenDeleted(itemToDelete);
            this.context.Kundens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenUpdated(Models.DbSinDarEla.Kunden item);

    [HttpPut("{KundenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKunden(int key, [FromBody]Models.DbSinDarEla.Kunden newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenID != key))
            {
                return BadRequest();
            }

            this.OnKundenUpdated(newItem);
            this.context.Kundens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Kundens.Where(i => i.KundenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKunden(int key, [FromBody]Delta<Models.DbSinDarEla.Kunden> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Kundens.Where(i => i.KundenID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenUpdated(itemToUpdate);
            this.context.Kundens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Kundens.Where(i => i.KundenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenCreated(Models.DbSinDarEla.Kunden item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Kunden item)
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

            this.OnKundenCreated(item);
            this.context.Kundens.Add(item);
            this.context.SaveChanges();

            var key = item.KundenID;

            var itemToReturn = this.context.Kundens.Where(i => i.KundenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenStatus");

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
