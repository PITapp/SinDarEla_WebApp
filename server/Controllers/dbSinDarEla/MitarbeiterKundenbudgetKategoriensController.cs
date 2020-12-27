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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterKundenbudgetKategoriens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterKundenbudgetKategoriens")]
  public partial class MitarbeiterKundenbudgetKategoriensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterKundenbudgetKategoriensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterKundenbudgetKategoriens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> GetMitarbeiterKundenbudgetKategoriens()
    {
      var items = this.context.MitarbeiterKundenbudgetKategoriens.AsQueryable<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien>();
      this.OnMitarbeiterKundenbudgetKategoriensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterKundenbudgetKategoriensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenbudgetKategorieID}")]
    public SingleResult<MitarbeiterKundenbudgetKategorien> GetMitarbeiterKundenbudgetKategorien(int key)
    {
        var items = this.context.MitarbeiterKundenbudgetKategoriens.Where(i=>i.KundenbudgetKategorieID == key);
        this.OnMitarbeiterKundenbudgetKategoriensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterKundenbudgetKategoriensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> items);

    partial void OnMitarbeiterKundenbudgetKategorienDeleted(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);

    [HttpDelete("{KundenbudgetKategorieID}")]
    public IActionResult DeleteMitarbeiterKundenbudgetKategorien(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterKundenbudgetKategoriens
                .Where(i => i.KundenbudgetKategorieID == key)
                .Include(i => i.MitarbeiterKundenbudgets)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterKundenbudgetKategorienDeleted(itemToDelete);
            this.context.MitarbeiterKundenbudgetKategoriens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterKundenbudgetKategorienUpdated(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);

    [HttpPut("{KundenbudgetKategorieID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterKundenbudgetKategorien(int key, [FromBody]Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenbudgetKategorieID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterKundenbudgetKategorienUpdated(newItem);
            this.context.MitarbeiterKundenbudgetKategoriens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterKundenbudgetKategoriens.Where(i => i.KundenbudgetKategorieID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenbudgetKategorieID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterKundenbudgetKategorien(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterKundenbudgetKategoriens.Where(i => i.KundenbudgetKategorieID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterKundenbudgetKategorienUpdated(itemToUpdate);
            this.context.MitarbeiterKundenbudgetKategoriens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterKundenbudgetKategoriens.Where(i => i.KundenbudgetKategorieID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterKundenbudgetKategorienCreated(Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterKundenbudgetKategorien item)
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

            this.OnMitarbeiterKundenbudgetKategorienCreated(item);
            this.context.MitarbeiterKundenbudgetKategoriens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/MitarbeiterKundenbudgetKategoriens/{item.KundenbudgetKategorieID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
