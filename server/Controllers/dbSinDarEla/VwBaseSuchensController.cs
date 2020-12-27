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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseSuchens")]
  [Route("mvc/odata/dbSinDarEla/VwBaseSuchens")]
  public partial class VwBaseSuchensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseSuchensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseSuchens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseSuchen> GetVwBaseSuchens()
    {
      var items = this.context.VwBaseSuchens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseSuchen>();
      this.OnVwBaseSuchensRead(ref items);

      return items;
    }

    partial void OnVwBaseSuchensRead(ref IQueryable<Models.DbSinDarEla.VwBaseSuchen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwBaseSuchen> GetVwBaseSuchen(int key)
    {
        var items = this.context.VwBaseSuchens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwBaseSuchensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseSuchensGet(ref IQueryable<Models.DbSinDarEla.VwBaseSuchen> items);

  }
}
