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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterUrlaubDetails")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterUrlaubDetails")]
  public partial class MitarbeiterUrlaubDetailsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterUrlaubDetailsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterUrlaubDetails
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterUrlaubDetail> GetMitarbeiterUrlaubDetails()
    {
      var items = this.context.MitarbeiterUrlaubDetails.AsQueryable<Models.DbSinDarEla.MitarbeiterUrlaubDetail>();
      this.OnMitarbeiterUrlaubDetailsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterUrlaubDetailsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubDetail> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterUrlaubDetailsID}")]
    public SingleResult<MitarbeiterUrlaubDetail> GetMitarbeiterUrlaubDetail(int key)
    {
        var items = this.context.MitarbeiterUrlaubDetails.Where(i=>i.MitarbeiterUrlaubDetailsID == key);
        this.OnMitarbeiterUrlaubDetailsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterUrlaubDetailsGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaubDetail> items);

    partial void OnMitarbeiterUrlaubDetailDeleted(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);

    [HttpDelete("{MitarbeiterUrlaubDetailsID}")]
    public IActionResult DeleteMitarbeiterUrlaubDetail(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterUrlaubDetails
                .Where(i => i.MitarbeiterUrlaubDetailsID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterUrlaubDetailDeleted(itemToDelete);
            this.context.MitarbeiterUrlaubDetails.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubDetailUpdated(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);

    [HttpPut("{MitarbeiterUrlaubDetailsID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterUrlaubDetail(int key, [FromBody]Models.DbSinDarEla.MitarbeiterUrlaubDetail newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterUrlaubDetailsID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubDetailUpdated(newItem);
            this.context.MitarbeiterUrlaubDetails.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubDetails.Where(i => i.MitarbeiterUrlaubDetailsID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterUrlaub");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterUrlaubDetailsID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterUrlaubDetail(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterUrlaubDetail> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterUrlaubDetails.Where(i => i.MitarbeiterUrlaubDetailsID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterUrlaubDetailUpdated(itemToUpdate);
            this.context.MitarbeiterUrlaubDetails.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubDetails.Where(i => i.MitarbeiterUrlaubDetailsID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterUrlaub");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubDetailCreated(Models.DbSinDarEla.MitarbeiterUrlaubDetail item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterUrlaubDetail item)
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

            this.OnMitarbeiterUrlaubDetailCreated(item);
            this.context.MitarbeiterUrlaubDetails.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterUrlaubDetailsID;

            var itemToReturn = this.context.MitarbeiterUrlaubDetails.Where(i => i.MitarbeiterUrlaubDetailsID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "MitarbeiterUrlaub");

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
