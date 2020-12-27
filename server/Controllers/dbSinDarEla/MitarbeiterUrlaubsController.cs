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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterUrlaubs")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterUrlaubs")]
  public partial class MitarbeiterUrlaubsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterUrlaubsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterUrlaubs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterUrlaub> GetMitarbeiterUrlaubs()
    {
      var items = this.context.MitarbeiterUrlaubs.AsQueryable<Models.DbSinDarEla.MitarbeiterUrlaub>();
      this.OnMitarbeiterUrlaubsRead(ref items);

      return items;
    }

    partial void OnMitarbeiterUrlaubsRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaub> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterUrlaubID}")]
    public SingleResult<MitarbeiterUrlaub> GetMitarbeiterUrlaub(int key)
    {
        var items = this.context.MitarbeiterUrlaubs.Where(i=>i.MitarbeiterUrlaubID == key);
        this.OnMitarbeiterUrlaubsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterUrlaubsGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterUrlaub> items);

    partial void OnMitarbeiterUrlaubDeleted(Models.DbSinDarEla.MitarbeiterUrlaub item);

    [HttpDelete("{MitarbeiterUrlaubID}")]
    public IActionResult DeleteMitarbeiterUrlaub(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterUrlaubs
                .Where(i => i.MitarbeiterUrlaubID == key)
                .Include(i => i.MitarbeiterUrlaubDetails)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterUrlaubDeleted(itemToDelete);
            this.context.MitarbeiterUrlaubs.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubUpdated(Models.DbSinDarEla.MitarbeiterUrlaub item);

    [HttpPut("{MitarbeiterUrlaubID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterUrlaub(int key, [FromBody]Models.DbSinDarEla.MitarbeiterUrlaub newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterUrlaubID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUrlaubUpdated(newItem);
            this.context.MitarbeiterUrlaubs.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubs.Where(i => i.MitarbeiterUrlaubID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterUrlaubID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterUrlaub(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterUrlaub> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterUrlaubs.Where(i => i.MitarbeiterUrlaubID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterUrlaubUpdated(itemToUpdate);
            this.context.MitarbeiterUrlaubs.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterUrlaubs.Where(i => i.MitarbeiterUrlaubID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitarbeiter");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUrlaubCreated(Models.DbSinDarEla.MitarbeiterUrlaub item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterUrlaub item)
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

            this.OnMitarbeiterUrlaubCreated(item);
            this.context.MitarbeiterUrlaubs.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterUrlaubID;

            var itemToReturn = this.context.MitarbeiterUrlaubs.Where(i => i.MitarbeiterUrlaubID == key);

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
