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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens")]
  public partial class MitarbeiterUrlaubKumuliertDienstzeitensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterUrlaubKumuliertDienstzeitensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterUrlaubKumuliertDienstzeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> GetMitarbeiterUrlaubKumuliertDienstzeitens()
    {
      var items = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.AsQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten>();
      this.OnMitarbeiterUrlaubKumuliertDienstzeitensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterUrlaubKumuliertDienstzeitenID}")]
    public SingleResult<MitarbeiterUrlaubKumuliertDienstzeiten> GetMitarbeiterUrlaubKumuliertDienstzeiten(int key)
    {
        var items = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i=>i.MitarbeiterUrlaubKumuliertDienstzeitenID == key);
        this.OnMitarbeiterUrlaubKumuliertDienstzeitensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> items);

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitenDeleted(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);

    [HttpDelete("{MitarbeiterUrlaubKumuliertDienstzeitenID}")]
    public IActionResult DeleteMitarbeiterUrlaubKumuliertDienstzeiten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterUrlaubKumuliertDienstzeitens
                .Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterUrlaubKumuliertDienstzeitenDeleted(itemToDelete);
            this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitenUpdated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);

    [HttpPut("{MitarbeiterUrlaubKumuliertDienstzeitenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterUrlaubKumuliertDienstzeiten(int key, [FromBody]Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterUrlaubKumuliertDienstzeitenID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubKumuliertDienstzeitenUpdated(newItem);
            this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterUrlaubKumuliertDienstzeitenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterUrlaubKumuliertDienstzeiten(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterUrlaubKumuliertDienstzeitenUpdated(itemToUpdate);
            this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubKumuliertDienstzeitenCreated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterUrlaubKumuliertDienstzeiten item)
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

            this.OnMitarbeiterUrlaubKumuliertDienstzeitenCreated(item);
            this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterUrlaubKumuliertDienstzeitenID;

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertDienstzeitens.Where(i => i.MitarbeiterUrlaubKumuliertDienstzeitenID == key);

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
