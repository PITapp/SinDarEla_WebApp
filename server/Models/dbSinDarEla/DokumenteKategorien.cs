using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SinDarEla.Models.DbSinDarEla
{
  [Table("DokumenteKategorien")]
  public partial class DokumenteKategorien
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DokumenteKategorieID
    {
      get;
      set;
    }


    public ICollection<Dokumente> Dokumentes { get; set; }
    public string Titel
    {
      get;
      set;
    }
  }
}
