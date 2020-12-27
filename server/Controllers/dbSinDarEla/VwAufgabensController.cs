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

  [ODataRoutePrefix("odata/dbSinDarEla/VwAufgabens")]
  [Route("mvc/odata/dbSinDarEla/VwAufgabens")]
  public partial class VwAufgabensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwAufgabensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwAufgabens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwAufgaben> GetVwAufgabens()
    {
      var items = this.context.VwAufgabens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwAufgaben>();
      this.OnVwAufgabensRead(ref items);

      return items;
    }

    partial void OnVwAufgabensRead(ref IQueryable<Models.DbSinDarEla.VwAufgaben> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwAufgaben> GetVwAufgaben(int key)
    {
        var items = this.context.VwAufgabens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwAufgabensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwAufgabensGet(ref IQueryable<Models.DbSinDarEla.VwAufgaben> items);

  }
}
