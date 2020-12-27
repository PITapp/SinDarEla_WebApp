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

  [ODataRoutePrefix("odata/dbSinDarEla/Versionskontrolles")]
  [Route("mvc/odata/dbSinDarEla/Versionskontrolles")]
  public partial class VersionskontrollesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VersionskontrollesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Versionskontrolles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Versionskontrolle> GetVersionskontrolles()
    {
      var items = this.context.Versionskontrolles.AsQueryable<Models.DbSinDarEla.Versionskontrolle>();
      this.OnVersionskontrollesRead(ref items);

      return items;
    }

    partial void OnVersionskontrollesRead(ref IQueryable<Models.DbSinDarEla.Versionskontrolle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{VersionskontrolleID}")]
    public SingleResult<Versionskontrolle> GetVersionskontrolle(int key)
    {
        var items = this.context.Versionskontrolles.Where(i=>i.VersionskontrolleID == key);
        this.OnVersionskontrollesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVersionskontrollesGet(ref IQueryable<Models.DbSinDarEla.Versionskontrolle> items);

    partial void OnVersionskontrolleDeleted(Models.DbSinDarEla.Versionskontrolle item);

    [HttpDelete("{VersionskontrolleID}")]
    public IActionResult DeleteVersionskontrolle(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Versionskontrolles
                .Where(i => i.VersionskontrolleID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnVersionskontrolleDeleted(itemToDelete);
            this.context.Versionskontrolles.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnVersionskontrolleUpdated(Models.DbSinDarEla.Versionskontrolle item);

    [HttpPut("{VersionskontrolleID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutVersionskontrolle(int key, [FromBody]Models.DbSinDarEla.Versionskontrolle newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.VersionskontrolleID != key))
            {
                return BadRequest();
            }

            this.OnVersionskontrolleUpdated(newItem);
            this.context.Versionskontrolles.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Versionskontrolles.Where(i => i.VersionskontrolleID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{VersionskontrolleID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchVersionskontrolle(int key, [FromBody]Delta<Models.DbSinDarEla.Versionskontrolle> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Versionskontrolles.Where(i => i.VersionskontrolleID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnVersionskontrolleUpdated(itemToUpdate);
            this.context.Versionskontrolles.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Versionskontrolles.Where(i => i.VersionskontrolleID == key);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnVersionskontrolleCreated(Models.DbSinDarEla.Versionskontrolle item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Versionskontrolle item)
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

            this.OnVersionskontrolleCreated(item);
            this.context.Versionskontrolles.Add(item);
            this.context.SaveChanges();

            return Created($"odata/DbSinDarEla/Versionskontrolles/{item.VersionskontrolleID}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
