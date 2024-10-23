using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp;

public class FileDeDuplicator
{
    private Dictionary<string, string> _hashToPath = new Dictionary<string, string>();
    public void RemoveDuplicateFile(string directoryPath)
    {
        Console.WriteLine($"processing file {directoryPath}");
        _hashToPath.Clear();
        var subDirectories = Directory.GetDirectories(directoryPath);

        foreach (var directory in subDirectories)
        {
            RemoveDuplicateFile(directory);
        }

        var files = Directory.GetFiles(directoryPath);
        foreach (var file in files)
        {
            var md5Hash = GetMD5(file);
            if (_hashToPath.ContainsKey(md5Hash))
            {
                File.Delete(file);
                Console.WriteLine($"Deleted duplicate file: {file}");
            }
            else
            {
                _hashToPath.Add(md5Hash, file);
            }
        }

    }

    public string GetMD5(string filename)
    {
        using (var md5 = MD5.Create())
        {
            return Encoding.Default.GetString(md5.ComputeHash(File.ReadAllBytes(filename)));
        }
    }
}
