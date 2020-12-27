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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseKundens")]
  [Route("mvc/odata/dbSinDarEla/VwBaseKundens")]
  public partial class VwBaseKundensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseKundensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseKundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseKunden> GetVwBaseKundens()
    {
      var items = this.context.VwBaseKundens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseKunden>();
      this.OnVwBaseKundensRead(ref items);

      return items;
    }

    partial void OnVwBaseKundensRead(ref IQueryable<Models.DbSinDarEla.VwBaseKunden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwBaseKunden> GetVwBaseKunden(string key)
    {
        var items = this.context.VwBaseKundens.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwBaseKundensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseKundensGet(ref IQueryable<Models.DbSinDarEla.VwBaseKunden> items);

  }
}
