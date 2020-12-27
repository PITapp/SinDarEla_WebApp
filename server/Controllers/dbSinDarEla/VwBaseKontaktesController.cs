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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseKontaktes")]
  [Route("mvc/odata/dbSinDarEla/VwBaseKontaktes")]
  public partial class VwBaseKontaktesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseKontaktesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseKontaktes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseKontakte> GetVwBaseKontaktes()
    {
      var items = this.context.VwBaseKontaktes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseKontakte>();
      this.OnVwBaseKontaktesRead(ref items);

      return items;
    }

    partial void OnVwBaseKontaktesRead(ref IQueryable<Models.DbSinDarEla.VwBaseKontakte> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwBaseKontakte> GetVwBaseKontakte(string key)
    {
        var items = this.context.VwBaseKontaktes.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwBaseKontaktesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseKontaktesGet(ref IQueryable<Models.DbSinDarEla.VwBaseKontakte> items);

  }
}
