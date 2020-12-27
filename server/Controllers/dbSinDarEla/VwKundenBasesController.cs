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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenBases")]
  [Route("mvc/odata/dbSinDarEla/VwKundenBases")]
  public partial class VwKundenBasesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenBasesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenBases
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenBase> GetVwKundenBases()
    {
      var items = this.context.VwKundenBases.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenBase>();
      this.OnVwKundenBasesRead(ref items);

      return items;
    }

    partial void OnVwKundenBasesRead(ref IQueryable<Models.DbSinDarEla.VwKundenBase> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwKundenBase> GetVwKundenBase(int key)
    {
        var items = this.context.VwKundenBases.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwKundenBasesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenBasesGet(ref IQueryable<Models.DbSinDarEla.VwKundenBase> items);

  }
}
