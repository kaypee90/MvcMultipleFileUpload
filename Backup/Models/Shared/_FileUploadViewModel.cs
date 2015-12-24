using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultiFileAttach.Helpers;

namespace MultiFileAttach.Models.Shared
{
    public class _FileUploadViewModel
    {
        public _FileUploadViewModel()
        {
            FileUploadView = new HttpFileUploadView();
        }

        public HttpFileUploadView FileUploadView { get; set; }
        public bool InUpdateMode { get; set; }
        public string UploadId { get; set; }
    }
}