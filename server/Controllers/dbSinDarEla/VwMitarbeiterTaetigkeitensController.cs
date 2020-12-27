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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterTaetigkeitens")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterTaetigkeitens")]
  public partial class VwMitarbeiterTaetigkeitensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterTaetigkeitensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterTaetigkeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> GetVwMitarbeiterTaetigkeitens()
    {
      var items = this.context.VwMitarbeiterTaetigkeitens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterTaetigkeiten>();
      this.OnVwMitarbeiterTaetigkeitensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterTaetigkeitensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<VwMitarbeiterTaetigkeiten> GetVwMitarbeiterTaetigkeiten(int key)
    {
        var items = this.context.VwMitarbeiterTaetigkeitens.AsNoTracking().Where(i=>i.MitarbeiterID == key);
        this.OnVwMitarbeiterTaetigkeitensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterTaetigkeitensGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTaetigkeiten> items);

  }
}
