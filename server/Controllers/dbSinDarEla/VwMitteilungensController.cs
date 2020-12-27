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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitteilungens")]
  [Route("mvc/odata/dbSinDarEla/VwMitteilungens")]
  public partial class VwMitteilungensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitteilungensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitteilungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitteilungen> GetVwMitteilungens()
    {
      var items = this.context.VwMitteilungens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitteilungen>();
      this.OnVwMitteilungensRead(ref items);

      return items;
    }

    partial void OnVwMitteilungensRead(ref IQueryable<Models.DbSinDarEla.VwMitteilungen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitteilungen> GetVwMitteilungen(int key)
    {
        var items = this.context.VwMitteilungens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitteilungensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitteilungensGet(ref IQueryable<Models.DbSinDarEla.VwMitteilungen> items);

  }
}
