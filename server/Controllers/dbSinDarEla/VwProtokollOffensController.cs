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

  [ODataRoutePrefix("odata/dbSinDarEla/VwProtokollOffens")]
  [Route("mvc/odata/dbSinDarEla/VwProtokollOffens")]
  public partial class VwProtokollOffensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwProtokollOffensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwProtokollOffens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwProtokollOffen> GetVwProtokollOffens()
    {
      var items = this.context.VwProtokollOffens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwProtokollOffen>();
      this.OnVwProtokollOffensRead(ref items);

      return items;
    }

    partial void OnVwProtokollOffensRead(ref IQueryable<Models.DbSinDarEla.VwProtokollOffen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwProtokollOffen> GetVwProtokollOffen(int key)
    {
        var items = this.context.VwProtokollOffens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwProtokollOffensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwProtokollOffensGet(ref IQueryable<Models.DbSinDarEla.VwProtokollOffen> items);

  }
}
