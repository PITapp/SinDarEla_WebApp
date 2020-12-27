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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenUndBetreuerAuswahls")]
  [Route("mvc/odata/dbSinDarEla/VwKundenUndBetreuerAuswahls")]
  public partial class VwKundenUndBetreuerAuswahlsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenUndBetreuerAuswahlsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenUndBetreuerAuswahls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenUndBetreuerAuswahl> GetVwKundenUndBetreuerAuswahls()
    {
      var items = this.context.VwKundenUndBetreuerAuswahls.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenUndBetreuerAuswahl>();
      this.OnVwKundenUndBetreuerAuswahlsRead(ref items);

      return items;
    }

    partial void OnVwKundenUndBetreuerAuswahlsRead(ref IQueryable<Models.DbSinDarEla.VwKundenUndBetreuerAuswahl> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundeBaseID}")]
    public SingleResult<VwKundenUndBetreuerAuswahl> GetVwKundenUndBetreuerAuswahl(int key)
    {
        var items = this.context.VwKundenUndBetreuerAuswahls.AsNoTracking().Where(i=>i.KundeBaseID == key);
        this.OnVwKundenUndBetreuerAuswahlsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenUndBetreuerAuswahlsGet(ref IQueryable<Models.DbSinDarEla.VwKundenUndBetreuerAuswahl> items);

  }
}
