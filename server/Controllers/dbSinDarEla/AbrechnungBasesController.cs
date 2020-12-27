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

  [ODataRoutePrefix("odata/dbSinDarEla/AbrechnungBases")]
  [Route("mvc/odata/dbSinDarEla/AbrechnungBases")]
  public partial class AbrechnungBasesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public AbrechnungBasesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/AbrechnungBases
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.AbrechnungBasis> GetAbrechnungBases()
    {
      var items = this.context.AbrechnungBases.AsQueryable<Models.DbSinDarEla.AbrechnungBasis>();
      this.OnAbrechnungBasesRead(ref items);

      return items;
    }

    partial void OnAbrechnungBasesRead(ref IQueryable<Models.DbSinDarEla.AbrechnungBasis> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AbrechnungBasisID}")]
    public SingleResult<AbrechnungBasis> GetAbrechnungBasis(int key)
    {
        var items = this.context.AbrechnungBases.Where(i=>i.AbrechnungBasisID == key);
        this.OnAbrechnungBasesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnAbrechnungBasesGet(ref IQueryable<Models.DbSinDarEla.AbrechnungBasis> items);

    partial void OnAbrechnungBasisDeleted(Models.DbSinDarEla.AbrechnungBasis item);

    [HttpDelete("{AbrechnungBasisID}")]
    public IActionResult DeleteAbrechnungBasis(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.AbrechnungBases
                .Where(i => i.AbrechnungBasisID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnAbrechnungBasisDeleted(itemToDelete);
            this.context.AbrechnungBases.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAbrechnungBasisUpdated(Models.DbSinDarEla.AbrechnungBasis item);

    [HttpPut("{AbrechnungBasisID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAbrechnungBasis(int key, [FromBody]Models.DbSinDarEla.AbrechnungBasis newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.AbrechnungBasisID != key))
            {
                return BadRequest();
            }

            this.OnAbrechnungBasisUpdated(newItem);
            this.context.AbrechnungBases.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AbrechnungBases.Where(i => i.AbrechnungBasisID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{AbrechnungBasisID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAbrechnungBasis(int key, [FromBody]Delta<Models.DbSinDarEla.AbrechnungBasis> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.AbrechnungBases.Where(i => i.AbrechnungBasisID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnAbrechnungBasisUpdated(itemToUpdate);
            this.context.AbrechnungBases.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.AbrechnungBases.Where(i => i.AbrechnungBasisID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAbrechnungBasisCreated(Models.DbSinDarEla.AbrechnungBasis item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.AbrechnungBasis item)
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

            this.OnAbrechnungBasisCreated(item);
            this.context.AbrechnungBases.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/AbrechnungBases/{item.AbrechnungBasisID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
