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

  [ODataRoutePrefix("odata/dbSinDarEla/VwDienstplanKundenLeistungens")]
  [Route("mvc/odata/dbSinDarEla/VwDienstplanKundenLeistungens")]
  public partial class VwDienstplanKundenLeistungensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwDienstplanKundenLeistungensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwDienstplanKundenLeistungens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwDienstplanKundenLeistungen> GetVwDienstplanKundenLeistungens()
    {
      var items = this.context.VwDienstplanKundenLeistungens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwDienstplanKundenLeistungen>();
      this.OnVwDienstplanKundenLeistungensRead(ref items);

      return items;
    }

    partial void OnVwDienstplanKundenLeistungensRead(ref IQueryable<Models.DbSinDarEla.VwDienstplanKundenLeistungen> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{BaseID}")]
    public SingleResult<VwDienstplanKundenLeistungen> GetVwDienstplanKundenLeistungen(int key)
    {
        var items = this.context.VwDienstplanKundenLeistungens.AsNoTracking().Where(i=>i.BaseID == key);
        this.OnVwDienstplanKundenLeistungensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwDienstplanKundenLeistungensGet(ref IQueryable<Models.DbSinDarEla.VwDienstplanKundenLeistungen> items);

  }
}
