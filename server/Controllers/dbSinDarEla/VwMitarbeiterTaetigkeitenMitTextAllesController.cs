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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterTaetigkeitenMitTextAlles")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterTaetigkeitenMitTextAlles")]
  public partial class VwMitarbeiterTaetigkeitenMitTextAllesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterTaetigkeitenMitTextAllesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterTaetigkeitenMitTextAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterTaetigkeitenMitTextAlle> GetVwMitarbeiterTaetigkeitenMitTextAlles()
    {
      var items = this.context.VwMitarbeiterTaetigkeitenMitTextAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterTaetigkeitenMitTextAlle>();
      this.OnVwMitarbeiterTaetigkeitenMitTextAllesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterTaetigkeitenMitTextAllesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTaetigkeitenMitTextAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterTaetigkeitenArtID}")]
    public SingleResult<VwMitarbeiterTaetigkeitenMitTextAlle> GetVwMitarbeiterTaetigkeitenMitTextAlle(Int64 key)
    {
        var items = this.context.VwMitarbeiterTaetigkeitenMitTextAlles.AsNoTracking().Where(i=>i.MitarbeiterTaetigkeitenArtID == key);
        this.OnVwMitarbeiterTaetigkeitenMitTextAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterTaetigkeitenMitTextAllesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTaetigkeitenMitTextAlle> items);

  }
}
