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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterVerlaufGehalts")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterVerlaufGehalts")]
  public partial class MitarbeiterVerlaufGehaltsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterVerlaufGehaltsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterVerlaufGehalts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterVerlaufGehalt> GetMitarbeiterVerlaufGehalts()
    {
      var items = this.context.MitarbeiterVerlaufGehalts.AsQueryable<Models.DbSinDarEla.MitarbeiterVerlaufGehalt>();
      this.OnMitarbeiterVerlaufGehaltsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterVerlaufGehaltsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufGehalt> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterVerlaufGehaltID}")]
    public SingleResult<MitarbeiterVerlaufGehalt> GetMitarbeiterVerlaufGehalt(int key)
    {
        var items = this.context.MitarbeiterVerlaufGehalts.Where(i=>i.MitarbeiterVerlaufGehaltID == key);
        this.OnMitarbeiterVerlaufGehaltsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterVerlaufGehaltsGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufGehalt> items);

    partial void OnMitarbeiterVerlaufGehaltDeleted(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);

    [HttpDelete("{MitarbeiterVerlaufGehaltID}")]
    public IActionResult DeleteMitarbeiterVerlaufGehalt(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterVerlaufGehalts
                .Where(i => i.MitarbeiterVerlaufGehaltID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterVerlaufGehaltDeleted(itemToDelete);
            this.context.MitarbeiterVerlaufGehalts.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufGehaltUpdated(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);

    [HttpPut("{MitarbeiterVerlaufGehaltID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterVerlaufGehalt(int key, [FromBody]Models.DbSinDarEla.MitarbeiterVerlaufGehalt newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterVerlaufGehaltID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufGehaltUpdated(newItem);
            this.context.MitarbeiterVerlaufGehalts.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufGehalts.Where(i => i.MitarbeiterVerlaufGehaltID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterVerlaufGehaltID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterVerlaufGehalt(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterVerlaufGehalt> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterVerlaufGehalts.Where(i => i.MitarbeiterVerlaufGehaltID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterVerlaufGehaltUpdated(itemToUpdate);
            this.context.MitarbeiterVerlaufGehalts.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufGehalts.Where(i => i.MitarbeiterVerlaufGehaltID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufGehaltCreated(Models.DbSinDarEla.MitarbeiterVerlaufGehalt item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterVerlaufGehalt item)
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

            this.OnMitarbeiterVerlaufGehaltCreated(item);
            this.context.MitarbeiterVerlaufGehalts.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterVerlaufGehaltID;

            var itemToReturn = this.context.MitarbeiterVerlaufGehalts.Where(i => i.MitarbeiterVerlaufGehaltID == key);

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
