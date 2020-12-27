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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterGeburtstages")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterGeburtstages")]
  public partial class VwMitarbeiterGeburtstagesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterGeburtstagesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterGeburtstages
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterGeburtstage> GetVwMitarbeiterGeburtstages()
    {
      var items = this.context.VwMitarbeiterGeburtstages.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterGeburtstage>();
      this.OnVwMitarbeiterGeburtstagesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterGeburtstagesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterGeburtstage> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterGeburtstage> GetVwMitarbeiterGeburtstage(int key)
    {
        var items = this.context.VwMitarbeiterGeburtstages.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterGeburtstagesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterGeburtstagesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterGeburtstage> items);

  }
}
