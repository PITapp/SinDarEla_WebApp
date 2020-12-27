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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterFilterListes")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterFilterListes")]
  public partial class VwMitarbeiterFilterListesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterFilterListesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterFilterListes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterFilterListe> GetVwMitarbeiterFilterListes()
    {
      var items = this.context.VwMitarbeiterFilterListes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterFilterListe>();
      this.OnVwMitarbeiterFilterListesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterFilterListesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFilterListe> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterFilterListe> GetVwMitarbeiterFilterListe(int key)
    {
        var items = this.context.VwMitarbeiterFilterListes.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterFilterListesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterFilterListesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFilterListe> items);

  }
}
