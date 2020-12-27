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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenProBetreuers")]
  [Route("mvc/odata/dbSinDarEla/VwKundenProBetreuers")]
  public partial class VwKundenProBetreuersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenProBetreuersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenProBetreuers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenProBetreuer> GetVwKundenProBetreuers()
    {
      var items = this.context.VwKundenProBetreuers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenProBetreuer>();
      this.OnVwKundenProBetreuersRead(ref items);

      return items;
    }

    partial void OnVwKundenProBetreuersRead(ref IQueryable<Models.DbSinDarEla.VwKundenProBetreuer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwKundenProBetreuer> GetVwKundenProBetreuer(int key)
    {
        var items = this.context.VwKundenProBetreuers.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwKundenProBetreuersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenProBetreuersGet(ref IQueryable<Models.DbSinDarEla.VwKundenProBetreuer> items);

  }
}
