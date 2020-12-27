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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseArtenManagements")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseArtenManagements")]
  public partial class VwEreignisseArtenManagementsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseArtenManagementsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseArtenManagements
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseArtenManagement> GetVwEreignisseArtenManagements()
    {
      var items = this.context.VwEreignisseArtenManagements.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseArtenManagement>();
      this.OnVwEreignisseArtenManagementsRead(ref items);

      return items;
    }

    partial void OnVwEreignisseArtenManagementsRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseArtenManagement> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseArtenManagement> GetVwEreignisseArtenManagement(string key)
    {
        var items = this.context.VwEreignisseArtenManagements.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseArtenManagementsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseArtenManagementsGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseArtenManagement> items);

  }
}
