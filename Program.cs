using static System.Console;
Title = "File Shredder";
while (true)
{
    string? path = ReadLine();
    if (path is null)
    {
        WriteLine("Path may not be null.");
        continue;
    }
    Stream stream = null!;
    try
    {
        stream = new FileStream(path, FileMode.Open, FileAccess.Write);
        WriteLine("File accessed. Shredding...");
        while (stream.Position < stream.Length)
        {
            stream.WriteByte(0);
        }

        WriteLine("File successfully shredded.");
    }
    catch (DirectoryNotFoundException)
    {
        WriteLine("ERROR: Directory not found.");
        WriteLine();
        continue;
    }
    catch (FileNotFoundException)
    {
        WriteLine("ERROR: File not found.");
        WriteLine();
        continue;
    }
    catch (UnauthorizedAccessException)
    {
        WriteLine("ERROR: Access denied.");
        WriteLine();
        continue;
    }
    catch (PathTooLongException)
    {
        WriteLine("ERROR: Path too long.");
        WriteLine();
        continue;
    }
    catch (IOException)
    {
        WriteLine("ERROR: An unrecognized I/O error occured.");
        WriteLine();
        continue;
    }
    catch
    {
        WriteLine("ERROR: An unrecognized error occured.");
        WriteLine();
        continue;
    }
    finally
    {
        stream?.Dispose();
    }
    WriteLine("Deleting file...");
    try
    {
        File.Delete(path);
        WriteLine("File deleted.");
    }
    catch (DirectoryNotFoundException)
    {
        WriteLine("ERROR: Directory not found.");
        WriteLine();
        continue;
    }
    catch (FileNotFoundException)
    {
        WriteLine("ERROR: File not found.");
        WriteLine();
        continue;
    }
    catch (UnauthorizedAccessException)
    {
        WriteLine("ERROR: Access denied.");
        WriteLine();
        continue;
    }
    catch (PathTooLongException)
    {
        WriteLine("ERROR: Path too long.");
        WriteLine();
        continue;
    }
    catch (IOException)
    {
        WriteLine("ERROR: An unrecognized I/O error occured.");
        WriteLine();
        continue;
    }
    catch
    {
        WriteLine("ERROR: An unrecognized error occured.");
        WriteLine();
        continue;
    }
    WriteLine();
}