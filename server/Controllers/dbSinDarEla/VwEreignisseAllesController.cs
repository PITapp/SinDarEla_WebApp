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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseAlles")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseAlles")]
  public partial class VwEreignisseAllesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseAllesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseAlles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseAlle> GetVwEreignisseAlles()
    {
      var items = this.context.VwEreignisseAlles.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseAlle>();
      this.OnVwEreignisseAllesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseAllesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseAlle> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseAlle> GetVwEreignisseAlle(string key)
    {
        var items = this.context.VwEreignisseAlles.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseAllesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseAllesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseAlle> items);

  }
}
