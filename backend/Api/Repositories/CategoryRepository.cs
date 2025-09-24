using Database;
using Domain.Database;
using Repositories.Translator;

namespace Repositories;

public class CategoryRepository(LocalContext localContext) : ICategoryRepository
{
    public List<CategoryModel> List()
        => [.. localContext.Categories.Select(x => x.ToModel())];
}
