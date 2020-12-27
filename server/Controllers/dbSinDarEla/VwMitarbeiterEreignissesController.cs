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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterEreignisses")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterEreignisses")]
  public partial class VwMitarbeiterEreignissesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterEreignissesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterEreignisses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterEreignisse> GetVwMitarbeiterEreignisses()
    {
      var items = this.context.VwMitarbeiterEreignisses.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterEreignisse>();
      this.OnVwMitarbeiterEreignissesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterEreignissesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterEreignisse> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Start}")]
    public SingleResult<VwMitarbeiterEreignisse> GetVwMitarbeiterEreignisse(DateTime key)
    {
        var items = this.context.VwMitarbeiterEreignisses.AsNoTracking().Where(i=>i.Start == key);
        this.OnVwMitarbeiterEreignissesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterEreignissesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterEreignisse> items);

  }
}
