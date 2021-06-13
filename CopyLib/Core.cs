using System;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CopyLib
{
    public class Core : ICore
    {
        public Core()
        {
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
        }

        public async Task<string> copyDirAsync(string sourcePath, string destinationPath)
        {
            try
            {
                Debug.Print("Validating Inputs");
                ValidationUtil.validateNotNullAndEmpty(sourcePath);
                ValidationUtil.validateNotNullAndEmpty(destinationPath);
                ValidationUtil.validateIsPathValid(sourcePath);

                //Create all directories if missing in destination path
                Debug.Print("Creating missing Directories..");
                foreach (string dir in Directory.GetDirectories(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    Directory.CreateDirectory(dir.Replace(sourcePath, destinationPath));
                }
                Trace.WriteLine("Missing Directories Created.");
                //Copying and replace files
                Trace.WriteLine($"Copying Files from Folder : {sourcePath} to Folder : {destinationPath}");
                foreach (string file in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                {
                    //File.Copy(file, file.Replace(sourcePath, destinationPath), true);
                    using (FileStream fileSourceStream = File.Open(file, FileMode.Open))
                    {
                        using (FileStream fileDestinatonStream = File.Create(file.Replace(sourcePath, destinationPath)))
                        {
                            await fileSourceStream.CopyToAsync(fileDestinatonStream);
                            // callback($"Copied file: {file} from Folder : {sourcePath} to Folder : {destinationPath}");
                        }
                    }
                    Trace.WriteLine($"Copied file: {file}");
                }
                return "Copy complete.";


            }
            catch (NullReferenceException err)
            {
                Trace.WriteLine(err.Message);
                return err.Message;
            }
            catch (FileNotFoundException err)
            {
                Trace.WriteLine(err.Message);
                return err.Message;
            }
        }

    }

}
