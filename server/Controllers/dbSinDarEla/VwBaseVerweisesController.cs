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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseVerweises")]
  [Route("mvc/odata/dbSinDarEla/VwBaseVerweises")]
  public partial class VwBaseVerweisesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseVerweisesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseVerweises
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseVerweise> GetVwBaseVerweises()
    {
      var items = this.context.VwBaseVerweises.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseVerweise>();
      this.OnVwBaseVerweisesRead(ref items);

      return items;
    }

    partial void OnVwBaseVerweisesRead(ref IQueryable<Models.DbSinDarEla.VwBaseVerweise> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Ebene}")]
    public SingleResult<VwBaseVerweise> GetVwBaseVerweise(string key)
    {
        var items = this.context.VwBaseVerweises.AsNoTracking().Where(i=>i.Ebene == key);
        this.OnVwBaseVerweisesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseVerweisesGet(ref IQueryable<Models.DbSinDarEla.VwBaseVerweise> items);

  }
}
