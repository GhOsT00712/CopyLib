using System;
using System.IO;
namespace CopyLib
{
    public static class ValidationUtil
    {
        public static void validateNotNullAndEmpty(string path)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
            {
                throw new NullReferenceException("Invalid path");
            }
        }

        public static void validateIsPathValid(string path)
        {

            if (!Directory.Exists(path))
            {
                throw new FileNotFoundException($"{path} location not found");
            }
        }
    }
}