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

  [ODataRoutePrefix("odata/dbSinDarEla/VwGeburtstages")]
  [Route("mvc/odata/dbSinDarEla/VwGeburtstages")]
  public partial class VwGeburtstagesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwGeburtstagesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwGeburtstages
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwGeburtstage> GetVwGeburtstages()
    {
      var items = this.context.VwGeburtstages.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwGeburtstage>();
      this.OnVwGeburtstagesRead(ref items);

      return items;
    }

    partial void OnVwGeburtstagesRead(ref IQueryable<Models.DbSinDarEla.VwGeburtstage> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Name1}")]
    public SingleResult<VwGeburtstage> GetVwGeburtstage(string key)
    {
        var items = this.context.VwGeburtstages.AsNoTracking().Where(i=>i.Name1 == key);
        this.OnVwGeburtstagesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwGeburtstagesGet(ref IQueryable<Models.DbSinDarEla.VwGeburtstage> items);

  }
}
