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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenEreignisses")]
  [Route("mvc/odata/dbSinDarEla/VwKundenEreignisses")]
  public partial class VwKundenEreignissesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenEreignissesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenEreignisses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenEreignisse> GetVwKundenEreignisses()
    {
      var items = this.context.VwKundenEreignisses.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenEreignisse>();
      this.OnVwKundenEreignissesRead(ref items);

      return items;
    }

    partial void OnVwKundenEreignissesRead(ref IQueryable<Models.DbSinDarEla.VwKundenEreignisse> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Start}")]
    public SingleResult<VwKundenEreignisse> GetVwKundenEreignisse(DateTime key)
    {
        var items = this.context.VwKundenEreignisses.AsNoTracking().Where(i=>i.Start == key);
        this.OnVwKundenEreignissesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenEreignissesGet(ref IQueryable<Models.DbSinDarEla.VwKundenEreignisse> items);

  }
}
