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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseModulManagements")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseModulManagements")]
  public partial class VwEreignisseModulManagementsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseModulManagementsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseModulManagements
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseModulManagement> GetVwEreignisseModulManagements()
    {
      var items = this.context.VwEreignisseModulManagements.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseModulManagement>();
      this.OnVwEreignisseModulManagementsRead(ref items);

      return items;
    }

    partial void OnVwEreignisseModulManagementsRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulManagement> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseModulManagement> GetVwEreignisseModulManagement(string key)
    {
        var items = this.context.VwEreignisseModulManagements.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseModulManagementsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseModulManagementsGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulManagement> items);

  }
}
