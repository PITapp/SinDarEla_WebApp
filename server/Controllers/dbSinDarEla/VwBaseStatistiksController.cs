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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseStatistiks")]
  [Route("mvc/odata/dbSinDarEla/VwBaseStatistiks")]
  public partial class VwBaseStatistiksController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseStatistiksController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseStatistiks
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseStatistik> GetVwBaseStatistiks()
    {
      var items = this.context.VwBaseStatistiks.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseStatistik>();
      this.OnVwBaseStatistiksRead(ref items);

      return items;
    }

    partial void OnVwBaseStatistiksRead(ref IQueryable<Models.DbSinDarEla.VwBaseStatistik> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AnzahlBase}")]
    public SingleResult<VwBaseStatistik> GetVwBaseStatistik(Int64 key)
    {
        var items = this.context.VwBaseStatistiks.AsNoTracking().Where(i=>i.AnzahlBase == key);
        this.OnVwBaseStatistiksGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseStatistiksGet(ref IQueryable<Models.DbSinDarEla.VwBaseStatistik> items);

  }
}
