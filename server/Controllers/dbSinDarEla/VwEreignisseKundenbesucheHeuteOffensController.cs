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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseKundenbesucheHeuteOffens")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseKundenbesucheHeuteOffens")]
  public partial class VwEreignisseKundenbesucheHeuteOffensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseKundenbesucheHeuteOffensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseKundenbesucheHeuteOffens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseKundenbesucheHeuteOffen> GetVwEreignisseKundenbesucheHeuteOffens()
    {
      var items = this.context.VwEreignisseKundenbesucheHeuteOffens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseKundenbesucheHeuteOffen>();
      this.OnVwEreignisseKundenbesucheHeuteOffensRead(ref items);

      return items;
    }

    partial void OnVwEreignisseKundenbesucheHeuteOffensRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseKundenbesucheHeuteOffen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwEreignisseKundenbesucheHeuteOffen> GetVwEreignisseKundenbesucheHeuteOffen(int key)
    {
        var items = this.context.VwEreignisseKundenbesucheHeuteOffens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwEreignisseKundenbesucheHeuteOffensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseKundenbesucheHeuteOffensGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseKundenbesucheHeuteOffen> items);

  }
}
