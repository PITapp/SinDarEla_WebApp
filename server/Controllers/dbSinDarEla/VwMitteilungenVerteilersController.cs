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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitteilungenVerteilers")]
  [Route("mvc/odata/dbSinDarEla/VwMitteilungenVerteilers")]
  public partial class VwMitteilungenVerteilersController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitteilungenVerteilersController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitteilungenVerteilers
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitteilungenVerteiler> GetVwMitteilungenVerteilers()
    {
      var items = this.context.VwMitteilungenVerteilers.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitteilungenVerteiler>();
      this.OnVwMitteilungenVerteilersRead(ref items);

      return items;
    }

    partial void OnVwMitteilungenVerteilersRead(ref IQueryable<Models.DbSinDarEla.VwMitteilungenVerteiler> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitteilungID}")]
    public SingleResult<VwMitteilungenVerteiler> GetVwMitteilungenVerteiler(int key)
    {
        var items = this.context.VwMitteilungenVerteilers.AsNoTracking().Where(i=>i.MitteilungID == key);
        this.OnVwMitteilungenVerteilersGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitteilungenVerteilersGet(ref IQueryable<Models.DbSinDarEla.VwMitteilungenVerteiler> items);

  }
}
