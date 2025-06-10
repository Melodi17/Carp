namespace Carp.libraries.std.io;

using exceptions;
using utils;

[Doc("Standard library class for filesystem operations.")]
public static class Storage
{
    [Doc("Returns the current working directory.")]
    public static string Current => Directory.GetCurrentDirectory();
    
    [Doc("Reads the content of a file at the specified path.")]
    public static string Read(string path)
    {
        try
        {
            return File.ReadAllText(path);
        }
        catch (FileNotFoundException)
        {
            throw new PathNotFoundException(path);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error reading file at '{path}': {ex.Message}");
        }
    }
    
    [Doc("Writes the specified content to a file at the given path, overwriting any existing content"
         + " and creating the file if it does not exist.")]
    public static void Write(string path, string content)
    {
        try
        {
            File.WriteAllText(path, content);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error writing to file at '{path}': {ex.Message}");
        }
    }
    
    [Doc("Reads the content of a file at the specified path as bytes.")]
    public static byte[] ReadData(string path)
    {
        try
        {
            return File.ReadAllBytes(path);
        }
        catch (FileNotFoundException)
        {
            throw new PathNotFoundException(path);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error reading data from '{path}': {ex.Message}");
        }
    }
    
    [Doc("Writes the specified byte array to a file at the given path, overwriting any existing content"
         + " and creating the file if it does not exist.")]
    public static void WriteData(string path, byte[] data)
    {
        try
        {
            File.WriteAllBytes(path, data);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error writing data to '{path}': {ex.Message}");
        }
    }
    
    [Doc("Checks if the specified path exists, either as a file or a directory.")]
    public static bool Exists(string path) => File.Exists(path) || Directory.Exists(path);
    
    [Doc("Checks if the specified path is a directory.")]
    public static bool IsDirectory(string path) => Directory.Exists(path);
    
    [Doc("Checks if the specified path is a file.")]
    public static bool IsFile(string path) => File.Exists(path);

    [Doc("Deletes the specified path, which can be either a file or a directory. If the path is a directory,"
         + " it will delete all contents recursively.")]
    public static void Delete(string path)
    {
        try
        {
            if (File.Exists(path))
                File.Delete(path);
            else if (Directory.Exists(path))
                Directory.Delete(path, true);
            else
                throw new PathNotFoundException(path);
        }
        catch (RuntimeException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error deleting path '{path}': {ex.Message}");
        }
    }
    
    [Doc("Lists all files and directories in the specified path. Returns an array of strings containing"
         + " the names of files and directories.")]
    public static string[] ListContents(string path)
    {
        try
        {
            if (!Directory.Exists(path))
                throw new PathNotFoundException(path);
            
            return Directory.GetFiles(path).Concat(Directory.GetDirectories(path)).ToArray();
        }
        catch (RuntimeException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error listing contents of '{path}': {ex.Message}");
        }
    }
    
    [Doc("Lists only files in the specified path. Returns an array of strings containing"
         + " the names of files.")]
    public static string[] ListFiles(string path)
    {
        try
        {
            if (!Directory.Exists(path))
                throw new PathNotFoundException(path);
            
            return Directory.GetFiles(path);
        }
        catch (RuntimeException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error listing files in '{path}': {ex.Message}");
        }
    }

    [Doc("Lists only directories in the specified path. Returns an array of strings containing"
         + " the names of directories.")]
    public static string[] ListDirectories(string path)
    {
        try
        {
            if (!Directory.Exists(path))
                throw new PathNotFoundException(path);

            return Directory.GetDirectories(path);
        }
        catch (RuntimeException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error listing directories in '{path}': {ex.Message}");
        }
    }
    
    [Doc("Creates a new directory at the specified path. If the directory already exists, it does nothing.")]
    public static void CreateDirectory(string path)
    {
        try
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }
        catch (Exception ex)
        {
            throw new RuntimeException($"Error creating directory at '{path}': {ex.Message}");
        }
    }
}

public class PathNotFoundException(string path) 
    : RuntimeException($"Path '{path}' not found.");