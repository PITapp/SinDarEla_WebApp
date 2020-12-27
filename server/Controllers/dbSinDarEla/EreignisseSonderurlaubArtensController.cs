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

  [ODataRoutePrefix("odata/dbSinDarEla/EreignisseSonderurlaubArtens")]
  [Route("mvc/odata/dbSinDarEla/EreignisseSonderurlaubArtens")]
  public partial class EreignisseSonderurlaubArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public EreignisseSonderurlaubArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/EreignisseSonderurlaubArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.EreignisseSonderurlaubArten> GetEreignisseSonderurlaubArtens()
    {
      var items = this.context.EreignisseSonderurlaubArtens.AsQueryable<Models.DbSinDarEla.EreignisseSonderurlaubArten>();
      this.OnEreignisseSonderurlaubArtensRead(ref items);

      return items;
    }

    partial void OnEreignisseSonderurlaubArtensRead(ref IQueryable<Models.DbSinDarEla.EreignisseSonderurlaubArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisSonderurlaubArtID}")]
    public SingleResult<EreignisseSonderurlaubArten> GetEreignisseSonderurlaubArten(int key)
    {
        var items = this.context.EreignisseSonderurlaubArtens.Where(i=>i.EreignisSonderurlaubArtID == key);
        this.OnEreignisseSonderurlaubArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnEreignisseSonderurlaubArtensGet(ref IQueryable<Models.DbSinDarEla.EreignisseSonderurlaubArten> items);

    partial void OnEreignisseSonderurlaubArtenDeleted(Models.DbSinDarEla.EreignisseSonderurlaubArten item);

    [HttpDelete("{EreignisSonderurlaubArtID}")]
    public IActionResult DeleteEreignisseSonderurlaubArten(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.EreignisseSonderurlaubArtens
                .Where(i => i.EreignisSonderurlaubArtID == key)
                .Include(i => i.Ereignisses)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnEreignisseSonderurlaubArtenDeleted(itemToDelete);
            this.context.EreignisseSonderurlaubArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseSonderurlaubArtenUpdated(Models.DbSinDarEla.EreignisseSonderurlaubArten item);

    [HttpPut("{EreignisSonderurlaubArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisseSonderurlaubArten(int key, [FromBody]Models.DbSinDarEla.EreignisseSonderurlaubArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.EreignisSonderurlaubArtID != key))
            {
                return BadRequest();
            }

            this.OnEreignisseSonderurlaubArtenUpdated(newItem);
            this.context.EreignisseSonderurlaubArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseSonderurlaubArtens.Where(i => i.EreignisSonderurlaubArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{EreignisSonderurlaubArtID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisseSonderurlaubArten(int key, [FromBody]Delta<Models.DbSinDarEla.EreignisseSonderurlaubArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.EreignisseSonderurlaubArtens.Where(i => i.EreignisSonderurlaubArtID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnEreignisseSonderurlaubArtenUpdated(itemToUpdate);
            this.context.EreignisseSonderurlaubArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseSonderurlaubArtens.Where(i => i.EreignisSonderurlaubArtID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseSonderurlaubArtenCreated(Models.DbSinDarEla.EreignisseSonderurlaubArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.EreignisseSonderurlaubArten item)
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

            this.OnEreignisseSonderurlaubArtenCreated(item);
            this.context.EreignisseSonderurlaubArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/EreignisseSonderurlaubArtens/{item.EreignisSonderurlaubArtID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
