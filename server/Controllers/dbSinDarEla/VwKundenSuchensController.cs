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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenSuchens")]
  [Route("mvc/odata/dbSinDarEla/VwKundenSuchens")]
  public partial class VwKundenSuchensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenSuchensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenSuchens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenSuchen> GetVwKundenSuchens()
    {
      var items = this.context.VwKundenSuchens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenSuchen>();
      this.OnVwKundenSuchensRead(ref items);

      return items;
    }

    partial void OnVwKundenSuchensRead(ref IQueryable<Models.DbSinDarEla.VwKundenSuchen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwKundenSuchen> GetVwKundenSuchen(int key)
    {
        var items = this.context.VwKundenSuchens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwKundenSuchensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenSuchensGet(ref IQueryable<Models.DbSinDarEla.VwKundenSuchen> items);

  }
}
