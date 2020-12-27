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

  [ODataRoutePrefix("odata/dbSinDarEla/VwEreignisseModulMitarbeiters")]
  [Route("mvc/odata/dbSinDarEla/VwEreignisseModulMitarbeiters")]
  public partial class VwEreignisseModulMitarbeitersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwEreignisseModulMitarbeitersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwEreignisseModulMitarbeiters
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwEreignisseModulMitarbeiter> GetVwEreignisseModulMitarbeiters()
    {
      var items = this.context.VwEreignisseModulMitarbeiters.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwEreignisseModulMitarbeiter>();
      this.OnVwEreignisseModulMitarbeitersRead(ref items);

      return items;
    }

    partial void OnVwEreignisseModulMitarbeitersRead(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulMitarbeiter> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwEreignisseModulMitarbeiter> GetVwEreignisseModulMitarbeiter(string key)
    {
        var items = this.context.VwEreignisseModulMitarbeiters.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwEreignisseModulMitarbeitersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwEreignisseModulMitarbeitersGet(ref IQueryable<Models.DbSinDarEla.VwEreignisseModulMitarbeiter> items);

  }
}
