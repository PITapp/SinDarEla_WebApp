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

  [ODataRoutePrefix("odata/dbSinDarEla/MitarbeiterFortbildungens")]
  [Route("mvc/odata/dbSinDarEla/MitarbeiterFortbildungens")]
  public partial class MitarbeiterFortbildungensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeiterFortbildungensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitarbeiterFortbildungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitarbeiterFortbildungen> GetMitarbeiterFortbildungens()
    {
      var items = this.context.MitarbeiterFortbildungens.AsQueryable<Models.DbSinDarEla.MitarbeiterFortbildungen>();
      this.OnMitarbeiterFortbildungensRead(ref items);

      return items;
    }

    partial void OnMitarbeiterFortbildungensRead(ref IQueryable<Models.DbSinDarEla.MitarbeiterFortbildungen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterFortbildungID}")]
    public SingleResult<MitarbeiterFortbildungen> GetMitarbeiterFortbildungen(int key)
    {
        var items = this.context.MitarbeiterFortbildungens.Where(i=>i.MitarbeiterFortbildungID == key);
        this.OnMitarbeiterFortbildungensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeiterFortbildungensGet(ref IQueryable<Models.DbSinDarEla.MitarbeiterFortbildungen> items);

    partial void OnMitarbeiterFortbildungenDeleted(Models.DbSinDarEla.MitarbeiterFortbildungen item);

    [HttpDelete("{MitarbeiterFortbildungID}")]
    public IActionResult DeleteMitarbeiterFortbildungen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitarbeiterFortbildungens
                .Where(i => i.MitarbeiterFortbildungID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterFortbildungenDeleted(itemToDelete);
            this.context.MitarbeiterFortbildungens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFortbildungenUpdated(Models.DbSinDarEla.MitarbeiterFortbildungen item);

    [HttpPut("{MitarbeiterFortbildungID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiterFortbildungen(int key, [FromBody]Models.DbSinDarEla.MitarbeiterFortbildungen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterFortbildungID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterFortbildungenUpdated(newItem);
            this.context.MitarbeiterFortbildungens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFortbildungens.Where(i => i.MitarbeiterFortbildungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Dokumente,Mitarbeiter,MitarbeiterFortbildungenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterFortbildungID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiterFortbildungen(int key, [FromBody]Delta<Models.DbSinDarEla.MitarbeiterFortbildungen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitarbeiterFortbildungens.Where(i => i.MitarbeiterFortbildungID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterFortbildungenUpdated(itemToUpdate);
            this.context.MitarbeiterFortbildungens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitarbeiterFortbildungens.Where(i => i.MitarbeiterFortbildungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Dokumente,Mitarbeiter,MitarbeiterFortbildungenArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterFortbildungenCreated(Models.DbSinDarEla.MitarbeiterFortbildungen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitarbeiterFortbildungen item)
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

            this.OnMitarbeiterFortbildungenCreated(item);
            this.context.MitarbeiterFortbildungens.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterFortbildungID;

            var itemToReturn = this.context.MitarbeiterFortbildungens.Where(i => i.MitarbeiterFortbildungID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Dokumente,Mitarbeiter,MitarbeiterFortbildungenArten");

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
