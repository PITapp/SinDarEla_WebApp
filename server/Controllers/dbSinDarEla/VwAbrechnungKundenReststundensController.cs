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

  [ODataRoutePrefix("odata/dbSinDarEla/VwAbrechnungKundenReststundens")]
  [Route("mvc/odata/dbSinDarEla/VwAbrechnungKundenReststundens")]
  public partial class VwAbrechnungKundenReststundensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwAbrechnungKundenReststundensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwAbrechnungKundenReststundens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwAbrechnungKundenReststunden> GetVwAbrechnungKundenReststundens()
    {
      var items = this.context.VwAbrechnungKundenReststundens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwAbrechnungKundenReststunden>();
      this.OnVwAbrechnungKundenReststundensRead(ref items);

      return items;
    }

    partial void OnVwAbrechnungKundenReststundensRead(ref IQueryable<Models.DbSinDarEla.VwAbrechnungKundenReststunden> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{AbrechnungBasisID}")]
    public SingleResult<VwAbrechnungKundenReststunden> GetVwAbrechnungKundenReststunden(int key)
    {
        var items = this.context.VwAbrechnungKundenReststundens.AsNoTracking().Where(i=>i.AbrechnungBasisID == key);
        this.OnVwAbrechnungKundenReststundensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwAbrechnungKundenReststundensGet(ref IQueryable<Models.DbSinDarEla.VwAbrechnungKundenReststunden> items);

  }
}
