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

  [ODataRoutePrefix("odata/dbSinDarEla/Feedbacks")]
  [Route("mvc/odata/dbSinDarEla/Feedbacks")]
  public partial class FeedbacksController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public FeedbacksController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Feedbacks
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Feedback> GetFeedbacks()
    {
      var items = this.context.Feedbacks.AsQueryable<Models.DbSinDarEla.Feedback>();
      this.OnFeedbacksRead(ref items);

      return items;
    }

    partial void OnFeedbacksRead(ref IQueryable<Models.DbSinDarEla.Feedback> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{FeedbackID}")]
    public SingleResult<Feedback> GetFeedback(int key)
    {
        var items = this.context.Feedbacks.Where(i=>i.FeedbackID == key);
        this.OnFeedbacksGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnFeedbacksGet(ref IQueryable<Models.DbSinDarEla.Feedback> items);

    partial void OnFeedbackDeleted(Models.DbSinDarEla.Feedback item);

    [HttpDelete("{FeedbackID}")]
    public IActionResult DeleteFeedback(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Feedbacks
                .Where(i => i.FeedbackID == key)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnFeedbackDeleted(itemToDelete);
            this.context.Feedbacks.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFeedbackUpdated(Models.DbSinDarEla.Feedback item);

    [HttpPut("{FeedbackID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutFeedback(int key, [FromBody]Models.DbSinDarEla.Feedback newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.FeedbackID != key))
            {
                return BadRequest();
            }

            this.OnFeedbackUpdated(newItem);
            this.context.Feedbacks.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Feedbacks.Where(i => i.FeedbackID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{FeedbackID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchFeedback(int key, [FromBody]Delta<Models.DbSinDarEla.Feedback> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Feedbacks.Where(i => i.FeedbackID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnFeedbackUpdated(itemToUpdate);
            this.context.Feedbacks.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Feedbacks.Where(i => i.FeedbackID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnFeedbackCreated(Models.DbSinDarEla.Feedback item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Feedback item)
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

            this.OnFeedbackCreated(item);
            this.context.Feedbacks.Add(item);
            this.context.SaveChanges();

            var key = item.FeedbackID;

            var itemToReturn = this.context.Feedbacks.Where(i => i.FeedbackID == key);

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
