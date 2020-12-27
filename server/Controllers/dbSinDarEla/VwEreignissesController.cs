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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisses")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisses")]
  public partial class VwEreignissesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignissesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisse> GetVwEreignisses()
    {
      var items = this.context.VwEreignisses.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisse>();
      this.OnVwEreignissesRead(ref items);

      return items;
    }

    partial void OnVwEreignissesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisse> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwEreignisse> GetVwEreignisse(int key)
    {
        var items = this.context.VwEreignisses.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwEreignissesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignissesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisse> items);

  }
}
