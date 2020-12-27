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

  [ODataRoutePrefix("odata/dbSinDarEla/EreignisseArtens")]
  [Route("mvc/odata/dbSinDarEla/EreignisseArtens")]
  public partial class EreignisseArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public EreignisseArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/EreignisseArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.EreignisseArten> GetEreignisseArtens()
    {
      var items = this.context.EreignisseArtens.AsQueryable<Models.DbSinDarEla.EreignisseArten>();
      this.OnEreignisseArtensRead(ref items);

      return items;
    }

    partial void OnEreignisseArtensRead(ref IQueryable<Models.DbSinDarEla.EreignisseArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<EreignisseArten> GetEreignisseArten(string key)
    {
        var items = this.context.EreignisseArtens.Where(i=>i.EreignisArtCode == key);
        this.OnEreignisseArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnEreignisseArtensGet(ref IQueryable<Models.DbSinDarEla.EreignisseArten> items);

    partial void OnEreignisseArtenDeleted(Models.DbSinDarEla.EreignisseArten item);

    [HttpDelete("{EreignisArtCode}")]
    public IActionResult DeleteEreignisseArten(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.EreignisseArtens
                .Where(i => i.EreignisArtCode == key)
                .Include(i => i.Ereignisses)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnEreignisseArtenDeleted(itemToDelete);
            this.context.EreignisseArtens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseArtenUpdated(Models.DbSinDarEla.EreignisseArten item);

    [HttpPut("{EreignisArtCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisseArten(string key, [FromBody]Models.DbSinDarEla.EreignisseArten newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.EreignisArtCode != key))
            {
                return BadRequest();
            }

            this.OnEreignisseArtenUpdated(newItem);
            this.context.EreignisseArtens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseArtens.Where(i => i.EreignisArtCode == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{EreignisArtCode}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisseArten(string key, [FromBody]Delta<Models.DbSinDarEla.EreignisseArten> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.EreignisseArtens.Where(i => i.EreignisArtCode == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnEreignisseArtenUpdated(itemToUpdate);
            this.context.EreignisseArtens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.EreignisseArtens.Where(i => i.EreignisArtCode == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseArtenCreated(Models.DbSinDarEla.EreignisseArten item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.EreignisseArten item)
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

            this.OnEreignisseArtenCreated(item);
            this.context.EreignisseArtens.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/EreignisseArtens/{item.EreignisArtCode}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
