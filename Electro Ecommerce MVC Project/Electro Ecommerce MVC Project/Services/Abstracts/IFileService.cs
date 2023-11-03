using Electro_Ecommerce_MVC_Project.Contracts;

namespace Electro_Ecommerce_MVC_Project.Services.Abstracts;

public interface IFileService
{
    string Upload(IFormFile file, string path);
    string Upload(IFormFile file, CustomUploadDirectories uploadDirectory);
    string GetStaticFilesDirectory(CustomUploadDirectories uploadDirectory);
    string GetStaticFilesDirectory(CustomUploadDirectories uploadDirectory, string fileName);
    string GetStaticFilesUrl(CustomUploadDirectories uploadDirectory, string fileName);
}
