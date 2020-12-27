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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenLeistungenBescheides")]
  [Route("mvc/odata/dbSinDarEla/VwKundenLeistungenBescheides")]
  public partial class VwKundenLeistungenBescheidesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenLeistungenBescheidesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenLeistungenBescheides
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenLeistungenBescheide> GetVwKundenLeistungenBescheides()
    {
      var items = this.context.VwKundenLeistungenBescheides.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenLeistungenBescheide>();
      this.OnVwKundenLeistungenBescheidesRead(ref items);

      return items;
    }

    partial void OnVwKundenLeistungenBescheidesRead(ref IQueryable<Models.DbSinDarEla.VwKundenLeistungenBescheide> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenID}")]
    public SingleResult<VwKundenLeistungenBescheide> GetVwKundenLeistungenBescheide(int key)
    {
        var items = this.context.VwKundenLeistungenBescheides.AsNoTracking().Where(i=>i.KundenID == key);
        this.OnVwKundenLeistungenBescheidesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenLeistungenBescheidesGet(ref IQueryable<Models.DbSinDarEla.VwKundenLeistungenBescheide> items);

  }
}
