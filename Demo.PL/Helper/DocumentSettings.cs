namespace Demo.PL.Helper
{
	public static class DocumentSettings
	{
		public static string UploadFile(IFormFile file, string folderName)
		{

			//1- Get Full Path of folder
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", folderName);

			//2- Get File Name and make it unique
			var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";

			//3- Get Full file path
			var filePath = Path.Combine(folderPath, fileName);

			//4- Copy File in filePath
			using FileStream writer = new FileStream(filePath, FileMode.Create);
			file.CopyTo(writer);

			return fileName;
		}

		public static bool DeleteFile(string fileName, string folderName)
		{
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", folderName);

			var filePath = Path.Combine(folderPath, fileName);

			if(File.Exists(filePath))
			{
				File.Delete(filePath);

				return true;
			}
			else
			{
				return false;
			}
        }
	}
}
