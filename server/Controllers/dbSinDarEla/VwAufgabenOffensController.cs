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

  [ODataRoutePrefix("odata/dbSinDarEla/VwAufgabenOffens")]
  [Route("mvc/odata/dbSinDarEla/VwAufgabenOffens")]
  public partial class VwAufgabenOffensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwAufgabenOffensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwAufgabenOffens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwAufgabenOffen> GetVwAufgabenOffens()
    {
      var items = this.context.VwAufgabenOffens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwAufgabenOffen>();
      this.OnVwAufgabenOffensRead(ref items);

      return items;
    }

    partial void OnVwAufgabenOffensRead(ref IQueryable<Models.DbSinDarEla.VwAufgabenOffen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{ZustaendigBaseID}")]
    public SingleResult<VwAufgabenOffen> GetVwAufgabenOffen(int? key)
    {
        var items = this.context.VwAufgabenOffens.AsNoTracking().Where(i=>i.ZustaendigBaseID == key);
        this.OnVwAufgabenOffensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwAufgabenOffensGet(ref IQueryable<Models.DbSinDarEla.VwAufgabenOffen> items);

  }
}
