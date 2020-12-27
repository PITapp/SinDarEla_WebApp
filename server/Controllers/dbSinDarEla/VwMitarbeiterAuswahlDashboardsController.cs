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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterAuswahlDashboards")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterAuswahlDashboards")]
  public partial class VwMitarbeiterAuswahlDashboardsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterAuswahlDashboardsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterAuswahlDashboards
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterAuswahlDashboard> GetVwMitarbeiterAuswahlDashboards()
    {
      var items = this.context.VwMitarbeiterAuswahlDashboards.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlDashboard>();
      this.OnVwMitarbeiterAuswahlDashboardsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterAuswahlDashboardsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlDashboard> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ZustaendigBaseID}")]
    public SingleResult<VwMitarbeiterAuswahlDashboard> GetVwMitarbeiterAuswahlDashboard(int key)
    {
        var items = this.context.VwMitarbeiterAuswahlDashboards.AsNoTracking().Where(i=>i.ZustaendigBaseID == key);
        this.OnVwMitarbeiterAuswahlDashboardsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterAuswahlDashboardsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlDashboard> items);

  }
}
