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

  [ODataRoutePrefix("odata/dbSinDarEla/VwKundens")]
  [Route("mvc/odata/dbSinDarEla/VwKundens")]
  public partial class VwKundensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwKundensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwKundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwKunden> GetVwKundens()
    {
      var items = this.context.VwKundens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwKunden>();
      this.OnVwKundensRead(ref items);

      return items;
    }

    partial void OnVwKundensRead(ref IQueryable<Models.DbSinDarEla.VwKunden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwKunden> GetVwKunden(int key)
    {
        var items = this.context.VwKundens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwKundensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwKundensGet(ref IQueryable<Models.DbSinDarEla.VwKunden> items);

  }
}
