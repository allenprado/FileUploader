using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileUpload.Models
{
    [Table("VwFileUpload")]
    public class VwFileUpload
    {
        [Key]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        [Display(Name = "Date")]
        public string DateStr { get; set; }
        [Display(Name = "Price Maximum")]
        public decimal MaxPrice { get; set; }
        [Display(Name = "Price Minimum")]
        public decimal MinPrice { get; set; }
        [Display(Name = "Price Average")]
        public decimal AvgPrice { get; set; }
    }
}