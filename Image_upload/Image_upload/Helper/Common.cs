﻿namespace Image_upload.Helper
{
    public static class Common
    {
        public static string GetStaticContentDirectory()
        {
            var result = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files\\");
            if (Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            return result;
        }

        public static string GetFilePath(string output)
        {
            var _GetStaticContentDirectory=GetStaticContentDirectory();
            var result=Path.Combine(_GetStaticContentDirectory, output);
            return result;
        }
    }
}
