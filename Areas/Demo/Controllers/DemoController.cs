using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication9.Areas.Demo.Models;
using System.Data.SqlClient;

namespace WebApplication9.Areas.Demo.Controllers
{

    [Area("Demo")]
    [Route("Demo/Demo/{Action}")]
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly IConfiguration Configuration;
        public DemoController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Save(FileUploadModel model_FileUpload)
        {

            using (SqlConnection objConn = new SqlConnection(this.Configuration.GetConnectionString("connectionString")))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        if (model_FileUpload.FileID != 0)
                        {
                            if (model_FileUpload.File == null && TempData["FilePath"] != null)

                                model_FileUpload.FilePath = TempData["FilePath"].ToString();
                        }


                        if (model_FileUpload.File != null)
                        { 
                            string filePath = System.IO.Path.GetExtension(model_FileUpload.File.FileName);

                            string directoryPath = @"D:\ARMAN\ASP.NET PROGRAMS\WebApplication9\WebApplication9\wwwroot\" + filePath;    

                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            //string folderPath = Path.Combine("wwwroot/" + filePath + "/", model_FileUpload.File.FileName);
                            string fileExtension = Path.GetExtension(model_FileUpload.File.FileName);
                            string folderPath = Path.Combine("wwwroot", fileExtension, model_FileUpload.File.FileName);


                            using (FileStream fs = System.IO.File.Create(folderPath))
                            {
                                model_FileUpload.File.CopyTo(fs);
                            }

                            model_FileUpload.FilePath = "/" + filePath + "/" + model_FileUpload.File.FileName;
                        }

                        objCmd.CommandType = CommandType.StoredProcedure;

                        if (model_FileUpload.FileID == null || model_FileUpload.FileID == 0)
                        {
                            objCmd.CommandText = "PR_FileUpload_Insert";
                        }
                        else
                        {
                            objCmd.CommandText = "PR_FileUpload_Update";
                            objCmd.Parameters.Add("@FileUploadID", SqlDbType.Int).Value = model_FileUpload.FileID;
                        }
                        objCmd.Parameters.Add("@FilePath", SqlDbType.VarChar).Value = model_FileUpload.FilePath;


                        if (Convert.ToBoolean(objCmd.ExecuteNonQuery()))
                        {
                            if (model_FileUpload.FileID == null || model_FileUpload.FileID == 0)
                                TempData["Message"] = "Record Inserted Successfully";
                            else
                            {

                            }
                                return RedirectToAction("Index");
                        }
                    }


                    catch (Exception ex)
                    {
                        //TempData["Message"] = ex.InnerException.Message.ToString();
                        TempData["Message"] = ex.InnerException != null ? ex.InnerException.Message.ToString() : ex.Message.ToString();

                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult DemoDisplay()
        {
            string str = this.Configuration.GetConnectionString("connectionString");
			SqlConnection conn = new SqlConnection(str);
			conn.Open();
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "PR_FileUpload_SelectAll";
			SqlDataReader rdr = cmd.ExecuteReader();
			DataTable dt = new DataTable();
			dt.Load(rdr);
			conn.Close();
			return View(dt);
        }

    }
}
