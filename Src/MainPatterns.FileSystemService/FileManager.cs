using System;
using System.IO;

namespace MainPatterns.FileSystemService
{
    public static class FileManager
    {
        public static string GetFilePath(Type type)
        {
            return $@"..\..\..\..\Adapters\{type.Name}Adapter.cs";
        }

        public static void Create(string filePath)
        {
            try
            {
                if (CheckExistFile(filePath))
                {
                    File.Create(filePath);
                }
            }
            catch
            {
                throw new Exception("Ну удалось создать файл!");
            }
        }

        public static string Read(string filePath)
        {
            var content = string.Empty;

            if (!CheckExistFile(filePath)) return content;
            try
            {
                using var reader = new StreamReader(filePath);
                content = reader.ReadToEnd();
            }
            catch
            {
                throw new Exception("Данный файл не может быть прочитан!");
            }

            return content;
        }

        public static bool Save(string content, string filePath)
        {
            if (!CheckExistFile(filePath)) return false;
            try
            {
                using var writer = new StreamWriter(filePath, false);
                writer.Write(content);

                return true;
            }
            catch
            {
                throw new Exception("Не удалось записать данные в файл!");
            }
        }

        public static bool CheckExistFile(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
