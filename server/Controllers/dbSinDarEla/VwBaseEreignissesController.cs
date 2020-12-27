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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseEreignisses")]
  [Route("mvc/odata/dbSinDarEla/VwBaseEreignisses")]
  public partial class VwBaseEreignissesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseEreignissesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseEreignisses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseEreignisse> GetVwBaseEreignisses()
    {
      var items = this.context.VwBaseEreignisses.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseEreignisse>();
      this.OnVwBaseEreignissesRead(ref items);

      return items;
    }

    partial void OnVwBaseEreignissesRead(ref IQueryable<Models.DbSinDarEla.VwBaseEreignisse> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwBaseEreignisse> GetVwBaseEreignisse(int key)
    {
        var items = this.context.VwBaseEreignisses.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwBaseEreignissesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseEreignissesGet(ref IQueryable<Models.DbSinDarEla.VwBaseEreignisse> items);

  }
}
