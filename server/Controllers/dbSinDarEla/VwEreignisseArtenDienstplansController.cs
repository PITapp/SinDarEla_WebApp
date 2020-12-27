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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseArtenDienstplans")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseArtenDienstplans")]
  public partial class VwEreignisseArtenDienstplansController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseArtenDienstplansController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseArtenDienstplans
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseArtenDienstplan> GetVwEreignisseArtenDienstplans()
    {
      var items = this.context.VwEreignisseArtenDienstplans.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseArtenDienstplan>();
      this.OnVwEreignisseArtenDienstplansRead(ref items);

      return items;
    }

    partial void OnVwEreignisseArtenDienstplansRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseArtenDienstplan> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseArtenDienstplan> GetVwEreignisseArtenDienstplan(string key)
    {
        var items = this.context.VwEreignisseArtenDienstplans.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseArtenDienstplansGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseArtenDienstplansGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseArtenDienstplan> items);

  }
}
