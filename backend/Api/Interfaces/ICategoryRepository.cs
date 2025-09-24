using Domain.Database;

namespace Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryModel> List();
    }
}