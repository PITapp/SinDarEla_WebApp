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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches")]
  public partial class MitarbeiterUrlaubKumuliertAnspruchesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterUrlaubKumuliertAnspruchesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterUrlaubKumuliertAnspruches
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> GetMitarbeiterUrlaubKumuliertAnspruches()
    {
      var items = this.context.MitarbeiterUrlaubKumuliertAnspruches.AsQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch>();
      this.OnMitarbeiterUrlaubKumuliertAnspruchesRead(ref items);

      return items;
    }

    partial void OnMitarbeiterUrlaubKumuliertAnspruchesRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterUrlaubKumuliertAnspruchID}")]
    public SingleResult<MitarbeiterUrlaubKumuliertAnspruch> GetMitarbeiterUrlaubKumuliertAnspruch(int key)
    {
        var items = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i=>i.MitarbeiterUrlaubKumuliertAnspruchID == key);
        this.OnMitarbeiterUrlaubKumuliertAnspruchesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterUrlaubKumuliertAnspruchesGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> items);

    partial void OnMitarbeiterUrlaubKumuliertAnspruchDeleted(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);

    [HttpDelete("{MitarbeiterUrlaubKumuliertAnspruchID}")]
    public IActionResult DeleteMitarbeiterUrlaubKumuliertAnspruch(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterUrlaubKumuliertAnspruches
                .Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterUrlaubKumuliertAnspruchDeleted(itemToDelete);
            this.context.MitarbeiterUrlaubKumuliertAnspruches.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubKumuliertAnspruchUpdated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);

    [HttpPut("{MitarbeiterUrlaubKumuliertAnspruchID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterUrlaubKumuliertAnspruch(int key, [FromBody]Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterUrlaubKumuliertAnspruchID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubKumuliertAnspruchUpdated(newItem);
            this.context.MitarbeiterUrlaubKumuliertAnspruches.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterUrlaubKumuliertAnspruchID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterUrlaubKumuliertAnspruch(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterUrlaubKumuliertAnspruchUpdated(itemToUpdate);
            this.context.MitarbeiterUrlaubKumuliertAnspruches.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubKumuliertAnspruchCreated(Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterUrlaubKumuliertAnspruch item)
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

            this.OnMitarbeiterUrlaubKumuliertAnspruchCreated(item);
            this.context.MitarbeiterUrlaubKumuliertAnspruches.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterUrlaubKumuliertAnspruchID;

            var itemToReturn = this.context.MitarbeiterUrlaubKumuliertAnspruches.Where(i => i.MitarbeiterUrlaubKumuliertAnspruchID == key);

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
