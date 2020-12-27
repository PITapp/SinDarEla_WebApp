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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterKundenbudgets")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterKundenbudgets")]
  public partial class MitarbeiterKundenbudgetsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterKundenbudgetsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterKundenbudgets
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterKundenbudget> GetMitarbeiterKundenbudgets()
    {
      var items = this.context.MitarbeiterKundenbudgets.AsQueryable<Models.DbSinDarEla.MitarbeiterKundenbudget>();
      this.OnMitarbeiterKundenbudgetsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterKundenbudgetsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterKundenbudget> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterKundenbudgetID}")]
    public SingleResult<MitarbeiterKundenbudget> GetMitarbeiterKundenbudget(int key)
    {
        var items = this.context.MitarbeiterKundenbudgets.Where(i=>i.MitarbeiterKundenbudgetID == key);
        this.OnMitarbeiterKundenbudgetsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterKundenbudgetsGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterKundenbudget> items);

    partial void OnMitarbeiterKundenbudgetDeleted(Models.DbSinDarEla.MitarbeiterKundenbudget item);

    [HttpDelete("{MitarbeiterKundenbudgetID}")]
    public IActionResult DeleteMitarbeiterKundenbudget(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterKundenbudgets
                .Where(i => i.MitarbeiterKundenbudgetID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterKundenbudgetDeleted(itemToDelete);
            this.context.MitarbeiterKundenbudgets.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterKundenbudgetUpdated(Models.DbSinDarEla.MitarbeiterKundenbudget item);

    [HttpPut("{MitarbeiterKundenbudgetID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterKundenbudget(int key, [FromBody]Models.DbSinDarEla.MitarbeiterKundenbudget newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterKundenbudgetID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterKundenbudgetUpdated(newItem);
            this.context.MitarbeiterKundenbudgets.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterKundenbudgets.Where(i => i.MitarbeiterKundenbudgetID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterKundenbudgetKategorien");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterKundenbudgetID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterKundenbudget(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterKundenbudget> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterKundenbudgets.Where(i => i.MitarbeiterKundenbudgetID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterKundenbudgetUpdated(itemToUpdate);
            this.context.MitarbeiterKundenbudgets.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterKundenbudgets.Where(i => i.MitarbeiterKundenbudgetID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterKundenbudgetKategorien");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterKundenbudgetCreated(Models.DbSinDarEla.MitarbeiterKundenbudget item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterKundenbudget item)
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

            this.OnMitarbeiterKundenbudgetCreated(item);
            this.context.MitarbeiterKundenbudgets.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterKundenbudgetID;

            var itemToReturn = this.context.MitarbeiterKundenbudgets.Where(i => i.MitarbeiterKundenbudgetID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterKundenbudgetKategorien");

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
