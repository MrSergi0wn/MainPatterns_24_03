﻿using System.IO;

namespace SpaceBattle.FileSystemService
{
    public static class DirectoryManager
    {
        public static string GetCurrent()
        {
            return Directory.GetCurrentDirectory();
        }

        public static void Create(string directory)
        {
            Directory.CreateDirectory(directory);
        }
    }
}
