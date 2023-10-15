using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Web;

public class FileController : Controller
{
    [HttpGet]
    public IActionResult DownloadFile()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DownloadFile(string firstName, string lastName, string fileName)
    {
        string encodedFileName = HttpUtility.UrlEncode(fileName);

        // Generate text content for the file
        string fileContent = $"Ім'я: {firstName}\nПрізвище: {lastName}";

        // Встановлення заголовків для відповіді
        Response.Headers.Add("Content-Disposition", $"attachment; filename={encodedFileName}.txt");
        Response.ContentType = "text/plain";

        // Запис текстового вмісту до відповіді
        Response.WriteAsync(fileContent);

        return new EmptyResult();
    }
}
