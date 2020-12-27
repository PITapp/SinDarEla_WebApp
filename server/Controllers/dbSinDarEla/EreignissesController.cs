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

  [ODataRoutePrefix("odata/dbSinDarEla/Ereignisses")]
  [Route("mvc/odata/dbSinDarEla/Ereignisses")]
  public partial class EreignissesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public EreignissesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Ereignisses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Ereignisse> GetEreignisses()
    {
      var items = this.context.Ereignisses.AsQueryable<Models.DbSinDarEla.Ereignisse>();
      this.OnEreignissesRead(ref items);

      return items;
    }

    partial void OnEreignissesRead(ref IQueryable<Models.DbSinDarEla.Ereignisse> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisID}")]
    public SingleResult<Ereignisse> GetEreignisse(int key)
    {
        var items = this.context.Ereignisses.Where(i=>i.EreignisID == key);
        this.OnEreignissesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnEreignissesGet(ref IQueryable<Models.DbSinDarEla.Ereignisse> items);

    partial void OnEreignisseDeleted(Models.DbSinDarEla.Ereignisse item);

    [HttpDelete("{EreignisID}")]
    public IActionResult DeleteEreignisse(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Ereignisses
                .Where(i => i.EreignisID == key)
                .Include(i => i.EreignisseTeilnehmers)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnEreignisseDeleted(itemToDelete);
            this.context.Ereignisses.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseUpdated(Models.DbSinDarEla.Ereignisse item);

    [HttpPut("{EreignisID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutEreignisse(int key, [FromBody]Models.DbSinDarEla.Ereignisse newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.EreignisID != key))
            {
                return BadRequest();
            }

            this.OnEreignisseUpdated(newItem);
            this.context.Ereignisses.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Ereignisses.Where(i => i.EreignisID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,EreignisseArten,EreignisseSonderurlaubArten,Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{EreignisID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchEreignisse(int key, [FromBody]Delta<Models.DbSinDarEla.Ereignisse> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Ereignisses.Where(i => i.EreignisID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnEreignisseUpdated(itemToUpdate);
            this.context.Ereignisses.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Ereignisses.Where(i => i.EreignisID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,EreignisseArten,EreignisseSonderurlaubArten,Kunden,KundenLeistungArten");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnEreignisseCreated(Models.DbSinDarEla.Ereignisse item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Ereignisse item)
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

            this.OnEreignisseCreated(item);
            this.context.Ereignisses.Add(item);
            this.context.SaveChanges();

            var key = item.EreignisID;

            var itemToReturn = this.context.Ereignisses.Where(i => i.EreignisID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,EreignisseArten,EreignisseSonderurlaubArten,Kunden,KundenLeistungArten");

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
