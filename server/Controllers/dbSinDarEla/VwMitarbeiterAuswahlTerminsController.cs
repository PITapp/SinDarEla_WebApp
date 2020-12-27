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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterAuswahlTermins")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterAuswahlTermins")]
  public partial class VwMitarbeiterAuswahlTerminsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterAuswahlTerminsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterAuswahlTermins
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterAuswahlTermin> GetVwMitarbeiterAuswahlTermins()
    {
      var items = this.context.VwMitarbeiterAuswahlTermins.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlTermin>();
      this.OnVwMitarbeiterAuswahlTerminsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterAuswahlTerminsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlTermin> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterAuswahlTermin> GetVwMitarbeiterAuswahlTermin(int key)
    {
        var items = this.context.VwMitarbeiterAuswahlTermins.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterAuswahlTerminsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterAuswahlTerminsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterAuswahlTermin> items);

  }
}
