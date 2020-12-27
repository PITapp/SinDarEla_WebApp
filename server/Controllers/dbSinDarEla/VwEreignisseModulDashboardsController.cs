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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseModulDashboards")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseModulDashboards")]
  public partial class VwEreignisseModulDashboardsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseModulDashboardsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseModulDashboards
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseModulDashboard> GetVwEreignisseModulDashboards()
    {
      var items = this.context.VwEreignisseModulDashboards.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseModulDashboard>();
      this.OnVwEreignisseModulDashboardsRead(ref items);

      return items;
    }

    partial void OnVwEreignisseModulDashboardsRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulDashboard> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseModulDashboard> GetVwEreignisseModulDashboard(string key)
    {
        var items = this.context.VwEreignisseModulDashboards.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseModulDashboardsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseModulDashboardsGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulDashboard> items);

  }
}
