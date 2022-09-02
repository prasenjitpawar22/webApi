

namespace MyWebAPICore.Repositories;

// public interface IGuid
// {
//     public Guid id { get; set; }
// }

public interface IRespository<T1, T2, T3> where T1 : class where T2 : class
{
    Task<IEnumerable<T1>> GetAllAction();

    Task<T1> GetSingleAction(T3 id);

    Task<T1> AddAction(T2 entity);

    Task<T1> DeleteAction(T3 id);

    Task<T1> UpdateAction(T3 id, T2 entity);

    Task SaveAction();
}