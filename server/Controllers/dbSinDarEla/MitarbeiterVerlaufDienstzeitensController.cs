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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterVerlaufDienstzeitens")]
  public partial class MitarbeiterVerlaufDienstzeitensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterVerlaufDienstzeitensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterVerlaufDienstzeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> GetMitarbeiterVerlaufDienstzeitens()
    {
      var items = this.context.MitarbeiterVerlaufDienstzeitens.AsQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten>();
      this.OnMitarbeiterVerlaufDienstzeitensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterVerlaufDienstzeitensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterVerlaufDienstzeitenID}")]
    public SingleResult<MitarbeiterVerlaufDienstzeiten> GetMitarbeiterVerlaufDienstzeiten(int key)
    {
        var items = this.context.MitarbeiterVerlaufDienstzeitens.Where(i=>i.MitarbeiterVerlaufDienstzeitenID == key);
        this.OnMitarbeiterVerlaufDienstzeitensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterVerlaufDienstzeitensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> items);

    partial void OnMitarbeiterVerlaufDienstzeitenDeleted(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);

    [HttpDelete("{MitarbeiterVerlaufDienstzeitenID}")]
    public IActionResult DeleteMitarbeiterVerlaufDienstzeiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterVerlaufDienstzeitens
                .Where(i => i.MitarbeiterVerlaufDienstzeitenID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterVerlaufDienstzeitenDeleted(itemToDelete);
            this.context.MitarbeiterVerlaufDienstzeitens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufDienstzeitenUpdated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);

    [HttpPut("{MitarbeiterVerlaufDienstzeitenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterVerlaufDienstzeiten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterVerlaufDienstzeitenID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterVerlaufDienstzeitenUpdated(newItem);
            this.context.MitarbeiterVerlaufDienstzeitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitens.Where(i => i.MitarbeiterVerlaufDienstzeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterVerlaufDienstzeitenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterVerlaufDienstzeitenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterVerlaufDienstzeiten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterVerlaufDienstzeitens.Where(i => i.MitarbeiterVerlaufDienstzeitenID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterVerlaufDienstzeitenUpdated(itemToUpdate);
            this.context.MitarbeiterVerlaufDienstzeitens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitens.Where(i => i.MitarbeiterVerlaufDienstzeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterVerlaufDienstzeitenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterVerlaufDienstzeitenCreated(Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterVerlaufDienstzeiten item)
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

            this.OnMitarbeiterVerlaufDienstzeitenCreated(item);
            this.context.MitarbeiterVerlaufDienstzeitens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterVerlaufDienstzeitenID;

            var itemToReturn = this.context.MitarbeiterVerlaufDienstzeitens.Where(i => i.MitarbeiterVerlaufDienstzeitenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter,MitarbeiterVerlaufDienstzeitenArten");

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
