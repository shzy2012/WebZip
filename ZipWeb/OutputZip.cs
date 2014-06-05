/// <summary>
/// Summary description for OutputZip
/// </summary>
public class OutputZip
{
    public static void ResponseZip(System.Web.HttpResponse response, string ZipFileToCreate, List<string> files)
    {
        try
        {
            using (ZipFile zip = new ZipFile())
            {
                foreach (String filename in files)
                {
                    ZipEntry e = zip.AddFile(filename, "");
                    e.Comment = "Added by  VAU";
                }

                zip.Comment = String.Format("This zip archive was created by the CreateZip example application on machine '{0}'", System.Net.Dns.GetHostName());

                zip.Save(ZipFileToCreate);
            }

            response.Clear();
            response.AppendHeader("Content-Disposition", "attachment; filename=VAUFiles.zip");
            response.ContentType = "application/x-zip-compressed";
            response.WriteFile(ZipFileToCreate);
            response.Flush();
            response.Close();
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
    }
}
