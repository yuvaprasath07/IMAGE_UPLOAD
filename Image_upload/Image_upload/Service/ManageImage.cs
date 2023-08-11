using Image_upload.Helper;
using Image_upload.Model;

namespace Image_upload.Service
{
    public class ManageImage : Imanageimage
    {
        private readonly FileDbContext dbContext;

        public ManageImage(FileDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<DetailsModel> UploadFile(IFormFile Files)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(Files.FileName);
                string fileName = Files.FileName + fileInfo.Extension;  //DateTime.UtcNow.Ticks.ToString() to be added to handle the same file repeatedly
                var filePath = Common.GetFilePath(fileName);

                if (File.Exists(filePath))
                {
                    throw new Exception("File with the same name already exists.");
                }

                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                    {
                        await Files.CopyToAsync(fileStream);
                    }
                }
                catch (IOException)
                {
                    throw new Exception("File with the same name already exists.");
                }

                fileInfo.Refresh();

                int width = 0;
                int height = 0;
                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".jpeg" || fileInfo.Extension == ".png")
                {
                    using (var image = System.Drawing.Image.FromFile(filePath))
                    {
                        width = image.Width;
                        height = image.Height;
                    }
                }
                FileInfo info = new FileInfo(filePath);
                long fileSizeInBytes = info.Length;
                double fileSizeInMegabytes = (double)fileSizeInBytes / 1048576; // 1024 bytes * 1024 bytes = 1048576 bytes
                DetailsModel fileDetails = new DetailsModel
                {
                    FileName = fileInfo.Name,
                    FullPath = filePath,
                    DirectoryName = fileInfo.DirectoryName,
                    Extension = fileInfo.Extension,
                    LastAccessTime = File.GetLastAccessTime(filePath).ToString("dd MMM yyyy, HH:mm:ss"),
                    LastWriteTime = File.GetLastWriteTime(filePath).ToString("dd MMM yyyy, HH:mm:ss"),
                    Width = width,
                    Height = height,
                    FileSize = fileSizeInMegabytes.ToString("0.00") + "MB"
                };

                await dbContext.IMAGE_DETAILS.AddAsync(fileDetails);
                await dbContext.SaveChangesAsync();

                return fileDetails;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
