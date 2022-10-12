using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private LevelSettings levelSettings;

    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private GameObject previousButton;
    [SerializeField] private GameObject nextButton;

    private void Start()
    {
        LoadPage();
        Debug.Log(GetMaxPageCount());
    }

    public void NextPage()
    {
        levelSettings.settings.currentPage++;
        LoadPage();
    }

    public void PreviousPage()
    {
        levelSettings.settings.currentPage--;
        LoadPage();
    }

    private void LoadPage()
    {
        // Delete all old levels
        foreach (Level level in GameObject.FindObjectsOfType<Level>())
        {
            Destroy(level.gameObject);
        }

        // Disable previous page button, if you're on the first page
        if (levelSettings.settings.currentPage == 1)
        {
            previousButton.SetActive(false);
        }
        else if (levelSettings.settings.currentPage > 1)
        {
            previousButton.SetActive(true);
        }

        // Disable next page button, if you're on the last page.
        if (levelSettings.settings.currentPage == GetMaxPageCount())
        {
            nextButton.SetActive(false);
        }
        else if (levelSettings.settings.currentPage <= GetMaxPageCount())
        {
            nextButton.SetActive(true);
        }

        // Load in all the levels & set their correct values
        foreach (LevelSaveData level in GetLevels())
        {
            GameObject levelGameObject = Instantiate(levelPrefab, transform.position, transform.rotation);
            levelGameObject.transform.SetParent(gameObject.transform, false);

            Level levelScript = levelGameObject.GetComponent<Level>();
            levelScript.id = level.id;
            levelScript.state = level.state;
            levelScript.scence = level.scence;
        }
    }

    // Get levels based on current page and levels per page from LevelSettings
    private IEnumerable<LevelSaveData> GetLevels()
    {
        return levelManager.levels.Skip((levelSettings.settings.currentPage - 1) *
            levelSettings.settings.levelsPerPage).Take(levelSettings.settings.levelsPerPage);
    }

    // Get max page
    private int GetMaxPageCount()
    {
        return Mathf.CeilToInt((float) levelManager.levels.Count / (float) levelSettings.settings.levelsPerPage);
    }
}
