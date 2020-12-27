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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterStatusMitTextAlles")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterStatusMitTextAlles")]
  public partial class VwMitarbeiterStatusMitTextAllesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterStatusMitTextAllesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterStatusMitTextAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterStatusMitTextAlle> GetVwMitarbeiterStatusMitTextAlles()
    {
      var items = this.context.VwMitarbeiterStatusMitTextAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterStatusMitTextAlle>();
      this.OnVwMitarbeiterStatusMitTextAllesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterStatusMitTextAllesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterStatusMitTextAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterStatusID}")]
    public SingleResult<VwMitarbeiterStatusMitTextAlle> GetVwMitarbeiterStatusMitTextAlle(Int64 key)
    {
        var items = this.context.VwMitarbeiterStatusMitTextAlles.AsNoTracking().Where(i=>i.MitarbeiterStatusID == key);
        this.OnVwMitarbeiterStatusMitTextAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterStatusMitTextAllesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterStatusMitTextAlle> items);

  }
}
