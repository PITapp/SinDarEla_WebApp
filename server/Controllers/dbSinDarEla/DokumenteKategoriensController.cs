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

  [ODataRoutePrefix("odata/dbSinDarEla/DokumenteKategoriens")]
  [Route("mvc/odata/dbSinDarEla/DokumenteKategoriens")]
  public partial class DokumenteKategoriensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public DokumenteKategoriensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/DokumenteKategoriens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.DokumenteKategorien> GetDokumenteKategoriens()
    {
      var items = this.context.DokumenteKategoriens.AsQueryable<Models.DbSinDarEla.DokumenteKategorien>();
      this.OnDokumenteKategoriensRead(ref items);

      return items;
    }

    partial void OnDokumenteKategoriensRead(ref IQueryable<Models.DbSinDarEla.DokumenteKategorien> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{DokumenteKategorieID}")]
    public SingleResult<DokumenteKategorien> GetDokumenteKategorien(int key)
    {
        var items = this.context.DokumenteKategoriens.Where(i=>i.DokumenteKategorieID == key);
        this.OnDokumenteKategoriensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnDokumenteKategoriensGet(ref IQueryable<Models.DbSinDarEla.DokumenteKategorien> items);

    partial void OnDokumenteKategorienDeleted(Models.DbSinDarEla.DokumenteKategorien item);

    [HttpDelete("{DokumenteKategorieID}")]
    public IActionResult DeleteDokumenteKategorien(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.DokumenteKategoriens
                .Where(i => i.DokumenteKategorieID == key)
                .Include(i => i.Dokumentes)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnDokumenteKategorienDeleted(itemToDelete);
            this.context.DokumenteKategoriens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDokumenteKategorienUpdated(Models.DbSinDarEla.DokumenteKategorien item);

    [HttpPut("{DokumenteKategorieID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutDokumenteKategorien(int key, [FromBody]Models.DbSinDarEla.DokumenteKategorien newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.DokumenteKategorieID != key))
            {
                return BadRequest();
            }

            this.OnDokumenteKategorienUpdated(newItem);
            this.context.DokumenteKategoriens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.DokumenteKategoriens.Where(i => i.DokumenteKategorieID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{DokumenteKategorieID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchDokumenteKategorien(int key, [FromBody]Delta<Models.DbSinDarEla.DokumenteKategorien> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.DokumenteKategoriens.Where(i => i.DokumenteKategorieID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnDokumenteKategorienUpdated(itemToUpdate);
            this.context.DokumenteKategoriens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.DokumenteKategoriens.Where(i => i.DokumenteKategorieID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnDokumenteKategorienCreated(Models.DbSinDarEla.DokumenteKategorien item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.DokumenteKategorien item)
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

            this.OnDokumenteKategorienCreated(item);
            this.context.DokumenteKategoriens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/DokumenteKategoriens/{item.DokumenteKategorieID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
