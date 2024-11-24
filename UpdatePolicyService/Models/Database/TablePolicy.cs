using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpdatePolicyService.Models.Database;

public class TablePolicy
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Policy { get; set; } = string.Empty;
    public int EndorseCount { get; set; }
    public bool CompletedPrint { get; set; }
    public int Rencnt { get; set; }
    public int Endcnt { get; set; }
    [Column("create_dat")]
    public DateTime CreateDate { get; set; }
    [Column("sta_print")]
    public bool StaPrint { get; set; }
    [Column("sta_release")]
    public bool StaRelease { get; set; }
    public string Flag { get; set; } = "00";
    public string Note1 { get; set; } = string.Empty;
    public string Note2 { get; set; } = string.Empty;
    public string Note3 { get; set; } = string.Empty;
}