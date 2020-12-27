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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseArtenModules")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseArtenModules")]
  public partial class VwEreignisseArtenModulesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseArtenModulesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseArtenModules
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseArtenModule> GetVwEreignisseArtenModules()
    {
      var items = this.context.VwEreignisseArtenModules.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseArtenModule>();
      this.OnVwEreignisseArtenModulesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseArtenModulesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseArtenModule> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{NameModul}")]
    public SingleResult<VwEreignisseArtenModule> GetVwEreignisseArtenModule(string key)
    {
        var items = this.context.VwEreignisseArtenModules.AsNoTracking().Where(i=>i.NameModul == key);
        this.OnVwEreignisseArtenModulesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseArtenModulesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseArtenModule> items);

  }
}
