using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public  class RecursiveScanFiles
    {
        
        public string path_dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
        public  string Text = "";
        


      public  bool arg_humanread = false;
        //Задает путь к папке через аргументы командной строки
        public void Path_Dir(string p)
        {
            path_dir = p;
        }


        public void Args_Humanread(bool h)
        {
            arg_humanread = h;
        }

        public  long SearchFolderSize(string folder, bool Arg_H)
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(folder);
                FileInfo[] files = di.GetFiles();
                DirectoryInfo[] dirs = di.GetDirectories();
                long foldersize = 0;

                foreach (FileInfo file in files)
                {
                    foldersize += file.Length;

                }

                if (Arg_H == true)
                {
                    Text += $"FOLDER: {folder}: ({FormatBytes(foldersize)})" + "\n";
                    foreach (FileInfo file in files)
                    {
                        Text += $"--{file.Name}: ({FormatBytes(file.Length)})" + "\n";
                    }
                }
                else
                {
                    Text += $"FOLDER: {folder}: ({foldersize})" + "\n";
                    foreach (FileInfo file in files)
                    {
                        Text += $"--{file.Name}: ({file.Length})" + "\n";
                    }

                }



                foreach (DirectoryInfo dir in dirs)
                {
                    foldersize += SearchFolderSize(dir.FullName, arg_humanread);

                }
                return foldersize;

            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Директория не найдена. Ошибка: " + ex.Message);
                return 0;
            }
            catch(UnauthorizedAccessException ex)
            {
                Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                return 0;

            }
            catch(Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
                return 0;
            }








        }

        public  string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }



    }
}

