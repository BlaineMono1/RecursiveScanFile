
using Code;
RecursiveScanFiles scan_file = new RecursiveScanFiles();
DataRecordingRead data_recording_read = new DataRecordingRead();
long MaxSize=0; 

 if (args.Length > 0)
    {
        for (int i = 0; i < args.Length; i++)
        {
            try
            {

                if (args[i] == "-p" || args[i] == "--path")
                {
                    // Путь записывается через пробел после праметра"-p"
                    scan_file.Path_Dir(args[i + 1]);
                   
                }
               
                else if (args[i] == "-h" || args[i] == "--humanread")
                {

                    scan_file.Args_Humanread(true);

                }
               
                else if (args[i] == "-q" || args[i] == "--quite")
                {
                    data_recording_read.Arg_quite(true);
                }
               
                else if (args[i] == "-o" || args[i] == "--output")
                {
                    data_recording_read.Path_O(args[i + 1]);
                }
              
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



        }
    
    MaxSize+= scan_file.SearchFolderSize(scan_file.path_dir, scan_file.arg_humanread);
    data_recording_read.DataCR(scan_file.Text, MaxSize);


}
 else
 {
    MaxSize += scan_file.SearchFolderSize(scan_file.path_dir, scan_file.arg_humanread);

        data_recording_read.DataCR(scan_file.Text, MaxSize);
 }



