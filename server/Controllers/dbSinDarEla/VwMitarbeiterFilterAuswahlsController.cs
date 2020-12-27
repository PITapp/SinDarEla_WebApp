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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterFilterAuswahls")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterFilterAuswahls")]
  public partial class VwMitarbeiterFilterAuswahlsController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterFilterAuswahlsController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterFilterAuswahls
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterFilterAuswahl> GetVwMitarbeiterFilterAuswahls()
    {
      var items = this.context.VwMitarbeiterFilterAuswahls.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterFilterAuswahl>();
      this.OnVwMitarbeiterFilterAuswahlsRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterFilterAuswahlsRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFilterAuswahl> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ID}")]
    public SingleResult<VwMitarbeiterFilterAuswahl> GetVwMitarbeiterFilterAuswahl(int key)
    {
        var items = this.context.VwMitarbeiterFilterAuswahls.AsNoTracking().Where(i=>i.ID == key);
        this.OnVwMitarbeiterFilterAuswahlsGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterFilterAuswahlsGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterFilterAuswahl> items);

  }
}
