WebZip
======

Download multiple files from web 



using  DotNetZip http://dotnetzip.codeplex.com/  

Firstly, Zip some files to a zip file, then download the zip

Eample


 string ZipFileToCreate = Server.MapPath(@"~/ZIP/download.zip");
            string DirectoryToZip = Server.MapPath(@"~/PDF/");

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    // note: this does not recurse directories! 
                    String[] filenames = System.IO.Directory.GetFiles(DirectoryToZip);

                    // This is just a sample, provided to illustrate the DotNetZip interface.  
                    // This logic does not recurse through sub-directories.
                    // If you are zipping up a directory, you may want to see the AddDirectory() method, 
                    // which operates recursively. 
                    foreach (String filename in filenames)
                    {
                        Console.WriteLine("Adding {0}...", filename);
                        ZipEntry e = zip.AddFile(filename, "");
                        e.Comment = "Added by Cheeso's CreateZip utility.";
                    }

                    zip.Comment = String.Format("This zip archive was created by the CreateZip example application on machine '{0}'",
                       System.Net.Dns.GetHostName());

                    zip.Save(ZipFileToCreate);
                }

            }
            catch (System.Exception ex1)
            {
                System.Console.Error.WriteLine("exception: " + ex1);
            }

            Response.Clear();
            //Response.ClearContent();
            //Response.ClearHeaders();
            //Response.Buffer = true;
            Response.AppendHeader("Content-Disposition", "attachment; filename=VAU.zip");
            //Response.AppendHeader("Content-Cength", file.Length.ToString());
            Response.ContentType = "application/x-zip-compressed";
            Response.WriteFile(ZipFileToCreate);
            //Response.Flush();
            Response.End();
