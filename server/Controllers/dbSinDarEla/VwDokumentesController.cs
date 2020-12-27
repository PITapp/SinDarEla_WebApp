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

  [ODataRoutePrefix("odata/dbSinDarEla/VwDokumentes")]
  [Route("mvc/odata/dbSinDarEla/VwDokumentes")]
  public partial class VwDokumentesController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwDokumentesController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwDokumentes
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwDokumente> GetVwDokumentes()
    {
      var items = this.context.VwDokumentes.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwDokumente>();
      this.OnVwDokumentesRead(ref items);

      return items;
    }

    partial void OnVwDokumentesRead(ref IQueryable<Models.DbSinDarEla.VwDokumente> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{DokumenteKategorieID}")]
    public SingleResult<VwDokumente> GetVwDokumente(int key)
    {
        var items = this.context.VwDokumentes.AsNoTracking().Where(i=>i.DokumenteKategorieID == key);
        this.OnVwDokumentesGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwDokumentesGet(ref IQueryable<Models.DbSinDarEla.VwDokumente> items);

  }
}
