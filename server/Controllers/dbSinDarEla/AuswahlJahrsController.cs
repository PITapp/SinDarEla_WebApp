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

  [ODataRoutePrefix("odata/dbSinDarEla/AuswahlJahrs")]
  [Route("mvc/odata/dbSinDarEla/AuswahlJahrs")]
  public partial class AuswahlJahrsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public AuswahlJahrsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/AuswahlJahrs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.AuswahlJahr> GetAuswahlJahrs()
    {
      var items = this.context.AuswahlJahrs.AsQueryable<Models.DbSinDarEla.AuswahlJahr>();
      this.OnAuswahlJahrsRead(ref items);

      return items;
    }

    partial void OnAuswahlJahrsRead(ref IQueryable<Models.DbSinDarEla.AuswahlJahr> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AuswahlJahrID}")]
    public SingleResult<AuswahlJahr> GetAuswahlJahr(int key)
    {
        var items = this.context.AuswahlJahrs.Where(i=>i.AuswahlJahrID == key);
        this.OnAuswahlJahrsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnAuswahlJahrsGet(ref IQueryable<Models.DbSinDarEla.AuswahlJahr> items);

    partial void OnAuswahlJahrDeleted(Models.DbSinDarEla.AuswahlJahr item);

    [HttpDelete("{AuswahlJahrID}")]
    public IActionResult DeleteAuswahlJahr(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.AuswahlJahrs
                .Where(i => i.AuswahlJahrID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnAuswahlJahrDeleted(itemToDelete);
            this.context.AuswahlJahrs.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAuswahlJahrUpdated(Models.DbSinDarEla.AuswahlJahr item);

    [HttpPut("{AuswahlJahrID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAuswahlJahr(int key, [FromBody]Models.DbSinDarEla.AuswahlJahr newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AuswahlJahrID != key))
            {
                return BadRequest();
            }

            this.OnAuswahlJahrUpdated(newItem);
            this.context.AuswahlJahrs.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AuswahlJahrs.Where(i => i.AuswahlJahrID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{AuswahlJahrID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAuswahlJahr(int key, [FromBody]Delta<Models.DbSinDarEla.AuswahlJahr> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.AuswahlJahrs.Where(i => i.AuswahlJahrID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnAuswahlJahrUpdated(itemToUpdate);
            this.context.AuswahlJahrs.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.AuswahlJahrs.Where(i => i.AuswahlJahrID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAuswahlJahrCreated(Models.DbSinDarEla.AuswahlJahr item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.AuswahlJahr item)
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

            this.OnAuswahlJahrCreated(item);
            this.context.AuswahlJahrs.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/AuswahlJahrs/{item.AuswahlJahrID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
