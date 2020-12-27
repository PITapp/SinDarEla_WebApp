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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenAuswahlNeus")]
  [Route("mvc/odata/dbSinDarEla/VwKundenAuswahlNeus")]
  public partial class VwKundenAuswahlNeusController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenAuswahlNeusController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenAuswahlNeus
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenAuswahlNeu> GetVwKundenAuswahlNeus()
    {
      var items = this.context.VwKundenAuswahlNeus.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenAuswahlNeu>();
      this.OnVwKundenAuswahlNeusRead(ref items);

      return items;
    }

    partial void OnVwKundenAuswahlNeusRead(ref IQueryable<Models.DbSinDarEla.VwKundenAuswahlNeu> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwKundenAuswahlNeu> GetVwKundenAuswahlNeu(int key)
    {
        var items = this.context.VwKundenAuswahlNeus.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwKundenAuswahlNeusGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenAuswahlNeusGet(ref IQueryable<Models.DbSinDarEla.VwKundenAuswahlNeu> items);

  }
}
