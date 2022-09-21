using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public abstract class Configuration<T>
{
    private string fileName;

    private string filePath;

    public Configuration(string fileName)
    {
        this.fileName = fileName;
        this.filePath = Application.persistentDataPath + Path.DirectorySeparatorChar + fileName;

        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }
    }

    public T load()
    {
        using (StreamReader sr = new StreamReader(filePath))
        {
            return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
        }
    }

    public void save(T data)
    {
        using (StreamWriter sw = new StreamWriter(filePath)) {
            sw.Write(JsonConvert.SerializeObject(data));
        }
    }

    public string getFileName()
    {
        return fileName;
    }

    public string getFilePath()
    {
        return filePath;
    }
}
