//css_ref System.Xml.dll;
//css_ref System.Xml.Linq.dll;
//css_ref System.IO.dll;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

public class MissingFileChecker
{
    static readonly XNamespace CsprojNamespace = XNamespace.Get("http://schemas.microsoft.com/developer/msbuild/2003");

    public static void Main(string[] args)
    {
        CheckFiles(args[0]);
    }

    public static string CheckFiles(string filename)
    {        
        var missingFiles = new List<string>();

        var fi = new FileInfo(filename);
        var xdoc = XDocument.Load(filename);

        foreach (var element in xdoc.Descendants(CsprojNamespace + "ItemGroup").Descendants().Where(x => x.Name == CsprojNamespace + "Content" | x.Name == CsprojNamespace + "Compile"))
        {
            var attribute = element.Attribute("Include");
            if(attribute != null)
            {
                string fileMustExist = attribute.Value;
                //the ' character which can occur in filenames is encoded in xml, and needs to be unencoded for comparison 
                fileMustExist = fileMustExist.Replace("%27", "'");
                var filePath = Path.Combine(fi.DirectoryName, fileMustExist);

                try
                {
                    if (!File.Exists(filePath))
                    {
                        missingFiles.Add(string.Format("Project: {0}, Filename: {1}", fi.Name, fileMustExist));
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Error");
                    System.Console.WriteLine(ex);
                }
            }
        }
        
        //If missingFiles.Count is bigger than 0, this means there are missing files
        //All missing files are then put into one fail output message
        if (missingFiles.Count > 0)
        {
            string output = "The following files are missing:" + Environment.NewLine;
            foreach (var missingFile in missingFiles)
            {
                output += missingFile + Environment.NewLine;
            }

            System.Console.WriteLine(output);
			throw new Exception();
        }

        return "";
    }
}