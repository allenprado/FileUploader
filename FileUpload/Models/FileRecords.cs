using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FileUpload.Models
{
    [Table("FileUpload")]
    public class FileRecords
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public DateTime DateUpload { get; set; }
    }
}