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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterFortbildungenSummenJahrArtens")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterFortbildungenSummenJahrArtens")]
  public partial class VwMitarbeiterFortbildungenSummenJahrArtensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterFortbildungenSummenJahrArtensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterFortbildungenSummenJahrArtens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahrArten> GetVwMitarbeiterFortbildungenSummenJahrArtens()
    {
      var items = this.context.VwMitarbeiterFortbildungenSummenJahrArtens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahrArten>();
      this.OnVwMitarbeiterFortbildungenSummenJahrArtensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterFortbildungenSummenJahrArtensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahrArten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<VwMitarbeiterFortbildungenSummenJahrArten> GetVwMitarbeiterFortbildungenSummenJahrArten(int key)
    {
        var items = this.context.VwMitarbeiterFortbildungenSummenJahrArtens.AsNoTracking().Where(i=>i.MitarbeiterID == key);
        this.OnVwMitarbeiterFortbildungenSummenJahrArtensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterFortbildungenSummenJahrArtensGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFortbildungenSummenJahrArten> items);

  }
}
