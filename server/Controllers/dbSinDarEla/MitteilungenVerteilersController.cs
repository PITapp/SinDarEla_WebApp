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

  [ODataRoutePrefix("odata/dbSinDarEla/MitteilungenVerteilers")]
  [Route("mvc/odata/dbSinDarEla/MitteilungenVerteilers")]
  public partial class MitteilungenVerteilersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitteilungenVerteilersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/MitteilungenVerteilers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.MitteilungenVerteiler> GetMitteilungenVerteilers()
    {
      var items = this.context.MitteilungenVerteilers.AsQueryable<Models.DbSinDarEla.MitteilungenVerteiler>();
      this.OnMitteilungenVerteilersRead(ref items);

      return items;
    }

    partial void OnMitteilungenVerteilersRead(ref IQueryable<Models.DbSinDarEla.MitteilungenVerteiler> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitteilungVerteilerID}")]
    public SingleResult<MitteilungenVerteiler> GetMitteilungenVerteiler(int key)
    {
        var items = this.context.MitteilungenVerteilers.Where(i=>i.MitteilungVerteilerID == key);
        this.OnMitteilungenVerteilersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitteilungenVerteilersGet(ref IQueryable<Models.DbSinDarEla.MitteilungenVerteiler> items);

    partial void OnMitteilungenVerteilerDeleted(Models.DbSinDarEla.MitteilungenVerteiler item);

    [HttpDelete("{MitteilungVerteilerID}")]
    public IActionResult DeleteMitteilungenVerteiler(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.MitteilungenVerteilers
                .Where(i => i.MitteilungVerteilerID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitteilungenVerteilerDeleted(itemToDelete);
            this.context.MitteilungenVerteilers.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitteilungenVerteilerUpdated(Models.DbSinDarEla.MitteilungenVerteiler item);

    [HttpPut("{MitteilungVerteilerID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitteilungenVerteiler(int key, [FromBody]Models.DbSinDarEla.MitteilungenVerteiler newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitteilungVerteilerID != key))
            {
                return BadRequest();
            }

            this.OnMitteilungenVerteilerUpdated(newItem);
            this.context.MitteilungenVerteilers.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitteilungenVerteilers.Where(i => i.MitteilungVerteilerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitteilungen,Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitteilungVerteilerID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitteilungenVerteiler(int key, [FromBody]Delta<Models.DbSinDarEla.MitteilungenVerteiler> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.MitteilungenVerteilers.Where(i => i.MitteilungVerteilerID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitteilungenVerteilerUpdated(itemToUpdate);
            this.context.MitteilungenVerteilers.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.MitteilungenVerteilers.Where(i => i.MitteilungVerteilerID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Mitteilungen,Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitteilungenVerteilerCreated(Models.DbSinDarEla.MitteilungenVerteiler item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.MitteilungenVerteiler item)
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

            this.OnMitteilungenVerteilerCreated(item);
            this.context.MitteilungenVerteilers.Add(item);
            this.context.SaveChanges();

            var key = item.MitteilungVerteilerID;

            var itemToReturn = this.context.MitteilungenVerteilers.Where(i => i.MitteilungVerteilerID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Mitteilungen,Base");

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
