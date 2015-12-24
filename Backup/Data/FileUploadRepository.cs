using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MultiFileAttach.Helpers;

namespace MultiFileAttach.Data
{
    public class FileUploadRepository
    {
        public List<HttpFileUploadView> GetUploadData() 
        {
            return new List<HttpFileUploadView>(){
            new HttpFileUploadView(){
            AttachedFileName = "Multiple File Tutor.pdf",
            AttachedFileSize = "234KB",
            AttachedFileType = "Application/pdf",
            Id = 1,
            sId = 1
            },
            new HttpFileUploadView(){
            AttachedFileName = "Learn MVC.pdf",
            AttachedFileSize = "800KB",
            AttachedFileType = "Application/pdf",
            Id = 2,
            sId = 2
            },
            new HttpFileUploadView(){
            AttachedFileName = "Kwabena's Profile.pdf",
            AttachedFileSize = "409KB",
            AttachedFileType = "Application/pdf",
            Id = 3,
            sId = 3
            }
            };
        }
    }
}