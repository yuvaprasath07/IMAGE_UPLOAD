using Image_upload.Model;

namespace Image_upload.Service
{
    public interface Imanageimage
    {
        Task<DetailsModel> UploadFile(IFormFile Files);
    }
}
