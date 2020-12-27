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

  [ODataRoutePrefix("odata/dbSinDarEla/VwModuleAuswahlMitTextAlles")]
  [Route("mvc/odata/dbSinDarEla/VwModuleAuswahlMitTextAlles")]
  public partial class VwModuleAuswahlMitTextAllesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwModuleAuswahlMitTextAllesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwModuleAuswahlMitTextAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwModuleAuswahlMitTextAlle> GetVwModuleAuswahlMitTextAlles()
    {
      var items = this.context.VwModuleAuswahlMitTextAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwModuleAuswahlMitTextAlle>();
      this.OnVwModuleAuswahlMitTextAllesRead(ref items);

      return items;
    }

    partial void OnVwModuleAuswahlMitTextAllesRead(ref IQueryable<Models.DbSinDarEla.VwModuleAuswahlMitTextAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ModulID}")]
    public SingleResult<VwModuleAuswahlMitTextAlle> GetVwModuleAuswahlMitTextAlle(Int64 key)
    {
        var items = this.context.VwModuleAuswahlMitTextAlles.AsNoTracking().Where(i=>i.ModulID == key);
        this.OnVwModuleAuswahlMitTextAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwModuleAuswahlMitTextAllesGet(ref IQueryable<Models.DbSinDarEla.VwModuleAuswahlMitTextAlle> items);

  }
}
