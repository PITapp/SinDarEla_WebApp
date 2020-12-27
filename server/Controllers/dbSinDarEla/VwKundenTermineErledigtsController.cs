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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenTermineErledigts")]
  [Route("mvc/odata/dbSinDarEla/VwKundenTermineErledigts")]
  public partial class VwKundenTermineErledigtsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenTermineErledigtsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenTermineErledigts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenTermineErledigt> GetVwKundenTermineErledigts()
    {
      var items = this.context.VwKundenTermineErledigts.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenTermineErledigt>();
      this.OnVwKundenTermineErledigtsRead(ref items);

      return items;
    }

    partial void OnVwKundenTermineErledigtsRead(ref IQueryable<Models.DbSinDarEla.VwKundenTermineErledigt> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwKundenTermineErledigt> GetVwKundenTermineErledigt(string key)
    {
        var items = this.context.VwKundenTermineErledigts.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwKundenTermineErledigtsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenTermineErledigtsGet(ref IQueryable<Models.DbSinDarEla.VwKundenTermineErledigt> items);

  }
}
