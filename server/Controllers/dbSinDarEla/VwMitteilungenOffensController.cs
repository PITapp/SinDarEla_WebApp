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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitteilungenOffens")]
  [Route("mvc/odata/dbSinDarEla/VwMitteilungenOffens")]
  public partial class VwMitteilungenOffensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitteilungenOffensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitteilungenOffens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitteilungenOffen> GetVwMitteilungenOffens()
    {
      var items = this.context.VwMitteilungenOffens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitteilungenOffen>();
      this.OnVwMitteilungenOffensRead(ref items);

      return items;
    }

    partial void OnVwMitteilungenOffensRead(ref IQueryable<Models.DbSinDarEla.VwMitteilungenOffen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitteilungenOffen> GetVwMitteilungenOffen(int key)
    {
        var items = this.context.VwMitteilungenOffens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitteilungenOffensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitteilungenOffensGet(ref IQueryable<Models.DbSinDarEla.VwMitteilungenOffen> items);

  }
}
