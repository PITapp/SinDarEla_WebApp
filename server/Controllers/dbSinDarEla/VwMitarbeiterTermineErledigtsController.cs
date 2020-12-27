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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterTermineErledigts")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterTermineErledigts")]
  public partial class VwMitarbeiterTermineErledigtsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterTermineErledigtsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterTermineErledigts
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterTermineErledigt> GetVwMitarbeiterTermineErledigts()
    {
      var items = this.context.VwMitarbeiterTermineErledigts.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterTermineErledigt>();
      this.OnVwMitarbeiterTermineErledigtsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterTermineErledigtsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTermineErledigt> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwMitarbeiterTermineErledigt> GetVwMitarbeiterTermineErledigt(string key)
    {
        var items = this.context.VwMitarbeiterTermineErledigts.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwMitarbeiterTermineErledigtsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterTermineErledigtsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTermineErledigt> items);

  }
}
