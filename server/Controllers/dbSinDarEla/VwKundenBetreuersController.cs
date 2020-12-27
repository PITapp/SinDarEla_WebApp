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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenBetreuers")]
  [Route("mvc/odata/dbSinDarEla/VwKundenBetreuers")]
  public partial class VwKundenBetreuersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenBetreuersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenBetreuers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenBetreuer> GetVwKundenBetreuers()
    {
      var items = this.context.VwKundenBetreuers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenBetreuer>();
      this.OnVwKundenBetreuersRead(ref items);

      return items;
    }

    partial void OnVwKundenBetreuersRead(ref IQueryable<Models.DbSinDarEla.VwKundenBetreuer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenLeistungID}")]
    public SingleResult<VwKundenBetreuer> GetVwKundenBetreuer(int key)
    {
        var items = this.context.VwKundenBetreuers.AsNoTracking().Where(i=>i.KundenLeistungID == key);
        this.OnVwKundenBetreuersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenBetreuersGet(ref IQueryable<Models.DbSinDarEla.VwKundenBetreuer> items);

  }
}
