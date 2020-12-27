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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseKundenbesucheHeutes")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseKundenbesucheHeutes")]
  public partial class VwEreignisseKundenbesucheHeutesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseKundenbesucheHeutesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseKundenbesucheHeutes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseKundenbesucheHeute> GetVwEreignisseKundenbesucheHeutes()
    {
      var items = this.context.VwEreignisseKundenbesucheHeutes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseKundenbesucheHeute>();
      this.OnVwEreignisseKundenbesucheHeutesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseKundenbesucheHeutesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseKundenbesucheHeute> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwEreignisseKundenbesucheHeute> GetVwEreignisseKundenbesucheHeute(int key)
    {
        var items = this.context.VwEreignisseKundenbesucheHeutes.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwEreignisseKundenbesucheHeutesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseKundenbesucheHeutesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseKundenbesucheHeute> items);

  }
}
