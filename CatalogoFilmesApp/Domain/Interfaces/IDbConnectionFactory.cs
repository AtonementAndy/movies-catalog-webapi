using System.Data;

namespace CatalogoFilmesApp.Domain.Interfaces
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
