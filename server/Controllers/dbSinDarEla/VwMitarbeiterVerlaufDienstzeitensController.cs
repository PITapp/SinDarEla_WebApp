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

  [ODataRoutePrefix("odata/dbSinDarEla/VwMitarbeiterVerlaufDienstzeitens")]
  [Route("mvc/odata/dbSinDarEla/VwMitarbeiterVerlaufDienstzeitens")]
  public partial class VwMitarbeiterVerlaufDienstzeitensController : ODataController
  {
    private Data.DbSinDarElaContext context;

    public VwMitarbeiterVerlaufDienstzeitensController(Data.DbSinDarElaContext context)
    {
      this.context = context;
    }
    // GET /odata/DbSinDarEla/VwMitarbeiterVerlaufDienstzeitens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten> GetVwMitarbeiterVerlaufDienstzeitens()
    {
      var items = this.context.VwMitarbeiterVerlaufDienstzeitens.AsNoTracking().AsQueryable<Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten>();
      this.OnVwMitarbeiterVerlaufDienstzeitensRead(ref items);

      return items;
    }

    partial void OnVwMitarbeiterVerlaufDienstzeitensRead(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten> items);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("{MitarbeiterVerlaufDienstzeitenArtID}")]
    public SingleResult<VwMitarbeiterVerlaufDienstzeiten> GetVwMitarbeiterVerlaufDienstzeiten(int key)
    {
        var items = this.context.VwMitarbeiterVerlaufDienstzeitens.AsNoTracking().Where(i=>i.MitarbeiterVerlaufDienstzeitenArtID == key);
        this.OnVwMitarbeiterVerlaufDienstzeitensGet(ref items);

        return SingleResult.Create(items);
    }

    partial void OnVwMitarbeiterVerlaufDienstzeitensGet(ref IQueryable<Models.DbSinDarEla.VwMitarbeiterVerlaufDienstzeiten> items);

  }
}
