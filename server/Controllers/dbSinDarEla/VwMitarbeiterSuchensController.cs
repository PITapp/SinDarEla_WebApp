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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterSuchens")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterSuchens")]
  public partial class VwMitarbeiterSuchensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterSuchensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterSuchens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterSuchen> GetVwMitarbeiterSuchens()
    {
      var items = this.context.VwMitarbeiterSuchens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterSuchen>();
      this.OnVwMitarbeiterSuchensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterSuchensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterSuchen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwMitarbeiterSuchen> GetVwMitarbeiterSuchen(int key)
    {
        var items = this.context.VwMitarbeiterSuchens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwMitarbeiterSuchensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterSuchensGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterSuchen> items);

  }
}
