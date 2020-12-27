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

  [ODataRoutePrefix("odata/dbSinDarEla/AuswahlMonats")]
  [Route("mvc/odata/dbSinDarEla/AuswahlMonats")]
  public partial class AuswahlMonatsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public AuswahlMonatsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/AuswahlMonats
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.AuswahlMonat> GetAuswahlMonats()
    {
      var items = this.context.AuswahlMonats.AsQueryable<Models.DbSinDarEla.AuswahlMonat>();
      this.OnAuswahlMonatsRead(ref items);

      return items;
    }

    partial void OnAuswahlMonatsRead(ref IQueryable<Models.DbSinDarEla.AuswahlMonat> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AuswahlMonatID}")]
    public SingleResult<AuswahlMonat> GetAuswahlMonat(int key)
    {
        var items = this.context.AuswahlMonats.Where(i=>i.AuswahlMonatID == key);
        this.OnAuswahlMonatsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnAuswahlMonatsGet(ref IQueryable<Models.DbSinDarEla.AuswahlMonat> items);

    partial void OnAuswahlMonatDeleted(Models.DbSinDarEla.AuswahlMonat item);

    [HttpDelete("{AuswahlMonatID}")]
    public IActionResult DeleteAuswahlMonat(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.AuswahlMonats
                .Where(i => i.AuswahlMonatID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnAuswahlMonatDeleted(itemToDelete);
            this.context.AuswahlMonats.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAuswahlMonatUpdated(Models.DbSinDarEla.AuswahlMonat item);

    [HttpPut("{AuswahlMonatID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAuswahlMonat(int key, [FromBody]Models.DbSinDarEla.AuswahlMonat newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AuswahlMonatID != key))
            {
                return BadRequest();
            }

            this.OnAuswahlMonatUpdated(newItem);
            this.context.AuswahlMonats.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AuswahlMonats.Where(i => i.AuswahlMonatID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{AuswahlMonatID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAuswahlMonat(int key, [FromBody]Delta<Models.DbSinDarEla.AuswahlMonat> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.AuswahlMonats.Where(i => i.AuswahlMonatID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnAuswahlMonatUpdated(itemToUpdate);
            this.context.AuswahlMonats.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.AuswahlMonats.Where(i => i.AuswahlMonatID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAuswahlMonatCreated(Models.DbSinDarEla.AuswahlMonat item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.AuswahlMonat item)
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

            this.OnAuswahlMonatCreated(item);
            this.context.AuswahlMonats.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/AuswahlMonats/{item.AuswahlMonatID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
