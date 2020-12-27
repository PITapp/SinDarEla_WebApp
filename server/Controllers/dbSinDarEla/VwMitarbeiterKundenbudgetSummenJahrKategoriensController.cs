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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterKundenbudgetSummenJahrKategoriens")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterKundenbudgetSummenJahrKategoriens")]
  public partial class VwMitarbeiterKundenbudgetSummenJahrKategoriensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterKundenbudgetSummenJahrKategoriensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterKundenbudgetSummenJahrKategoriens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahrKategorien> GetVwMitarbeiterKundenbudgetSummenJahrKategoriens()
    {
      var items = this.context.VwMitarbeiterKundenbudgetSummenJahrKategoriens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahrKategorien>();
      this.OnVwMitarbeiterKundenbudgetSummenJahrKategoriensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterKundenbudgetSummenJahrKategoriensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahrKategorien> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<VwMitarbeiterKundenbudgetSummenJahrKategorien> GetVwMitarbeiterKundenbudgetSummenJahrKategorien(int key)
    {
        var items = this.context.VwMitarbeiterKundenbudgetSummenJahrKategoriens.AsNoTracking().Where(i=>i.MitarbeiterID == key);
        this.OnVwMitarbeiterKundenbudgetSummenJahrKategoriensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterKundenbudgetSummenJahrKategoriensGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterKundenbudgetSummenJahrKategorien> items);

  }
}
