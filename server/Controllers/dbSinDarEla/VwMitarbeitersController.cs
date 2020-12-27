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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiters")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiters")]
  public partial class VwMitarbeitersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeitersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiters
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiter> GetVwMitarbeiters()
    {
      var items = this.context.VwMitarbeiters.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiter>();
      this.OnVwMitarbeitersRead(ref items);

      return items;
    }

    partial void OnVwMitarbeitersRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiter> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiter> GetVwMitarbeiter(int key)
    {
        var items = this.context.VwMitarbeiters.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeitersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeitersGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiter> items);

  }
}
