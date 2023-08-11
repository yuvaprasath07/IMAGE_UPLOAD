using System.ComponentModel.DataAnnotations;

namespace Image_upload.Model
{
    public class DetailsModel
    {
        [Key]
        public string? FileName { get; set; }
        public string? FullPath { get; set; }
        public string? DirectoryName { get; set; }
        public string? FileSize { get; set; }
        public string? Extension { get; set; }
        public string? LastAccessTime { get; set; }
        public string? LastWriteTime { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
