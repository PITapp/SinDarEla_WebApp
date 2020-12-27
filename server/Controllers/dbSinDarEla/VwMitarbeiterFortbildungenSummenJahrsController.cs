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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterFortbildungenSummenJahrs")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterFortbildungenSummenJahrs")]
  public partial class VwMitarbeiterFortbildungenSummenJahrsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterFortbildungenSummenJahrsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterFortbildungenSummenJahrs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahr> GetVwMitarbeiterFortbildungenSummenJahrs()
    {
      var items = this.context.VwMitarbeiterFortbildungenSummenJahrs.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahr>();
      this.OnVwMitarbeiterFortbildungenSummenJahrsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterFortbildungenSummenJahrsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahr> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<VwMitarbeiterFortbildungenSummenJahr> GetVwMitarbeiterFortbildungenSummenJahr(int key)
    {
        var items = this.context.VwMitarbeiterFortbildungenSummenJahrs.AsNoTracking().Where(i=>i.MitarbeiterID == key);
        this.OnVwMitarbeiterFortbildungenSummenJahrsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterFortbildungenSummenJahrsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahr> items);

  }
}
