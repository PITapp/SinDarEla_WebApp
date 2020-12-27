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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBenutzerAnus")]
  [Route("mvc/odata/dbSinDarEla/VwBenutzerAnus")]
  public partial class VwBenutzerAnusController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBenutzerAnusController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBenutzerAnus
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBenutzerAnu> GetVwBenutzerAnus()
    {
      var items = this.context.VwBenutzerAnus.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBenutzerAnu>();
      this.OnVwBenutzerAnusRead(ref items);

      return items;
    }

    partial void OnVwBenutzerAnusRead(ref IQueryable<Models.DbSinDarEla.VwBenutzerAnu> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Id}")]
    public SingleResult<VwBenutzerAnu> GetVwBenutzerAnu(string key)
    {
        var items = this.context.VwBenutzerAnus.AsNoTracking().Where(i=>i.Id == key);
        this.OnVwBenutzerAnusGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBenutzerAnusGet(ref IQueryable<Models.DbSinDarEla.VwBenutzerAnu> items);

  }
}
