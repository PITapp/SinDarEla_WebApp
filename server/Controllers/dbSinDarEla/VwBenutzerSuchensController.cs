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

  [ODataRoutePrefix("odata/dbSinDarEla/VwBenutzerSuchens")]
  [Route("mvc/odata/dbSinDarEla/VwBenutzerSuchens")]
  public partial class VwBenutzerSuchensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwBenutzerSuchensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwBenutzerSuchens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwBenutzerSuchen> GetVwBenutzerSuchens()
    {
      var items = this.context.VwBenutzerSuchens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwBenutzerSuchen>();
      this.OnVwBenutzerSuchensRead(ref items);

      return items;
    }

    partial void OnVwBenutzerSuchensRead(ref IQueryable<Models.DbSinDarEla.VwBenutzerSuchen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwBenutzerSuchen> GetVwBenutzerSuchen(int key)
    {
        var items = this.context.VwBenutzerSuchens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwBenutzerSuchensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwBenutzerSuchensGet(ref IQueryable<Models.DbSinDarEla.VwBenutzerSuchen> items);

  }
}
