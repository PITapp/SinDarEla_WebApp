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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBaseBenutzers")]
  [Route("mvc/odata/dbSinDarEla/VwBaseBenutzers")]
  public partial class VwBaseBenutzersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBaseBenutzersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBaseBenutzers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBaseBenutzer> GetVwBaseBenutzers()
    {
      var items = this.context.VwBaseBenutzers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBaseBenutzer>();
      this.OnVwBaseBenutzersRead(ref items);

      return items;
    }

    partial void OnVwBaseBenutzersRead(ref IQueryable<Models.DbSinDarEla.VwBaseBenutzer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Benutzername}")]
    public SingleResult<VwBaseBenutzer> GetVwBaseBenutzer(string key)
    {
        var items = this.context.VwBaseBenutzers.AsNoTracking().Where(i=>i.Benutzername == key);
        this.OnVwBaseBenutzersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBaseBenutzersGet(ref IQueryable<Models.DbSinDarEla.VwBaseBenutzer> items);

  }
}
