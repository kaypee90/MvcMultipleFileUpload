using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiFileAttach.Helpers
{
    public class FileUploadView
    {
        public FileUploadView()
        {
            Id = 0;
        }
        public int Id { get; set; }
        public byte[] AttachedFile { get; set; }
        public string AttachedFileName { get; set; }
        public string AttachedFileType { get; set; }
        public string AttachedFileSize { get; set; }
    }
}