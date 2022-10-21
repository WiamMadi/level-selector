[System.Serializable]
public class LevelSettingsData
{
    public int currentPage;
    public int levelsPerPage;
    public bool saveCurrentPagePosition;

    public LevelSettingsData(int currentPage, int levelsPerPage, bool saveCurrentPagePosition)
    {
        this.currentPage = currentPage;
        this.levelsPerPage = levelsPerPage;
        this.saveCurrentPagePosition = saveCurrentPagePosition;
    }
}
