using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultiFileAttach.Helpers;
using MultiFileAttach.Models.Shared;

namespace MultiFileAttach.Models.ViewpageModels
{
    /*
      The class UploadPageViewModel is the view model class for your view. So you can add the properties of this class
      to a view model you are already using on the view where you want to add the multiple file attachment control.
    */
    public class UploadPageViewModel
    {
        public List<HttpFileUploadView> HttpFileUploadViews { get; set; }
        public _FileUploadViewModel _FileUploadViewModel { get; set; }
    }
}