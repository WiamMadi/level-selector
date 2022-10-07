using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public abstract class Configuration<T> : ScriptableObject
{
    private string _fileName;
    private string _filePath;

    //Initialize method to set fileName and filePath
    public void Init(string fileName)
    {
        // Make sure the user has supplied a file name
        if (string.IsNullOrEmpty(fileName))
        {
            Debug.LogError("The variable 'File Name' has not been set");
        }

        // Set _fileName
        _fileName = fileName;

        // Set _filePath
        _filePath = Path.Combine(Application.streamingAssetsPath, _fileName);

        // Ensure that the file path exists, if not, create it
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Close();
        }
    }

    public T Load()
    {
        using (StreamReader sr = new StreamReader(_filePath))
        {
            return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
        }
    }

    public void Save(T data)
    {
        using (StreamWriter sw = new StreamWriter(_filePath))
        {
            sw.Write(JsonConvert.SerializeObject(data));
        }
    }

    public string GetFileName()
    {
        return _fileName;
    }

    public string GetFilePath()
    {
        return _filePath;
    }
}
