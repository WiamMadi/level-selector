using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

[CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObjects/Levels")]
public class LevelManager : ScriptableObject, IConfiguration<List<LevelSaveData>>
{
    [SerializeField] private string _fileName;
    [SerializeField] private string _filePath;

    public string FileName { 
        get { return _fileName; } 
        set { _fileName = value; }
    }

    public string FilePath
    {
        get { return _filePath; }
        set { _filePath = value; }
    }

    public List<LevelSaveData> levels;

    private void OnEnable()
    {
        // Make sure the user has supplied a file name
        if (string.IsNullOrEmpty(_fileName))
        {
            Debug.LogError("The variable 'File Name' has not been set");
        }

        _filePath = Path.Combine(Application.streamingAssetsPath, _fileName);

        // Ensure that the file path exists, if not, create it
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Close();
        }

        // Load in levels
        levels = Load() ?? new List<LevelSaveData>();
    }

    private void OnValidate()
    {
        Save();
    }

    public IEnumerable<LevelSaveData> GetLevels(int pageNumber, int pageLimit)
    {
        return levels.Skip((pageNumber - 1) * pageLimit).Take(pageLimit);
    }

    public List<LevelSaveData> Load()
    {
        using (StreamReader sr = new StreamReader(_filePath))
        {
            return JsonConvert.DeserializeObject<List<LevelSaveData>>(sr.ReadToEnd());
        }
    }

    public void Save()
    {
        using (StreamWriter sw = new StreamWriter(_filePath))
        {
            sw.Write(JsonConvert.SerializeObject(levels));
        }
    }
}
