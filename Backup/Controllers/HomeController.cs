using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using MultiFileAttach.Models.ViewpageModels;
using MultiFileAttach.Helpers;
using MultiFileAttach.Models.Shared;
using MultiFileAttach.Data;

namespace MultiFileAttach.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create() 
        {
            //Creating viewModel object for the view
            UploadPageViewModel viewModel = new UploadPageViewModel();
            viewModel.HttpFileUploadViews = new List<HttpFileUploadView>();
            viewModel._FileUploadViewModel = new _FileUploadViewModel();
            
            //Creating set InUpdate mode to false
            viewModel._FileUploadViewModel.InUpdateMode = false;
 

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(UploadPageViewModel viewModel)
        {
            //File and its details are found in HttpPostedFileBase

            if (ModelState.IsValid) 
            {
                //retrieve fileupload content
                foreach (var upload in viewModel.HttpFileUploadViews) 
                {
                    //take files without sIds
                    if (upload.HttpFileUpload != null) 
                    {
                        var httpPostedFile = upload.HttpFileUpload.InputStream;
                        string filename = upload.HttpFileUpload.FileName;
                        string filetype = upload.HttpFileUpload.ContentType;
                        string filesize = upload.HttpFileUpload.ContentLength.ToString();
                    }
                    
                    
                    //process file upload content
                }

                return RedirectToAction("Index");
            }
            //if modelstate is not valid, check if viewModel has files attached to it
            if (viewModel.HttpFileUploadViews.Count() > 0)
            {
                //if viewModel as files set InUpdateMode to true
                viewModel._FileUploadViewModel.InUpdateMode = true;
            }
            
            return View(viewModel);
        }

        public ActionResult Edit() 
        {
            //Creating viewModel object for the view
            UploadPageViewModel viewModel = new UploadPageViewModel();
            viewModel.HttpFileUploadViews = new List<HttpFileUploadView>();
            viewModel._FileUploadViewModel = new _FileUploadViewModel();

            //Load files into viewModel
            FileUploadRepository db = new FileUploadRepository();
            viewModel.HttpFileUploadViews = db.GetUploadData();

            //Editing set InUpdate mode to true
            viewModel._FileUploadViewModel.InUpdateMode = true;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(UploadPageViewModel viewModel)
        {
            //Uploads with sId are files already saved

            if (ModelState.IsValid)
            {
                //retrieve fileupload content
                foreach (var upload in viewModel.HttpFileUploadViews)
                {                   
                    //take files without sIds
                    if (upload.HttpFileUpload != null) 
                    {
                        var httpPostedFile = upload.HttpFileUpload.InputStream;
                        string filename = upload.HttpFileUpload.FileName;
                        string filetype = upload.HttpFileUpload.ContentType;
                        string filesize = upload.HttpFileUpload.ContentLength.ToString();
                    }
                    
                    
                    //process file upload content

                    //remove files that didn't come back from the view from the database
                    //add new new files that came from the view to the database
                    //retain files that were already in the database that came from view
                }

                return RedirectToAction("Index");
            }
            //if modelstate is not valid, check if viewModel has files attached to it
            if (viewModel.HttpFileUploadViews.Count() > 0)
            {
                //if viewModel as files set InUpdateMode to true
                viewModel._FileUploadViewModel.InUpdateMode = true;
            }
            
            return View(viewModel);
        }

        public ActionResult GetUpload()
        {
            _FileUploadViewModel _fileUploadViewModel = new _FileUploadViewModel();
            _fileUploadViewModel.FileUploadView = new HttpFileUploadView();
            return View("_FileUpload", _fileUploadViewModel);
        }

        public ActionResult PartialFileUpload() 
        {
            //******* processing ajax file upload ******//

            var httpPostedFile = Request.Files["UpoadFile"];
            string filename = null;
            string filetype = null;
            string filesize = null;
            if (httpPostedFile != null)
            {
                 filename = httpPostedFile.FileName;
                 filetype = httpPostedFile.ContentType;
                 filesize = httpPostedFile.ContentLength.ToString();

                byte[] data;

                using (Stream inputStream = httpPostedFile.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                }
            }

            
            //save data and return its id from table and send as part of the returning json
            Random rand = new Random();
            int id = rand.Next();

            var result = new
            {
                _id = id,
                _name = filename,
                _type = filetype,
                _length = filesize
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
