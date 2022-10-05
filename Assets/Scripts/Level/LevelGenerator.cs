using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private int levelsPerPage;

    private int currentPage = 1;

    private void Start()
    {
        LoadPage();
    }

    public void NextPage()
    {
        currentPage++;
        LoadPage();
    }

    public void PreviousPage()
    {
        currentPage--;
        LoadPage();
    }

    private void LoadPage()
    {
        //Delete previous buttons
        Level[] oldLevels = GameObject.FindObjectsOfType<Level>();

        foreach (Level level in oldLevels)
        {
            Destroy(level.gameObject);
        }

        foreach (LevelSaveData level in levelManager.GetLevels(currentPage, levelsPerPage))
        {
            GameObject levelGameObject = Instantiate(levelPrefab, transform.position, transform.rotation);
            levelGameObject.transform.SetParent(gameObject.transform, false);

            Level levelScript = levelGameObject.GetComponent<Level>();
            levelScript.id = level.id;
            levelScript.state = level.state;
            levelScript.scence = level.scence;
        }
    }
}
