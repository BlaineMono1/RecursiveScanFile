using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{

    public class DataRecordingRead
    {
        RecursiveScanFiles scan_file = new RecursiveScanFiles();

        string output_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MyFaile.txt");
        bool Arg_q = false;

        public void Path_O(string t)
        {
            output_path = t;
        }
        public void Arg_quite(bool n)
        {
            Arg_q= n;
        }

        public void DataCR(string txt, long MaxSize)
        {
            try
            {
                if (Arg_q == true)
                {
                    using (StreamWriter sw = new StreamWriter(output_path))
                    {
                        sw.WriteLine("|Overall size| " + scan_file.FormatBytes(MaxSize).ToString());

                        sw.WriteLine(txt);

                    }

                }
                else if (Arg_q ==false)
                {

                    using (StreamWriter sw = new StreamWriter(output_path))
                    {
                        sw.WriteLine("|Overall size| " + scan_file.FormatBytes(MaxSize).ToString());

                        sw.WriteLine(txt);

                    }
                    Console.WriteLine("|Overall size| " + scan_file.FormatBytes(MaxSize).ToString());
                    Console.WriteLine(txt);



                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }


    }
}
