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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterKundenLeistungens")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterKundenLeistungens")]
  public partial class VwMitarbeiterKundenLeistungensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterKundenLeistungensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterKundenLeistungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterKundenLeistungen> GetVwMitarbeiterKundenLeistungens()
    {
      var items = this.context.VwMitarbeiterKundenLeistungens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterKundenLeistungen>();
      this.OnVwMitarbeiterKundenLeistungensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterKundenLeistungensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenLeistungen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterBaseID}")]
    public SingleResult<VwMitarbeiterKundenLeistungen> GetVwMitarbeiterKundenLeistungen(int key)
    {
        var items = this.context.VwMitarbeiterKundenLeistungens.AsNoTracking().Where(i=>i.MitarbeiterBaseID == key);
        this.OnVwMitarbeiterKundenLeistungensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterKundenLeistungensGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenLeistungen> items);

  }
}
