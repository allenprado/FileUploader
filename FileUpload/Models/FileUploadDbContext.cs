using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FileUpload.Models
{
    public class FileUploadDbContext: DbContext
    {
        public FileUploadDbContext() : base("FileUploaderCS")
        {
        }

        public DbSet<FileRecords> FileRecordsDB { get; set; }
    }
}