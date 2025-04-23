using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication9.Areas.FILEUPLOAD.Controllers
{
	[Area("FILEUPLOAD")]
	[Route("FILEUPLOAD/FILEUPLOAD/{Action}")]

	public class FILEUPLOADController : Controller
	{
		public IConfiguration Configuration;
		public FILEUPLOADController(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private readonly ILogger<FILEUPLOADController> _logger;

		public IActionResult FileList()
		{
			string connectionString = this.Configuration.GetConnectionString("connectionString");

			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			SqlCommand sqlCommand = sqlConnection.CreateCommand();
			sqlCommand.CommandText = "PR_FileUpload_SelectAll";
			sqlCommand.CommandType = CommandType.StoredProcedure;
			SqlDataReader reader = sqlCommand.ExecuteReader();
			DataTable dataTable = new DataTable();
			dataTable.Load(reader);
			sqlConnection.Close();
			return View(dataTable);
		}


	}
}
