namespace CarstoreApi.Repositories
  
{
    //تعريف الواجهة العامة وتحتوي على اهم العمليات 
    public interface IGenericRepository<T> 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
        T Create ( T obj );
        void Update (int id ,  T obj );
        void Delete (int id );
    }
}
