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

  [ODataRoutePrefix("odata/dbSinDarEla/KundenLeistungenBescheideKontingentes")]
  [Route("mvc/odata/dbSinDarEla/KundenLeistungenBescheideKontingentes")]
  public partial class KundenLeistungenBescheideKontingentesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public KundenLeistungenBescheideKontingentesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/KundenLeistungenBescheideKontingentes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.KundenLeistungenBescheideKontingente> GetKundenLeistungenBescheideKontingentes()
    {
      var items = this.context.KundenLeistungenBescheideKontingentes.AsQueryable<Models.DbSinDarEla.KundenLeistungenBescheideKontingente>();
      this.OnKundenLeistungenBescheideKontingentesRead(ref items);

      return items;
    }

    partial void OnKundenLeistungenBescheideKontingentesRead(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBescheideKontingente> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungenBescheideKontingentID}")]
    public SingleResult<KundenLeistungenBescheideKontingente> GetKundenLeistungenBescheideKontingente(int key)
    {
        var items = this.context.KundenLeistungenBescheideKontingentes.Where(i=>i.KundenLeistungenBescheideKontingentID == key);
        this.OnKundenLeistungenBescheideKontingentesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnKundenLeistungenBescheideKontingentesGet(ref IQueryable<Models.DbSinDarEla.KundenLeistungenBescheideKontingente> items);

    partial void OnKundenLeistungenBescheideKontingenteDeleted(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);

    [HttpDelete("{KundenLeistungenBescheideKontingentID}")]
    public IActionResult DeleteKundenLeistungenBescheideKontingente(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.KundenLeistungenBescheideKontingentes
                .Where(i => i.KundenLeistungenBescheideKontingentID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnKundenLeistungenBescheideKontingenteDeleted(itemToDelete);
            this.context.KundenLeistungenBescheideKontingentes.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideKontingenteUpdated(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);

    [HttpPut("{KundenLeistungenBescheideKontingentID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKundenLeistungenBescheideKontingente(int key, [FromBody]Models.DbSinDarEla.KundenLeistungenBescheideKontingente newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KundenLeistungenBescheideKontingentID != key))
            {
                return BadRequest();
            }

            this.OnKundenLeistungenBescheideKontingenteUpdated(newItem);
            this.context.KundenLeistungenBescheideKontingentes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheideKontingentes.Where(i => i.KundenLeistungenBescheideKontingentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "KundenLeistungenBescheide");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KundenLeistungenBescheideKontingentID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKundenLeistungenBescheideKontingente(int key, [FromBody]Delta<Models.DbSinDarEla.KundenLeistungenBescheideKontingente> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.KundenLeistungenBescheideKontingentes.Where(i => i.KundenLeistungenBescheideKontingentID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnKundenLeistungenBescheideKontingenteUpdated(itemToUpdate);
            this.context.KundenLeistungenBescheideKontingentes.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.KundenLeistungenBescheideKontingentes.Where(i => i.KundenLeistungenBescheideKontingentID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "KundenLeistungenBescheide");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKundenLeistungenBescheideKontingenteCreated(Models.DbSinDarEla.KundenLeistungenBescheideKontingente item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.KundenLeistungenBescheideKontingente item)
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

            this.OnKundenLeistungenBescheideKontingenteCreated(item);
            this.context.KundenLeistungenBescheideKontingentes.Add(item);
            this.context.SaveChanges();

            var key = item.KundenLeistungenBescheideKontingentID;

            var itemToReturn = this.context.KundenLeistungenBescheideKontingentes.Where(i => i.KundenLeistungenBescheideKontingentID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "KundenLeistungenBescheide");

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
