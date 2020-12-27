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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseTeilnehmerListes")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseTeilnehmerListes")]
  public partial class VwEreignisseTeilnehmerListesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseTeilnehmerListesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseTeilnehmerListes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseTeilnehmerListe> GetVwEreignisseTeilnehmerListes()
    {
      var items = this.context.VwEreignisseTeilnehmerListes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseTeilnehmerListe>();
      this.OnVwEreignisseTeilnehmerListesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseTeilnehmerListesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseTeilnehmerListe> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisID}")]
    public SingleResult<VwEreignisseTeilnehmerListe> GetVwEreignisseTeilnehmerListe(int key)
    {
        var items = this.context.VwEreignisseTeilnehmerListes.AsNoTracking().Where(i=>i.EreignisID == key);
        this.OnVwEreignisseTeilnehmerListesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseTeilnehmerListesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseTeilnehmerListe> items);

  }
}
