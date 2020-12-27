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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseAntraegeUrlaubVerbrauchts")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseAntraegeUrlaubVerbrauchts")]
  public partial class VwEreignisseAntraegeUrlaubVerbrauchtsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseAntraegeUrlaubVerbrauchtsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseAntraegeUrlaubVerbrauchts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseAntraegeUrlaubVerbraucht> GetVwEreignisseAntraegeUrlaubVerbrauchts()
    {
      var items = this.context.VwEreignisseAntraegeUrlaubVerbrauchts.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseAntraegeUrlaubVerbraucht>();
      this.OnVwEreignisseAntraegeUrlaubVerbrauchtsRead(ref items);

      return items;
    }

    partial void OnVwEreignisseAntraegeUrlaubVerbrauchtsRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseAntraegeUrlaubVerbraucht> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwEreignisseAntraegeUrlaubVerbraucht> GetVwEreignisseAntraegeUrlaubVerbraucht(int key)
    {
        var items = this.context.VwEreignisseAntraegeUrlaubVerbrauchts.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwEreignisseAntraegeUrlaubVerbrauchtsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseAntraegeUrlaubVerbrauchtsGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseAntraegeUrlaubVerbraucht> items);

  }
}
