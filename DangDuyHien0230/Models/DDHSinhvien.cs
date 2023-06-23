using System.ComponentModel.DataAnnotations;
namespace DangDuyHien0230.Models;
public class DDHSinhvien
{
    [Key]
    [Display(Name = "Sinh vien")]
    public string Sinhvien {get;set;}
    [Display(Name = "Truong")]
    public  string Truong  {get;set;}
    [Display(Name = "thanh pho")]
    public  string Thanhpho {get;set;}
}