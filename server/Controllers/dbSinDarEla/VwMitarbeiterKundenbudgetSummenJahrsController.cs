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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterKundenbudgetSummenJahrs")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterKundenbudgetSummenJahrs")]
  public partial class VwMitarbeiterKundenbudgetSummenJahrsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterKundenbudgetSummenJahrsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterKundenbudgetSummenJahrs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahr> GetVwMitarbeiterKundenbudgetSummenJahrs()
    {
      var items = this.context.VwMitarbeiterKundenbudgetSummenJahrs.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahr>();
      this.OnVwMitarbeiterKundenbudgetSummenJahrsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterKundenbudgetSummenJahrsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahr> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<VwMitarbeiterKundenbudgetSummenJahr> GetVwMitarbeiterKundenbudgetSummenJahr(int key)
    {
        var items = this.context.VwMitarbeiterKundenbudgetSummenJahrs.AsNoTracking().Where(i=>i.MitarbeiterID == key);
        this.OnVwMitarbeiterKundenbudgetSummenJahrsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterKundenbudgetSummenJahrsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahr> items);

  }
}
