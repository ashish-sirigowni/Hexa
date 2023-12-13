namespace BookMyShowProjectNewAPI.Repo
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        bool Add(T item);
        bool Delete(T item);
        bool Update(int Id);
    }
}
