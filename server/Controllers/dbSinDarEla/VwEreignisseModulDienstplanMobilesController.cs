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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseModulDienstplanMobiles")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseModulDienstplanMobiles")]
  public partial class VwEreignisseModulDienstplanMobilesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseModulDienstplanMobilesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseModulDienstplanMobiles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseModulDienstplanMobile> GetVwEreignisseModulDienstplanMobiles()
    {
      var items = this.context.VwEreignisseModulDienstplanMobiles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseModulDienstplanMobile>();
      this.OnVwEreignisseModulDienstplanMobilesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseModulDienstplanMobilesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulDienstplanMobile> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseModulDienstplanMobile> GetVwEreignisseModulDienstplanMobile(string key)
    {
        var items = this.context.VwEreignisseModulDienstplanMobiles.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseModulDienstplanMobilesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseModulDienstplanMobilesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulDienstplanMobile> items);

  }
}
