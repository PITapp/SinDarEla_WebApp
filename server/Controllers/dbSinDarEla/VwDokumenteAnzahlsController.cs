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

  [ODataRoutePrefix("odata/dbSinDarEla/VwDokumenteAnzahls")]
  [Route("mvc/odata/dbSinDarEla/VwDokumenteAnzahls")]
  public partial class VwDokumenteAnzahlsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwDokumenteAnzahlsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwDokumenteAnzahls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwDokumenteAnzahl> GetVwDokumenteAnzahls()
    {
      var items = this.context.VwDokumenteAnzahls.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwDokumenteAnzahl>();
      this.OnVwDokumenteAnzahlsRead(ref items);

      return items;
    }

    partial void OnVwDokumenteAnzahlsRead(ref IQueryable<Models.DbSinDarEla.VwDokumenteAnzahl> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Kategorie}")]
    public SingleResult<VwDokumenteAnzahl> GetVwDokumenteAnzahl(string key)
    {
        var items = this.context.VwDokumenteAnzahls.AsNoTracking().Where(i=>i.Kategorie == key);
        this.OnVwDokumenteAnzahlsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwDokumenteAnzahlsGet(ref IQueryable<Models.DbSinDarEla.VwDokumenteAnzahl> items);

  }
}
