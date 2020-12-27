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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenTermineZusammenfassungs")]
  [Route("mvc/odata/dbSinDarEla/VwKundenTermineZusammenfassungs")]
  public partial class VwKundenTermineZusammenfassungsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenTermineZusammenfassungsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenTermineZusammenfassungs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenTermineZusammenfassung> GetVwKundenTermineZusammenfassungs()
    {
      var items = this.context.VwKundenTermineZusammenfassungs.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenTermineZusammenfassung>();
      this.OnVwKundenTermineZusammenfassungsRead(ref items);

      return items;
    }

    partial void OnVwKundenTermineZusammenfassungsRead(ref IQueryable<Models.DbSinDarEla.VwKundenTermineZusammenfassung> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenID}")]
    public SingleResult<VwKundenTermineZusammenfassung> GetVwKundenTermineZusammenfassung(int? key)
    {
        var items = this.context.VwKundenTermineZusammenfassungs.AsNoTracking().Where(i=>i.KundenID == key);
        this.OnVwKundenTermineZusammenfassungsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenTermineZusammenfassungsGet(ref IQueryable<Models.DbSinDarEla.VwKundenTermineZusammenfassung> items);

  }
}
