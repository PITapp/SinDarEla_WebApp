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

  [ODataRoutePrefix("odata/dbSinDarEla/VwDashboardTermineGeplants")]
  [Route("mvc/odata/dbSinDarEla/VwDashboardTermineGeplants")]
  public partial class VwDashboardTermineGeplantsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwDashboardTermineGeplantsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwDashboardTermineGeplants
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwDashboardTermineGeplant> GetVwDashboardTermineGeplants()
    {
      var items = this.context.VwDashboardTermineGeplants.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwDashboardTermineGeplant>();
      this.OnVwDashboardTermineGeplantsRead(ref items);

      return items;
    }

    partial void OnVwDashboardTermineGeplantsRead(ref IQueryable<Models.DbSinDarEla.VwDashboardTermineGeplant> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwDashboardTermineGeplant> GetVwDashboardTermineGeplant(string key)
    {
        var items = this.context.VwDashboardTermineGeplants.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwDashboardTermineGeplantsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwDashboardTermineGeplantsGet(ref IQueryable<Models.DbSinDarEla.VwDashboardTermineGeplant> items);

  }
}
