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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBenutzers")]
  [Route("mvc/odata/dbSinDarEla/VwBenutzers")]
  public partial class VwBenutzersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBenutzersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBenutzers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBenutzer> GetVwBenutzers()
    {
      var items = this.context.VwBenutzers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBenutzer>();
      this.OnVwBenutzersRead(ref items);

      return items;
    }

    partial void OnVwBenutzersRead(ref IQueryable<Models.DbSinDarEla.VwBenutzer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwBenutzer> GetVwBenutzer(int key)
    {
        var items = this.context.VwBenutzers.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwBenutzersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBenutzersGet(ref IQueryable<Models.DbSinDarEla.VwBenutzer> items);

  }
}
