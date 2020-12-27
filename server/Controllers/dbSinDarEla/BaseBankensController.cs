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

  [ODataRoutePrefix("odata/dbSinDarEla/BaseBankens")]
  [Route("mvc/odata/dbSinDarEla/BaseBankens")]
  public partial class BaseBankensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public BaseBankensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/BaseBankens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.BaseBanken> GetBaseBankens()
    {
      var items = this.context.BaseBankens.AsQueryable<Models.DbSinDarEla.BaseBanken>();
      this.OnBaseBankensRead(ref items);

      return items;
    }

    partial void OnBaseBankensRead(ref IQueryable<Models.DbSinDarEla.BaseBanken> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BankID}")]
    public SingleResult<BaseBanken> GetBaseBanken(int key)
    {
        var items = this.context.BaseBankens.Where(i=>i.BankID == key);
        this.OnBaseBankensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnBaseBankensGet(ref IQueryable<Models.DbSinDarEla.BaseBanken> items);

    partial void OnBaseBankenDeleted(Models.DbSinDarEla.BaseBanken item);

    [HttpDelete("{BankID}")]
    public IActionResult DeleteBaseBanken(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.BaseBankens
                .Where(i => i.BankID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnBaseBankenDeleted(itemToDelete);
            this.context.BaseBankens.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseBankenUpdated(Models.DbSinDarEla.BaseBanken item);

    [HttpPut("{BankID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutBaseBanken(int key, [FromBody]Models.DbSinDarEla.BaseBanken newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.BankID != key))
            {
                return BadRequest();
            }

            this.OnBaseBankenUpdated(newItem);
            this.context.BaseBankens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseBankens.Where(i => i.BankID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{BankID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchBaseBanken(int key, [FromBody]Delta<Models.DbSinDarEla.BaseBanken> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.BaseBankens.Where(i => i.BankID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnBaseBankenUpdated(itemToUpdate);
            this.context.BaseBankens.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.BaseBankens.Where(i => i.BankID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnBaseBankenCreated(Models.DbSinDarEla.BaseBanken item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.BaseBanken item)
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

            this.OnBaseBankenCreated(item);
            this.context.BaseBankens.Add(item);
            this.context.SaveChanges();

            var key = item.BankID;

            var itemToReturn = this.context.BaseBankens.Where(i => i.BankID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base");

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
