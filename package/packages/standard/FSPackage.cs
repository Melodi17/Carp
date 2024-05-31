using Carp.objects.types;

namespace Carp.package.packages.standard;

public class FSPackage(IPackageResolver source) : EmbeddedPackage(source, "FS")
{
    /// <summary>
    /// Reads the content of a file at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the file. The path should be a string.</param>
    /// <returns>A CarpString containing the content of the file.</returns>
    /// <exception cref="FileNotFound">Thrown when the file does not exist.</exception>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    [PackageMember]
    public CarpString ReadFile(CarpString path)
    {
        string strPath = path.String().Native;

        if (!File.Exists(strPath))
            throw new FileNotFound(path);

        try
        {
            return new(File.ReadAllText(strPath));
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    /// <summary>
    /// Reads all lines from a file at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the file. The path should be a string.</param>
    /// <returns>A CarpCollection containing each line of the file as a CarpString.</returns>
    /// <exception cref="FileNotFound">Thrown when the file does not exist.</exception>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    [PackageMember]
    public CarpCollection ReadFileLines(CarpString path)
    {
        string strPath = path.String().Native;
        
        if (!File.Exists(strPath))
            throw new FileNotFound(path);
        
        try
        {
            return new(CarpString.Type, File.ReadAllLines(strPath)
                .Select(x => new CarpString(x)).ToArray());
        }
        catch (FileNotFoundException)
        {
            throw new FileNotFound(path);
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    /// <summary>
    /// Writes the specified content to a file at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the file. The path should be a string.</param>
    /// <param name="cont">A CarpString representing the content to write to the file.</param>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    [PackageMember]
    public void WriteFile(CarpString path, CarpString cont)
    {
        try
        {
            File.WriteAllText(path.String().Native, cont.String().Native);
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    /// <summary>
    /// Writes the specified lines to a file at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the file. The path should be a string.</param>
    /// <param name="cont">A CarpCollection representing the lines to write to the file. Each line should be a CarpString.</param>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    [PackageMember]
    public void WriteFileLines(CarpString path, CarpCollection cont)
    {
        try
        {
            File.WriteAllLines(path.String().Native,
                cont.Native.Select(x => x.String().Native).ToArray());
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    /// <summary>
    /// Checks if a file or directory exists at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to check. The path should be a string.</param>
    /// <returns>A CarpBool indicating whether the file or directory exists.</returns>
    [PackageMember]
    public CarpBool Exists(CarpString path)
    {
        return CarpBool.Of(File.Exists(path.String().Native));
    }

    /// <summary>
    /// Deletes a file at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the file to delete. The path should be a string.</param>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    [PackageMember]
    public void Delete(CarpString path)
    {
        try
        {
            File.Delete(path.String().Native);
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    /// <summary>
    /// Creates a directory at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the directory to create. The path should be a string.</param>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    [PackageMember]
    public void CreateDir(CarpString path)
    {
        try
        {
            Directory.CreateDirectory(path.String().Native);
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    /// <summary>
    /// Deletes a directory at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the directory to delete. The path should be a string.</param>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    [PackageMember]
    public void DeleteDir(CarpString path)
    {
        try
        {
            Directory.Delete(path.String().Native, true);
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    /// <summary>
    /// Lists all files in a directory at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the directory. The path should be a string.</param>
    /// <returns>A CarpCollection containing the paths to each file in the directory as a CarpString.</returns>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    /// <exception cref="DirectoryNotFound">Thrown when the directory does not exist.</exception>
    [PackageMember]
    public CarpCollection ListDir(CarpString path)
    {
        string strPath = path.String().Native;
        
        if (!Directory.Exists(strPath))
            throw new DirectoryNotFound(path);
        
        try
        {
            return new(CarpString.Type,
                Directory.GetFiles(strPath).Select(x => new CarpString(x)).ToArray());
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    /// <summary>
    /// Lists all directories in a directory at the given path.
    /// </summary>
    /// <param name="path">A CarpString representing the path to the directory. The path should be a string.</param>
    /// <returns>A CarpCollection containing the paths to each subdirectory in the directory as a CarpString.</returns>
    /// <exception cref="IOError">Thrown when an I/O error occurs.</exception>
    /// <exception cref="DirectoryNotFound">Thrown when the directory does not exist.</exception>
    [PackageMember]
    public CarpCollection ListDirs(CarpString path)
    {
        string strPath = path.String().Native;
        
        if (!Directory.Exists(strPath))
            throw new DirectoryNotFound(path);
        
        try
        {
            return new(CarpString.Type,
                Directory.GetDirectories(strPath).Select(x => new CarpString(x)).ToArray());
        }
        catch (Exception)
        {
            throw new IOError(path);
        }
    }

    public class FileNotFound(CarpString path) : CarpError($"File '{path}' not found");
    public class DirectoryNotFound(CarpString path) : CarpError($"Directory '{path}' not found");
    public class IOError(CarpString path) : CarpError($"Error interfacing with IO for '{path}'");
}