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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseMitarbeiters")]
  [Route("mvc/odata/dbSinDarEla/VwBaseMitarbeiters")]
  public partial class VwBaseMitarbeitersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseMitarbeitersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseMitarbeiters
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseMitarbeiter> GetVwBaseMitarbeiters()
    {
      var items = this.context.VwBaseMitarbeiters.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseMitarbeiter>();
      this.OnVwBaseMitarbeitersRead(ref items);

      return items;
    }

    partial void OnVwBaseMitarbeitersRead(ref IQueryable<Models.DbSinDarEla.VwBaseMitarbeiter> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwBaseMitarbeiter> GetVwBaseMitarbeiter(string key)
    {
        var items = this.context.VwBaseMitarbeiters.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwBaseMitarbeitersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseMitarbeitersGet(ref IQueryable<Models.DbSinDarEla.VwBaseMitarbeiter> items);

  }
}
