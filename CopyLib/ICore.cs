using System.Threading.Tasks;
using System;
namespace CopyLib
{
    public interface ICore
    {
        public Task<string> copyDirAsync(string sourcePath, string destinationPath);
    }
}

