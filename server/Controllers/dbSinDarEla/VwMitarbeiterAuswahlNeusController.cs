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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterAuswahlNeus")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterAuswahlNeus")]
  public partial class VwMitarbeiterAuswahlNeusController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterAuswahlNeusController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterAuswahlNeus
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterAuswahlNeu> GetVwMitarbeiterAuswahlNeus()
    {
      var items = this.context.VwMitarbeiterAuswahlNeus.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlNeu>();
      this.OnVwMitarbeiterAuswahlNeusRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterAuswahlNeusRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlNeu> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterAuswahlNeu> GetVwMitarbeiterAuswahlNeu(int key)
    {
        var items = this.context.VwMitarbeiterAuswahlNeus.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterAuswahlNeusGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterAuswahlNeusGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlNeu> items);

  }
}
