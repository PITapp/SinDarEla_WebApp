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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBenutzerModules")]
  [Route("mvc/odata/dbSinDarEla/VwBenutzerModules")]
  public partial class VwBenutzerModulesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBenutzerModulesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBenutzerModules
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBenutzerModule> GetVwBenutzerModules()
    {
      var items = this.context.VwBenutzerModules.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBenutzerModule>();
      this.OnVwBenutzerModulesRead(ref items);

      return items;
    }

    partial void OnVwBenutzerModulesRead(ref IQueryable<Models.DbSinDarEla.VwBenutzerModule> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwBenutzerModule> GetVwBenutzerModule(int key)
    {
        var items = this.context.VwBenutzerModules.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwBenutzerModulesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBenutzerModulesGet(ref IQueryable<Models.DbSinDarEla.VwBenutzerModule> items);

  }
}
