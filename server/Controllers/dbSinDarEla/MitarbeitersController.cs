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

  [ODataRoutePrefix("odata/dbSinDarEla/Mitarbeiters")]
  [Route("mvc/odata/dbSinDarEla/Mitarbeiters")]
  public partial class MitarbeitersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public MitarbeitersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/Mitarbeiters
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.Mitarbeiter> GetMitarbeiters()
    {
      var items = this.context.Mitarbeiters.AsQueryable<Models.DbSinDarEla.Mitarbeiter>();
      this.OnMitarbeitersRead(ref items);

      return items;
    }

    partial void OnMitarbeitersRead(ref IQueryable<Models.DbSinDarEla.Mitarbeiter> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<Mitarbeiter> GetMitarbeiter(int key)
    {
        var items = this.context.Mitarbeiters.Where(i=>i.MitarbeiterID == key);
        this.OnMitarbeitersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnMitarbeitersGet(ref IQueryable<Models.DbSinDarEla.Mitarbeiter> items);

    partial void OnMitarbeiterDeleted(Models.DbSinDarEla.Mitarbeiter item);

    [HttpDelete("{MitarbeiterID}")]
    public IActionResult DeleteMitarbeiter(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var itemToDelete = this.context.Mitarbeiters
                .Where(i => i.MitarbeiterID == key)
                .Include(i => i.Dokumentes)
                .Include(i => i.MitarbeiterFortbildungens)
                .Include(i => i.MitarbeiterInfos)
                .Include(i => i.MitarbeiterKundenbudgets)
                .Include(i => i.MitarbeiterTaetigkeitens)
                .Include(i => i.MitarbeiterUrlaubs)
                .Include(i => i.MitarbeiterUrlaubKumuliertAnspruches)
                .Include(i => i.MitarbeiterUrlaubKumuliertDienstzeitens)
                .Include(i => i.MitarbeiterVerlaufDienstzeitens)
                .Include(i => i.MitarbeiterVerlaufGehalts)
                .Include(i => i.MitarbeiterVerlaufNormalarbeitszeits)
                .FirstOrDefault();

            if (itemToDelete == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            this.OnMitarbeiterDeleted(itemToDelete);
            this.context.Mitarbeiters.Remove(itemToDelete);
            this.context.SaveChanges();

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterUpdated(Models.DbSinDarEla.Mitarbeiter item);

    [HttpPut("{MitarbeiterID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutMitarbeiter(int key, [FromBody]Models.DbSinDarEla.Mitarbeiter newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newItem == null || (newItem.MitarbeiterID != key))
            {
                return BadRequest();
            }

            this.OnMitarbeiterUpdated(newItem);
            this.context.Mitarbeiters.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Mitarbeiters.Where(i => i.MitarbeiterID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,MitarbeiterArten,MitarbeiterStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("{MitarbeiterID}")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchMitarbeiter(int key, [FromBody]Delta<Models.DbSinDarEla.Mitarbeiter> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var itemToUpdate = this.context.Mitarbeiters.Where(i => i.MitarbeiterID == key).FirstOrDefault();

            if (itemToUpdate == null)
            {
                ModelState.AddModelError("", "Item no longer available");
                return BadRequest(ModelState);
            }

            patch.Patch(itemToUpdate);

            this.OnMitarbeiterUpdated(itemToUpdate);
            this.context.Mitarbeiters.Update(itemToUpdate);
            this.context.SaveChanges();

            var itemToReturn = this.context.Mitarbeiters.Where(i => i.MitarbeiterID == key);
            Request.QueryString = Request.QueryString.Add("$expand", "Base,MitarbeiterArten,MitarbeiterStatus");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnMitarbeiterCreated(Models.DbSinDarEla.Mitarbeiter item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.DbSinDarEla.Mitarbeiter item)
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

            this.OnMitarbeiterCreated(item);
            this.context.Mitarbeiters.Add(item);
            this.context.SaveChanges();

            var key = item.MitarbeiterID;

            var itemToReturn = this.context.Mitarbeiters.Where(i => i.MitarbeiterID == key);

            Request.QueryString = Request.QueryString.Add("$expand", "Base,MitarbeiterArten,MitarbeiterStatus");

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
