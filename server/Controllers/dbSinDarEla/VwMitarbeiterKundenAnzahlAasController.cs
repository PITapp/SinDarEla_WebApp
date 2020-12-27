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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterKundenAnzahlAas")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterKundenAnzahlAas")]
  public partial class VwMitarbeiterKundenAnzahlAasController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterKundenAnzahlAasController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterKundenAnzahlAas
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterKundenAnzahlAa> GetVwMitarbeiterKundenAnzahlAas()
    {
      var items = this.context.VwMitarbeiterKundenAnzahlAas.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterKundenAnzahlAa>();
      this.OnVwMitarbeiterKundenAnzahlAasRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterKundenAnzahlAasRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenAnzahlAa> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterKundenAnzahlAa> GetVwMitarbeiterKundenAnzahlAa(int key)
    {
        var items = this.context.VwMitarbeiterKundenAnzahlAas.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterKundenAnzahlAasGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterKundenAnzahlAasGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenAnzahlAa> items);

  }
}
