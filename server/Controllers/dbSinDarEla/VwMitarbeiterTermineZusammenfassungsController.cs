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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterTermineZusammenfassungs")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterTermineZusammenfassungs")]
  public partial class VwMitarbeiterTermineZusammenfassungsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterTermineZusammenfassungsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterTermineZusammenfassungs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterTermineZusammenfassung> GetVwMitarbeiterTermineZusammenfassungs()
    {
      var items = this.context.VwMitarbeiterTermineZusammenfassungs.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterTermineZusammenfassung>();
      this.OnVwMitarbeiterTermineZusammenfassungsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterTermineZusammenfassungsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTermineZusammenfassung> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterTermineZusammenfassung> GetVwMitarbeiterTermineZusammenfassung(int key)
    {
        var items = this.context.VwMitarbeiterTermineZusammenfassungs.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterTermineZusammenfassungsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterTermineZusammenfassungsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTermineZusammenfassung> items);

  }
}
