using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FileUpload.Models
{
    [Table("VwFileUploadPerHour")]
    public class VwFileUploadPerHour
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal MaxPrice { get; set; }
        
    }
}