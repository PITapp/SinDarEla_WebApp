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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenLeistungens")]
  [Route("mvc/odata/dbSinDarEla/VwKundenLeistungens")]
  public partial class VwKundenLeistungensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenLeistungensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenLeistungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenLeistungen> GetVwKundenLeistungens()
    {
      var items = this.context.VwKundenLeistungens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenLeistungen>();
      this.OnVwKundenLeistungensRead(ref items);

      return items;
    }

    partial void OnVwKundenLeistungensRead(ref IQueryable<Models.DbSinDarEla.VwKundenLeistungen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{KundenID}")]
    public SingleResult<VwKundenLeistungen> GetVwKundenLeistungen(int key)
    {
        var items = this.context.VwKundenLeistungens.AsNoTracking().Where(i=>i.KundenID == key);
        this.OnVwKundenLeistungensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenLeistungensGet(ref IQueryable<Models.DbSinDarEla.VwKundenLeistungen> items);

  }
}
