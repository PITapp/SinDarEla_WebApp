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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundenHauptbetreuers")]
  [Route("mvc/odata/dbSinDarEla/VwKundenHauptbetreuers")]
  public partial class VwKundenHauptbetreuersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundenHauptbetreuersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundenHauptbetreuers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKundenHauptbetreuer> GetVwKundenHauptbetreuers()
    {
      var items = this.context.VwKundenHauptbetreuers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKundenHauptbetreuer>();
      this.OnVwKundenHauptbetreuersRead(ref items);

      return items;
    }

    partial void OnVwKundenHauptbetreuersRead(ref IQueryable<Models.DbSinDarEla.VwKundenHauptbetreuer> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwKundenHauptbetreuer> GetVwKundenHauptbetreuer(int key)
    {
        var items = this.context.VwKundenHauptbetreuers.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwKundenHauptbetreuersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundenHauptbetreuersGet(ref IQueryable<Models.DbSinDarEla.VwKundenHauptbetreuer> items);

  }
}
