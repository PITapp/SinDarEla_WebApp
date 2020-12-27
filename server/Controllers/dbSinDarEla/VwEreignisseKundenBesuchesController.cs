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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseKundenBesuches")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseKundenBesuches")]
  public partial class VwEreignisseKundenBesuchesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseKundenBesuchesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseKundenBesuches
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseKundenBesuche> GetVwEreignisseKundenBesuches()
    {
      var items = this.context.VwEreignisseKundenBesuches.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseKundenBesuche>();
      this.OnVwEreignisseKundenBesuchesRead(ref items);

      return items;
    }

    partial void OnVwEreignisseKundenBesuchesRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseKundenBesuche> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseKundenBesuche> GetVwEreignisseKundenBesuche(string key)
    {
        var items = this.context.VwEreignisseKundenBesuches.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseKundenBesuchesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseKundenBesuchesGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseKundenBesuche> items);

  }
}
