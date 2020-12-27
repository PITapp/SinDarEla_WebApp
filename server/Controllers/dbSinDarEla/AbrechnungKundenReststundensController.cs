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

  [ODataRoutePrefix("odata/dbSinDarEla/AbrechnungKundenReststundens")]
  [Route("mvc/odata/dbSinDarEla/AbrechnungKundenReststundens")]
  public partial class AbrechnungKundenReststundensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public AbrechnungKundenReststundensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/AbrechnungKundenReststundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.AbrechnungKundenReststunden> GetAbrechnungKundenReststundens()
    {
      var items = this.context.AbrechnungKundenReststundens.AsQueryable<Models.DbSinDarEla.AbrechnungKundenReststunden>();
      this.OnAbrechnungKundenReststundensRead(ref items);

      return items;
    }

    partial void OnAbrechnungKundenReststundensRead(ref IQueryable<Models.DbSinDarEla.AbrechnungKundenReststunden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AbrechnungKundenReststundenID}")]
    public SingleResult<AbrechnungKundenReststunden> GetAbrechnungKundenReststunden(int key)
    {
        var items = this.context.AbrechnungKundenReststundens.Where(i=>i.AbrechnungKundenReststundenID == key);
        this.OnAbrechnungKundenReststundensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnAbrechnungKundenReststundensGet(ref IQueryable<Models.DbSinDarEla.AbrechnungKundenReststunden> items);

    partial void OnAbrechnungKundenReststundenDeleted(Models.DbSinDarEla.AbrechnungKundenReststunden item);

    [HttpDelete("{AbrechnungKundenReststundenID}")]
    public IActionResult DeleteAbrechnungKundenReststunden(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.AbrechnungKundenReststundens
                .Where(i => i.AbrechnungKundenReststundenID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnAbrechnungKundenReststundenDeleted(itemToDelete);
            this.context.AbrechnungKundenReststundens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAbrechnungKundenReststundenUpdated(Models.DbSinDarEla.AbrechnungKundenReststunden item);

    [HttpPut("{AbrechnungKundenReststundenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAbrechnungKundenReststunden(int key, [FromBody]Models.DbSinDarEla.AbrechnungKundenReststunden newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AbrechnungKundenReststundenID != key))
            {
                return BadRequest();
            }

            this.OnAbrechnungKundenReststundenUpdated(newItem);
            this.context.AbrechnungKundenReststundens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AbrechnungKundenReststundens.Where(i => i.AbrechnungKundenReststundenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{AbrechnungKundenReststundenID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAbrechnungKundenReststunden(int key, [FromBody]Delta<Models.DbSinDarEla.AbrechnungKundenReststunden> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.AbrechnungKundenReststundens.Where(i => i.AbrechnungKundenReststundenID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnAbrechnungKundenReststundenUpdated(itemToUpdate);
            this.context.AbrechnungKundenReststundens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.AbrechnungKundenReststundens.Where(i => i.AbrechnungKundenReststundenID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAbrechnungKundenReststundenCreated(Models.DbSinDarEla.AbrechnungKundenReststunden item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.AbrechnungKundenReststunden item)
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

            this.OnAbrechnungKundenReststundenCreated(item);
            this.context.AbrechnungKundenReststundens.Add(item);
            this.context.SaveChanges();

            var key = item.AbrechnungKundenReststundenID;

            var itemToReturn = this.context.AbrechnungKundenReststundens.Where(i => i.AbrechnungKundenReststundenID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Kunden,KundenLeistungArten");

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
