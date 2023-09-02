using System;
using System.IO;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
namespace InputHelpers
{
    public static class FileInputHelper
    {
        public static string ReadJsonFile(string message)
        {
            while (true)
            {
                string filePath = ReadInputHelper.GetStringInput(message);

                if (IsFilePathValidJson(filePath))
                {
                    return filePath;
                }
                else
                {
                    Console.WriteLine("Invalid JSON file path or format. Please enter a valid JSON file path.");
                }
            }
        }

        private static bool IsFilePathValidJson(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);
                    JToken.Parse(jsonContent);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static string ReadXmlFile(string message)
        {
            while (true)
            {
                string filePath = ReadInputHelper.GetStringInput(message);

                if (IsFilePathValidXml(filePath))
                {
                    return filePath;
                }
                else
                {
                    Console.WriteLine("Invalid XML file path or format. Please enter a valid XML file path.");
                }
            }
        }

        private static bool IsFilePathValidXml(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    XDocument.Load(filePath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}