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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseMitTeilnehmers")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseMitTeilnehmers")]
  public partial class VwEreignisseMitTeilnehmersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseMitTeilnehmersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseMitTeilnehmers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseMitTeilnehmer> GetVwEreignisseMitTeilnehmers()
    {
      var items = this.context.VwEreignisseMitTeilnehmers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseMitTeilnehmer>();
      this.OnVwEreignisseMitTeilnehmersRead(ref items);

      return items;
    }

    partial void OnVwEreignisseMitTeilnehmersRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseMitTeilnehmer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{start}")]
    public SingleResult<VwEreignisseMitTeilnehmer> GetVwEreignisseMitTeilnehmer(DateTime key)
    {
        var items = this.context.VwEreignisseMitTeilnehmers.AsNoTracking().Where(i=>i.start == key);
        this.OnVwEreignisseMitTeilnehmersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseMitTeilnehmersGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseMitTeilnehmer> items);

  }
}
