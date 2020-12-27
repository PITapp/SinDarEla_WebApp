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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseGesamts")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseGesamts")]
  public partial class VwEreignisseGesamtsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseGesamtsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseGesamts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseGesamt> GetVwEreignisseGesamts()
    {
      var items = this.context.VwEreignisseGesamts.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseGesamt>();
      this.OnVwEreignisseGesamtsRead(ref items);

      return items;
    }

    partial void OnVwEreignisseGesamtsRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseGesamt> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseGesamt> GetVwEreignisseGesamt(string key)
    {
        var items = this.context.VwEreignisseGesamts.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseGesamtsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseGesamtsGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseGesamt> items);

  }
}
