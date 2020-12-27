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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterKundenAnzahlBbs")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterKundenAnzahlBbs")]
  public partial class VwMitarbeiterKundenAnzahlBbsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterKundenAnzahlBbsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterKundenAnzahlBbs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterKundenAnzahlBb> GetVwMitarbeiterKundenAnzahlBbs()
    {
      var items = this.context.VwMitarbeiterKundenAnzahlBbs.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterKundenAnzahlBb>();
      this.OnVwMitarbeiterKundenAnzahlBbsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterKundenAnzahlBbsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenAnzahlBb> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterKundenAnzahlBb> GetVwMitarbeiterKundenAnzahlBb(int key)
    {
        var items = this.context.VwMitarbeiterKundenAnzahlBbs.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterKundenAnzahlBbsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterKundenAnzahlBbsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenAnzahlBb> items);

  }
}
