using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public abstract class Configuration<T> : ScriptableObject
{
    private string _fileName;
    private string _filePath;

    //Initialize method to setup configuration files properly
    protected void Init(string fileName)
    {
        // Make sure the user has supplied a file name
        if (string.IsNullOrEmpty(fileName))
        {
            Debug.LogError("The variable 'File Name' has not been set");
        }

        // Set _fileName
        _fileName = fileName;

        if (Application.isEditor)
        {
            // Ensure that the file path exists, if not, create it
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath).Close();
            }

            // Set _filePath location while in editor
            _filePath = Path.Combine(Application.streamingAssetsPath, _fileName);
        }
        else
        {
            // Copy over data
            CopyData(Path.Combine(Application.streamingAssetsPath, _fileName),
                Path.Combine(Application.persistentDataPath, _fileName));

            // Set _filePath location during build
            _filePath = Path.Combine(Application.persistentDataPath, _fileName);
        }
    }

    // Load the data from the file path
    protected T Load()
    {
        using (StreamReader sr = new StreamReader(_filePath))
        {
            return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
        }
    }

    // Save the provided data
    protected void Save(T data)
    {
        using (StreamWriter sw = new StreamWriter(_filePath))
        {
            sw.Write(JsonConvert.SerializeObject(data));
        }
    }

    /**
     * Copy the data from one file location to another,
     * this resolves the READ-ONLY issue of the StreamingAssets file location
     * 
     * TO-DO:
     *   - Implement some sort of update system, that way if new levels are added
     *     your old data stays relevant and is updated accordingly
    **/
    protected void CopyData(string originalFilePath, string copiedFilePath)
    {
        if (File.Exists(originalFilePath) && !File.Exists(copiedFilePath))
        {
            T copiedData;

            if (Application.platform == RuntimePlatform.Android)
            {
                // Load data up using WebRequest, ANDRIOD ONLY
                using (UnityWebRequest webRequest = UnityWebRequest.Get(originalFilePath))
                {
                    webRequest.SendWebRequest();
                    copiedData = JsonConvert.DeserializeObject<T>(webRequest.downloadHandler.text);
                }
            } else
            {
                // Load data up using Stream Reader
                using (StreamReader sr = new StreamReader(originalFilePath))
                {
                    copiedData = JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
                }
            }

            // Copy loaded data to a different location
            using (StreamWriter sw = new StreamWriter(copiedFilePath))
            {
                sw.Write(JsonConvert.SerializeObject(copiedData));
            }
        }
    }

    // Returns the name of the file
    public string GetFileName()
    {
        return _fileName;
    }

    // Returns the location of the file
    public string GetFilePath()
    {
        return _filePath;
    }
}
