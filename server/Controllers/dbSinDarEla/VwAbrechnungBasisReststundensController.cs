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

  [ODataRoutePrefix("odata/dbSinDarEla/VwAbrechnungBasisReststundens")]
  [Route("mvc/odata/dbSinDarEla/VwAbrechnungBasisReststundens")]
  public partial class VwAbrechnungBasisReststundensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwAbrechnungBasisReststundensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwAbrechnungBasisReststundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwAbrechnungBasisReststunden> GetVwAbrechnungBasisReststundens()
    {
      var items = this.context.VwAbrechnungBasisReststundens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwAbrechnungBasisReststunden>();
      this.OnVwAbrechnungBasisReststundensRead(ref items);

      return items;
    }

    partial void OnVwAbrechnungBasisReststundensRead(ref IQueryable<Models.DbSinDarEla.VwAbrechnungBasisReststunden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{Art}")]
    public SingleResult<VwAbrechnungBasisReststunden> GetVwAbrechnungBasisReststunden(string key)
    {
        var items = this.context.VwAbrechnungBasisReststundens.AsNoTracking().Where(i=>i.Art == key);
        this.OnVwAbrechnungBasisReststundensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwAbrechnungBasisReststundensGet(ref IQueryable<Models.DbSinDarEla.VwAbrechnungBasisReststunden> items);

  }
}
