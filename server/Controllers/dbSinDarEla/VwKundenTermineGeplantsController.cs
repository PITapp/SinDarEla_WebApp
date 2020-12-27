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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenTermineGeplants")]
  [Route("mvc/odata/dbSinDarEla/VwKundenTermineGeplants")]
  public partial class VwKundenTermineGeplantsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenTermineGeplantsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenTermineGeplants
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenTermineGeplant> GetVwKundenTermineGeplants()
    {
      var items = this.context.VwKundenTermineGeplants.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenTermineGeplant>();
      this.OnVwKundenTermineGeplantsRead(ref items);

      return items;
    }

    partial void OnVwKundenTermineGeplantsRead(ref IQueryable<Models.DbSinDarEla.VwKundenTermineGeplant> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwKundenTermineGeplant> GetVwKundenTermineGeplant(string key)
    {
        var items = this.context.VwKundenTermineGeplants.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwKundenTermineGeplantsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenTermineGeplantsGet(ref IQueryable<Models.DbSinDarEla.VwKundenTermineGeplant> items);

  }
}
