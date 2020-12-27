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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterUrlaubs")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterUrlaubs")]
  public partial class VwMitarbeiterUrlaubsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterUrlaubsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterUrlaubs
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterUrlaub> GetVwMitarbeiterUrlaubs()
    {
      var items = this.context.VwMitarbeiterUrlaubs.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterUrlaub>();
      this.OnVwMitarbeiterUrlaubsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterUrlaubsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterUrlaub> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterID}")]
    public SingleResult<VwMitarbeiterUrlaub> GetVwMitarbeiterUrlaub(int key)
    {
        var items = this.context.VwMitarbeiterUrlaubs.AsNoTracking().Where(i=>i.MitarbeiterID == key);
        this.OnVwMitarbeiterUrlaubsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterUrlaubsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterUrlaub> items);

  }
}
