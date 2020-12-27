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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterMitTextAlles")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterMitTextAlles")]
  public partial class VwMitarbeiterMitTextAllesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterMitTextAllesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterMitTextAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterMitTextAlle> GetVwMitarbeiterMitTextAlles()
    {
      var items = this.context.VwMitarbeiterMitTextAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterMitTextAlle>();
      this.OnVwMitarbeiterMitTextAllesRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterMitTextAllesRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterMitTextAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<VwMitarbeiterMitTextAlle> GetVwMitarbeiterMitTextAlle(Int64 key)
    {
        var items = this.context.VwMitarbeiterMitTextAlles.AsNoTracking().Where(i=>i.MitarbeiterID == key);
        this.OnVwMitarbeiterMitTextAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterMitTextAllesGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterMitTextAlle> items);

  }
}
