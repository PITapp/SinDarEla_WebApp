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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterTermineGeplants")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterTermineGeplants")]
  public partial class VwMitarbeiterTermineGeplantsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterTermineGeplantsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterTermineGeplants
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterTermineGeplant> GetVwMitarbeiterTermineGeplants()
    {
      var items = this.context.VwMitarbeiterTermineGeplants.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterTermineGeplant>();
      this.OnVwMitarbeiterTermineGeplantsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterTermineGeplantsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTermineGeplant> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{EreignisArtCode}")]
    public SingleResult<VwMitarbeiterTermineGeplant> GetVwMitarbeiterTermineGeplant(string key)
    {
        var items = this.context.VwMitarbeiterTermineGeplants.AsNoTracking().Where(i=>i.EreignisArtCode == key);
        this.OnVwMitarbeiterTermineGeplantsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterTermineGeplantsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterTermineGeplant> items);

  }
}
