using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public abstract class Configuration<T>
{
    // File name for where the data will be stored
    private string fileName;

    // The path to where the file is located
    private string filePath;

    public Configuration(string fileName)
    {
        this.fileName = fileName;
        filePath = Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;

        // Ensure that the file path exists, if not, create it
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }
    }

    // Load the data from the JSON file
    public T load()
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
        }
    }

    // Save the data to a JSON file
    public void save(T data)
    {
        using (StreamWriter sw = new StreamWriter(filePath)) {
            sw.Write(JsonConvert.SerializeObject(data));
        }
    }

    // Grabs the name of the file
    public string getFileName()
    {
        return fileName;
    }

    // Grabs the file path
    public string getFilePath()
    {
        return filePath;
    }
}
