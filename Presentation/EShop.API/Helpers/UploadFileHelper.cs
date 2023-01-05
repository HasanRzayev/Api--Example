namespace PhotoHome.Helpers
{
	public class UploadFileHelper
	{
       
            public async static Task<string> UploadFile(IFormFile file)
            {
                string link = Guid.NewGuid().ToString();
                using var fs = new FileStream(@$"wwwroot/{link}{Path.GetExtension(file.FileName)}", FileMode.Create);

                await file.CopyToAsync(fs);
                return fs.Name;

            }
        
    }
}
