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

  [ODataRoutePrefix("odata/dbSinDarEla/TextbausteineHtmls")]
  [Route("mvc/odata/dbSinDarEla/TextbausteineHtmls")]
  public partial class TextbausteineHtmlsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public TextbausteineHtmlsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/TextbausteineHtmls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.TextbausteineHtml> GetTextbausteineHtmls()
    {
      var items = this.context.TextbausteineHtmls.AsQueryable<Models.DbSinDarEla.TextbausteineHtml>();
      this.OnTextbausteineHtmlsRead(ref items);

      return items;
    }

    partial void OnTextbausteineHtmlsRead(ref IQueryable<Models.DbSinDarEla.TextbausteineHtml> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{TextbausteinID}")]
    public SingleResult<TextbausteineHtml> GetTextbausteineHtml(int key)
    {
        var items = this.context.TextbausteineHtmls.Where(i=>i.TextbausteinID == key);
        this.OnTextbausteineHtmlsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnTextbausteineHtmlsGet(ref IQueryable<Models.DbSinDarEla.TextbausteineHtml> items);

    partial void OnTextbausteineHtmlDeleted(Models.DbSinDarEla.TextbausteineHtml item);

    [HttpDelete("{TextbausteinID}")]
    public IActionResult DeleteTextbausteineHtml(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.TextbausteineHtmls
                .Where(i => i.TextbausteinID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnTextbausteineHtmlDeleted(itemToDelete);
            this.context.TextbausteineHtmls.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnTextbausteineHtmlUpdated(Models.DbSinDarEla.TextbausteineHtml item);

    [HttpPut("{TextbausteinID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutTextbausteineHtml(int key, [FromBody]Models.DbSinDarEla.TextbausteineHtml newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.TextbausteinID != key))
            {
                return BadRequest();
            }

            this.OnTextbausteineHtmlUpdated(newItem);
            this.context.TextbausteineHtmls.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.TextbausteineHtmls.Where(i => i.TextbausteinID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{TextbausteinID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchTextbausteineHtml(int key, [FromBody]Delta<Models.DbSinDarEla.TextbausteineHtml> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.TextbausteineHtmls.Where(i => i.TextbausteinID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnTextbausteineHtmlUpdated(itemToUpdate);
            this.context.TextbausteineHtmls.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.TextbausteineHtmls.Where(i => i.TextbausteinID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnTextbausteineHtmlCreated(Models.DbSinDarEla.TextbausteineHtml item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.TextbausteineHtml item)
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

            this.OnTextbausteineHtmlCreated(item);
            this.context.TextbausteineHtmls.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/TextbausteineHtmls/{item.TextbausteinID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
