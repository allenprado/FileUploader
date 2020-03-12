using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FileUpload.Models
{
    [Table("VwFileUploadPerHour")]
    public class VwFileUploadPerHour
    {
        [Key]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Date")]
        public string DateStr { get; set; }
        [Display(Name = "Most Expensive Hour")]
        public decimal MaxPrice { get; set; }

    }
}