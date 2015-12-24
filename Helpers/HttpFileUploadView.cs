using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiFileAttach.Helpers
{
    public class HttpFileUploadView : FileUploadView
    {
        public HttpFileUploadView() : base()
        {
           
        }
        public int? sId { get; set; }
        public HttpPostedFileBase HttpFileUpload { get; set; }
    }
}