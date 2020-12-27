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

  [ODataRoutePrefix("odata/dbSinDarEla/BaseKontaktes")]
  [Route("mvc/odata/dbSinDarEla/BaseKontaktes")]
  public partial class BaseKontaktesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public BaseKontaktesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BaseKontaktes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BaseKontakte> GetBaseKontaktes()
    {
      var items = this.context.BaseKontaktes.AsQueryable<Models.DbSinDarEla.BaseKontakte>();
      this.OnBaseKontaktesRead(ref items);

      return items;
    }

    partial void OnBaseKontaktesRead(ref IQueryable<Models.DbSinDarEla.BaseKontakte> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KontaktID}")]
    public SingleResult<BaseKontakte> GetBaseKontakte(int key)
    {
        var items = this.context.BaseKontaktes.Where(i=>i.KontaktID == key);
        this.OnBaseKontaktesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBaseKontaktesGet(ref IQueryable<Models.DbSinDarEla.BaseKontakte> items);

    partial void OnBaseKontakteDeleted(Models.DbSinDarEla.BaseKontakte item);

    [HttpDelete("{KontaktID}")]
    public IActionResult DeleteBaseKontakte(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.BaseKontaktes
                .Where(i => i.KontaktID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBaseKontakteDeleted(itemToDelete);
            this.context.BaseKontaktes.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseKontakteUpdated(Models.DbSinDarEla.BaseKontakte item);

    [HttpPut("{KontaktID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBaseKontakte(int key, [FromBody]Models.DbSinDarEla.BaseKontakte newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.KontaktID != key))
            {
                return BadRequest();
            }

            this.OnBaseKontakteUpdated(newItem);
            this.context.BaseKontaktes.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,BaseAnreden");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{KontaktID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBaseKontakte(int key, [FromBody]Delta<Models.DbSinDarEla.BaseKontakte> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.BaseKontaktes.Where(i => i.KontaktID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBaseKontakteUpdated(itemToUpdate);
            this.context.BaseKontaktes.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,BaseAnreden");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseKontakteCreated(Models.DbSinDarEla.BaseKontakte item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BaseKontakte item)
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

            this.OnBaseKontakteCreated(item);
            this.context.BaseKontaktes.Add(item);
            this.context.SaveChanges();

            var key = item.KontaktID;

            var itemToReturn = this.context.BaseKontaktes.Where(i => i.KontaktID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,BaseAnreden");

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
