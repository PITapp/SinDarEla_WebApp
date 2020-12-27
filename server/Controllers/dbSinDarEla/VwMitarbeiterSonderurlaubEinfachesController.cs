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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterSonderurlaubEinfaches")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterSonderurlaubEinfaches")]
  public partial class VwMitarbeiterSonderurlaubEinfachesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterSonderurlaubEinfachesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterSonderurlaubEinfaches
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterSonderurlaubEinfach> GetVwMitarbeiterSonderurlaubEinfaches()
    {
      var items = this.context.VwMitarbeiterSonderurlaubEinfaches.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterSonderurlaubEinfach>();
      this.OnVwMitarbeiterSonderurlaubEinfachesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterSonderurlaubEinfachesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterSonderurlaubEinfach> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterSonderurlaubEinfach> GetVwMitarbeiterSonderurlaubEinfach(int key)
    {
        var items = this.context.VwMitarbeiterSonderurlaubEinfaches.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterSonderurlaubEinfachesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterSonderurlaubEinfachesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterSonderurlaubEinfach> items);

  }
}
