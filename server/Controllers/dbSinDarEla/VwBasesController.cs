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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBases")]
  [Route("mvc/odata/dbSinDarEla/VwBases")]
  public partial class VwBasesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBasesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBases
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBase> GetVwBases()
    {
      var items = this.context.VwBases.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBase>();
      this.OnVwBasesRead(ref items);

      return items;
    }

    partial void OnVwBasesRead(ref IQueryable<Models.DbSinDarEla.VwBase> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwBase> GetVwBase(string key)
    {
        var items = this.context.VwBases.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwBasesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBasesGet(ref IQueryable<Models.DbSinDarEla.VwBase> items);

  }
}
