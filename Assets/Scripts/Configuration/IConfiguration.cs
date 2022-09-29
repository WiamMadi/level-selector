public interface IConfiguration<T>
{
    public string FileName { get; set; }

    public string FilePath { get; set; }

    T Load();

    void Save();
}
