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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseModulDienstplanListes")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseModulDienstplanListes")]
  public partial class VwEreignisseModulDienstplanListesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseModulDienstplanListesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseModulDienstplanListes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseModulDienstplanListe> GetVwEreignisseModulDienstplanListes()
    {
      var items = this.context.VwEreignisseModulDienstplanListes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseModulDienstplanListe>();
      this.OnVwEreignisseModulDienstplanListesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseModulDienstplanListesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulDienstplanListe> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseModulDienstplanListe> GetVwEreignisseModulDienstplanListe(string key)
    {
        var items = this.context.VwEreignisseModulDienstplanListes.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseModulDienstplanListesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseModulDienstplanListesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulDienstplanListe> items);

  }
}
