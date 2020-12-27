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

  [ODataRoutePrefix("odata/dbSinDarEla/VwDienstplanEreignisses")]
  [Route("mvc/odata/dbSinDarEla/VwDienstplanEreignisses")]
  public partial class VwDienstplanEreignissesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwDienstplanEreignissesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwDienstplanEreignisses
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwDienstplanEreignisse> GetVwDienstplanEreignisses()
    {
      var items = this.context.VwDienstplanEreignisses.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwDienstplanEreignisse>();
      this.OnVwDienstplanEreignissesRead(ref items);

      return items;
    }

    partial void OnVwDienstplanEreignissesRead(ref IQueryable<Models.DbSinDarEla.VwDienstplanEreignisse> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwDienstplanEreignisse> GetVwDienstplanEreignisse(string key)
    {
        var items = this.context.VwDienstplanEreignisses.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwDienstplanEreignissesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwDienstplanEreignissesGet(ref IQueryable<Models.DbSinDarEla.VwDienstplanEreignisse> items);

  }
}
