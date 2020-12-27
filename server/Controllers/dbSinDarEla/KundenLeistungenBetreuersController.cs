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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenLeistungenBetreuers")]
  [Route("mvc/odata/dbSinDarEla/KundenLeistungenBetreuers")]
  public partial class KundenLeistungenBetreuersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenLeistungenBetreuersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBetreuers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBetreuer> GetKundenLeistungenBetreuers()
    {
      var items = this.context.KundenLeistungenBetreuers.AsQueryable<Models.DbSinDarEla.KundenLeistungenBetreuer>();
      this.OnKundenLeistungenBetreuersRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBetreuersRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBetreuer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungenBetreuerID}")]
    public SingleResult<KundenLeistungenBetreuer> GetKundenLeistungenBetreuer(int key)
    {
        var items = this.context.KundenLeistungenBetreuers.Where(i=>i.KundenLeistungenBetreuerID == key);
        this.OnKundenLeistungenBetreuersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenLeistungenBetreuersGet(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBetreuer> items);

    partial void OnKundenLeistungenBetreuerDeleted(Models.DbSinDarEla.KundenLeistungenBetreuer item);

    [HttpDelete("{KundenLeistungenBetreuerID}")]
    public IActionResult DeleteKundenLeistungenBetreuer(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenLeistungenBetreuers
                .Where(i => i.KundenLeistungenBetreuerID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenLeistungenBetreuerDeleted(itemToDelete);
            this.context.KundenLeistungenBetreuers.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBetreuerUpdated(Models.DbSinDarEla.KundenLeistungenBetreuer item);

    [HttpPut("{KundenLeistungenBetreuerID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBetreuer(int key, [FromBody]Models.DbSinDarEla.KundenLeistungenBetreuer newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungenBetreuerID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBetreuerUpdated(newItem);
            this.context.KundenLeistungenBetreuers.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBetreuers.Where(i => i.KundenLeistungenBetreuerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenLeistungenBetreuerArten,KundenLeistungen");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenLeistungenBetreuerID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBetreuer(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBetreuer> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenLeistungenBetreuers.Where(i => i.KundenLeistungenBetreuerID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenLeistungenBetreuerUpdated(itemToUpdate);
            this.context.KundenLeistungenBetreuers.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBetreuers.Where(i => i.KundenLeistungenBetreuerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenLeistungenBetreuerArten,KundenLeistungen");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBetreuerCreated(Models.DbSinDarEla.KundenLeistungenBetreuer item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBetreuer item)
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

            this.OnKundenLeistungenBetreuerCreated(item);
            this.context.KundenLeistungenBetreuers.Add(item);
            this.context.SaveChanges();

            var key = item.KundenLeistungenBetreuerID;

            var itemToReturn = this.context.KundenLeistungenBetreuers.Where(i => i.KundenLeistungenBetreuerID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,KundenLeistungenBetreuerArten,KundenLeistungen");

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
