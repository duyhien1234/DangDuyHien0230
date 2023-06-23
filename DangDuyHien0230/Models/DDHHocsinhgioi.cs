using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace DangDuyHien0230.Models;
public class DDHHocsinhgioi
{
    [Key]
    [Display(Name = "Ket qua")]
    public string Ketqua {get;set;}
    [Display(Name = "Sinh vien")]
    public string Sinhvien {get;set;}
    [ForeignKey("Sinhvien")]
    public DDHSinhvien? DDHSinhvien {get;set;}
}