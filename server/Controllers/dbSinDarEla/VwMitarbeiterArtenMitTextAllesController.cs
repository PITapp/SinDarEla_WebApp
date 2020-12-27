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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterArtenMitTextAlles")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterArtenMitTextAlles")]
  public partial class VwMitarbeiterArtenMitTextAllesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterArtenMitTextAllesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterArtenMitTextAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterArtenMitTextAlle> GetVwMitarbeiterArtenMitTextAlles()
    {
      var items = this.context.VwMitarbeiterArtenMitTextAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterArtenMitTextAlle>();
      this.OnVwMitarbeiterArtenMitTextAllesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterArtenMitTextAllesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterArtenMitTextAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterArtID}")]
    public SingleResult<VwMitarbeiterArtenMitTextAlle> GetVwMitarbeiterArtenMitTextAlle(Int64 key)
    {
        var items = this.context.VwMitarbeiterArtenMitTextAlles.AsNoTracking().Where(i=>i.MitarbeiterArtID == key);
        this.OnVwMitarbeiterArtenMitTextAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterArtenMitTextAllesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterArtenMitTextAlle> items);

  }
}
