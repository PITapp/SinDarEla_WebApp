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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenUndBetreuerUndLeistungenAuswahls")]
  [Route("mvc/odata/dbSinDarEla/VwKundenUndBetreuerUndLeistungenAuswahls")]
  public partial class VwKundenUndBetreuerUndLeistungenAuswahlsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenUndBetreuerUndLeistungenAuswahlsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenUndBetreuerUndLeistungenAuswahls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenUndBetreuerUndLeistungenAuswahl> GetVwKundenUndBetreuerUndLeistungenAuswahls()
    {
      var items = this.context.VwKundenUndBetreuerUndLeistungenAuswahls.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenUndBetreuerUndLeistungenAuswahl>();
      this.OnVwKundenUndBetreuerUndLeistungenAuswahlsRead(ref items);

      return items;
    }

    partial void OnVwKundenUndBetreuerUndLeistungenAuswahlsRead(ref IQueryable<Models.DbSinDarEla.VwKundenUndBetreuerUndLeistungenAuswahl> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundeBaseID}")]
    public SingleResult<VwKundenUndBetreuerUndLeistungenAuswahl> GetVwKundenUndBetreuerUndLeistungenAuswahl(int key)
    {
        var items = this.context.VwKundenUndBetreuerUndLeistungenAuswahls.AsNoTracking().Where(i=>i.KundeBaseID == key);
        this.OnVwKundenUndBetreuerUndLeistungenAuswahlsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenUndBetreuerUndLeistungenAuswahlsGet(ref IQueryable<Models.DbSinDarEla.VwKundenUndBetreuerUndLeistungenAuswahl> items);

  }
}
