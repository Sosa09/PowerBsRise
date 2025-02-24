using System;
using System.IO;
using System.Xml.Linq;

namespace PowerBsRise
{
    public class FileHandler
    {   
        StreamReader _streamReader;
        StreamWriter _streamWriter;
        public string GetContent(string file)
        {
            try
            {
                using (_streamReader = new StreamReader(file)) //keyword using ensures that the instance closes and don't block the file after finishing with it
                {
                    return _streamReader.ReadToEnd(); //return all character from start to end in the file
                }            
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException();
            }
        }
        public void SaveFile(string file, string content)
        {
            try
            {
                using (_streamWriter = new StreamWriter(file))
                {
                    _streamWriter.Write(content);
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (DirectoryNotFoundException)
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}