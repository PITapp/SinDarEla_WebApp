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

  [ODataRoutePrefix("odata/dbSinDarEla/Mitteilungens")]
  [Route("mvc/odata/dbSinDarEla/Mitteilungens")]
  public partial class MitteilungensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitteilungensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Mitteilungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Mitteilungen> GetMitteilungens()
    {
      var items = this.context.Mitteilungens.AsQueryable<Models.DbSinDarEla.Mitteilungen>();
      this.OnMitteilungensRead(ref items);

      return items;
    }

    partial void OnMitteilungensRead(ref IQueryable<Models.DbSinDarEla.Mitteilungen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitteilungID}")]
    public SingleResult<Mitteilungen> GetMitteilungen(int key)
    {
        var items = this.context.Mitteilungens.Where(i=>i.MitteilungID == key);
        this.OnMitteilungensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitteilungensGet(ref IQueryable<Models.DbSinDarEla.Mitteilungen> items);

    partial void OnMitteilungenDeleted(Models.DbSinDarEla.Mitteilungen item);

    [HttpDelete("{MitteilungID}")]
    public IActionResult DeleteMitteilungen(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Mitteilungens
                .Where(i => i.MitteilungID == key)
                .Include(i => i.MitteilungenVerteilers)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitteilungenDeleted(itemToDelete);
            this.context.Mitteilungens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitteilungenUpdated(Models.DbSinDarEla.Mitteilungen item);

    [HttpPut("{MitteilungID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitteilungen(int key, [FromBody]Models.DbSinDarEla.Mitteilungen newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitteilungID != key))
            {
                return BadRequest();
            }

            this.OnMitteilungenUpdated(newItem);
            this.context.Mitteilungens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Mitteilungens.Where(i => i.MitteilungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Dokumente");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitteilungID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitteilungen(int key, [FromBody]Delta<Models.DbSinDarEla.Mitteilungen> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Mitteilungens.Where(i => i.MitteilungID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitteilungenUpdated(itemToUpdate);
            this.context.Mitteilungens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Mitteilungens.Where(i => i.MitteilungID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,Dokumente");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitteilungenCreated(Models.DbSinDarEla.Mitteilungen item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Mitteilungen item)
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

            this.OnMitteilungenCreated(item);
            this.context.Mitteilungens.Add(item);
            this.context.SaveChanges();

            var key = item.MitteilungID;

            var itemToReturn = this.context.Mitteilungens.Where(i => i.MitteilungID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,Dokumente");

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
