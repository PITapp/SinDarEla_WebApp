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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseArtenMitTextAlles")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseArtenMitTextAlles")]
  public partial class VwEreignisseArtenMitTextAllesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseArtenMitTextAllesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseArtenMitTextAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseArtenMitTextAlle> GetVwEreignisseArtenMitTextAlles()
    {
      var items = this.context.VwEreignisseArtenMitTextAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseArtenMitTextAlle>();
      this.OnVwEreignisseArtenMitTextAllesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseArtenMitTextAllesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseArtenMitTextAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseArtenMitTextAlle> GetVwEreignisseArtenMitTextAlle(string key)
    {
        var items = this.context.VwEreignisseArtenMitTextAlles.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseArtenMitTextAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseArtenMitTextAllesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseArtenMitTextAlle> items);

  }
}
