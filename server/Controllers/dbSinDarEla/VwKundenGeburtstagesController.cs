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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenGeburtstages")]
  [Route("mvc/odata/dbSinDarEla/VwKundenGeburtstages")]
  public partial class VwKundenGeburtstagesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenGeburtstagesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenGeburtstages
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenGeburtstage> GetVwKundenGeburtstages()
    {
      var items = this.context.VwKundenGeburtstages.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenGeburtstage>();
      this.OnVwKundenGeburtstagesRead(ref items);

      return items;
    }

    partial void OnVwKundenGeburtstagesRead(ref IQueryable<Models.DbSinDarEla.VwKundenGeburtstage> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwKundenGeburtstage> GetVwKundenGeburtstage(int key)
    {
        var items = this.context.VwKundenGeburtstages.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwKundenGeburtstagesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenGeburtstagesGet(ref IQueryable<Models.DbSinDarEla.VwKundenGeburtstage> items);

  }
}
