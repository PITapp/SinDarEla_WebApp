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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits")]
  public partial class MitarbeiterVerlaufNormalarbeitszeitsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterVerlaufNormalarbeitszeitsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterVerlaufNormalarbeitszeits
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> GetMitarbeiterVerlaufNormalarbeitszeits()
    {
      var items = this.context.MitarbeiterVerlaufNormalarbeitszeits.AsQueryable<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit>();
      this.OnMitarbeiterVerlaufNormalarbeitszeitsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterVerlaufNormalarbeitszeitsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterVerlaufNormalarbeitszeitID}")]
    public SingleResult<MitarbeiterVerlaufNormalarbeitszeit> GetMitarbeiterVerlaufNormalarbeitszeit(int key)
    {
        var items = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i=>i.MitarbeiterVerlaufNormalarbeitszeitID == key);
        this.OnMitarbeiterVerlaufNormalarbeitszeitsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterVerlaufNormalarbeitszeitsGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> items);

    partial void OnMitarbeiterVerlaufNormalarbeitszeitDeleted(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);

    [HttpDelete("{MitarbeiterVerlaufNormalarbeitszeitID}")]
    public IActionResult DeleteMitarbeiterVerlaufNormalarbeitszeit(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterVerlaufNormalarbeitszeits
                .Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterVerlaufNormalarbeitszeitDeleted(itemToDelete);
            this.context.MitarbeiterVerlaufNormalarbeitszeits.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufNormalarbeitszeitUpdated(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);

    [HttpPut("{MitarbeiterVerlaufNormalarbeitszeitID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterVerlaufNormalarbeitszeit(int key, [FromBody]Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterVerlaufNormalarbeitszeitID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufNormalarbeitszeitUpdated(newItem);
            this.context.MitarbeiterVerlaufNormalarbeitszeits.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterVerlaufNormalarbeitszeitID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterVerlaufNormalarbeitszeit(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterVerlaufNormalarbeitszeitUpdated(itemToUpdate);
            this.context.MitarbeiterVerlaufNormalarbeitszeits.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufNormalarbeitszeitCreated(Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterVerlaufNormalarbeitszeit item)
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

            this.OnMitarbeiterVerlaufNormalarbeitszeitCreated(item);
            this.context.MitarbeiterVerlaufNormalarbeitszeits.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterVerlaufNormalarbeitszeitID;

            var itemToReturn = this.context.MitarbeiterVerlaufNormalarbeitszeits.Where(i => i.MitarbeiterVerlaufNormalarbeitszeitID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");

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
