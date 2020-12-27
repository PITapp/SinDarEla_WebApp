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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseModulDashboardMobiles")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseModulDashboardMobiles")]
  public partial class VwEreignisseModulDashboardMobilesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseModulDashboardMobilesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseModulDashboardMobiles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseModulDashboardMobile> GetVwEreignisseModulDashboardMobiles()
    {
      var items = this.context.VwEreignisseModulDashboardMobiles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseModulDashboardMobile>();
      this.OnVwEreignisseModulDashboardMobilesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseModulDashboardMobilesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulDashboardMobile> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseModulDashboardMobile> GetVwEreignisseModulDashboardMobile(string key)
    {
        var items = this.context.VwEreignisseModulDashboardMobiles.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseModulDashboardMobilesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseModulDashboardMobilesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulDashboardMobile> items);

  }
}
