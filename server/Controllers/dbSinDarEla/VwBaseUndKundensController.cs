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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseUndKundens")]
  [Route("mvc/odata/dbSinDarEla/VwBaseUndKundens")]
  public partial class VwBaseUndKundensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseUndKundensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseUndKundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseUndKunden> GetVwBaseUndKundens()
    {
      var items = this.context.VwBaseUndKundens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseUndKunden>();
      this.OnVwBaseUndKundensRead(ref items);

      return items;
    }

    partial void OnVwBaseUndKundensRead(ref IQueryable<Models.DbSinDarEla.VwBaseUndKunden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwBaseUndKunden> GetVwBaseUndKunden(string key)
    {
        var items = this.context.VwBaseUndKundens.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwBaseUndKundensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseUndKundensGet(ref IQueryable<Models.DbSinDarEla.VwBaseUndKunden> items);

  }
}
