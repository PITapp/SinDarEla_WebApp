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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterFuerAuswahlMitTextAlles")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterFuerAuswahlMitTextAlles")]
  public partial class VwMitarbeiterFuerAuswahlMitTextAllesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterFuerAuswahlMitTextAllesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterFuerAuswahlMitTextAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle> GetVwMitarbeiterFuerAuswahlMitTextAlles()
    {
      var items = this.context.VwMitarbeiterFuerAuswahlMitTextAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle>();
      this.OnVwMitarbeiterFuerAuswahlMitTextAllesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterFuerAuswahlMitTextAllesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<VwMitarbeiterFuerAuswahlMitTextAlle> GetVwMitarbeiterFuerAuswahlMitTextAlle(Int64 key)
    {
        var items = this.context.VwMitarbeiterFuerAuswahlMitTextAlles.AsNoTracking().Where(i=>i.MitarbeiterID == key);
        this.OnVwMitarbeiterFuerAuswahlMitTextAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterFuerAuswahlMitTextAllesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFuerAuswahlMitTextAlle> items);

  }
}
