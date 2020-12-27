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

  [ODataRoutePrefix("odata/dbSinDarEla/Dokumentes")]
  [Route("mvc/odata/dbSinDarEla/Dokumentes")]
  public partial class DokumentesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public DokumentesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Dokumentes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Dokumente> GetDokumentes()
    {
      var items = this.context.Dokumentes.AsQueryable<Models.DbSinDarEla.Dokumente>();
      this.OnDokumentesRead(ref items);

      return items;
    }

    partial void OnDokumentesRead(ref IQueryable<Models.DbSinDarEla.Dokumente> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{DokumentID}")]
    public SingleResult<Dokumente> GetDokumente(int key)
    {
        var items = this.context.Dokumentes.Where(i=>i.DokumentID == key);
        this.OnDokumentesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnDokumentesGet(ref IQueryable<Models.DbSinDarEla.Dokumente> items);

    partial void OnDokumenteDeleted(Models.DbSinDarEla.Dokumente item);

    [HttpDelete("{DokumentID}")]
    public IActionResult DeleteDokumente(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Dokumentes
                .Where(i => i.DokumentID == key)
                .Include(i => i.MitarbeiterFortbildungens)
                .Include(i => i.Mitteilungens)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnDokumenteDeleted(itemToDelete);
            this.context.Dokumentes.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDokumenteUpdated(Models.DbSinDarEla.Dokumente item);

    [HttpPut("{DokumentID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDokumente(int key, [FromBody]Models.DbSinDarEla.Dokumente newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DokumentID != key))
            {
                return BadRequest();
            }

            this.OnDokumenteUpdated(newItem);
            this.context.Dokumentes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Dokumentes.Where(i => i.DokumentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DokumenteKategorien,Kunden,Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{DokumentID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDokumente(int key, [FromBody]Delta<Models.DbSinDarEla.Dokumente> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Dokumentes.Where(i => i.DokumentID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnDokumenteUpdated(itemToUpdate);
            this.context.Dokumentes.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Dokumentes.Where(i => i.DokumentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "DokumenteKategorien,Kunden,Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDokumenteCreated(Models.DbSinDarEla.Dokumente item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Dokumente item)
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

            this.OnDokumenteCreated(item);
            this.context.Dokumentes.Add(item);
            this.context.SaveChanges();

            var key = item.DokumentID;

            var itemToReturn = this.context.Dokumentes.Where(i => i.DokumentID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "DokumenteKategorien,Kunden,Mitarbeiter");

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
