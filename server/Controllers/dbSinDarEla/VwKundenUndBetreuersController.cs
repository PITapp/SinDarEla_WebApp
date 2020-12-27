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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenUndBetreuers")]
  [Route("mvc/odata/dbSinDarEla/VwKundenUndBetreuers")]
  public partial class VwKundenUndBetreuersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenUndBetreuersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenUndBetreuers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenUndBetreuer> GetVwKundenUndBetreuers()
    {
      var items = this.context.VwKundenUndBetreuers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenUndBetreuer>();
      this.OnVwKundenUndBetreuersRead(ref items);

      return items;
    }

    partial void OnVwKundenUndBetreuersRead(ref IQueryable<Models.DbSinDarEla.VwKundenUndBetreuer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwKundenUndBetreuer> GetVwKundenUndBetreuer(int key)
    {
        var items = this.context.VwKundenUndBetreuers.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwKundenUndBetreuersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenUndBetreuersGet(ref IQueryable<Models.DbSinDarEla.VwKundenUndBetreuer> items);

  }
}
