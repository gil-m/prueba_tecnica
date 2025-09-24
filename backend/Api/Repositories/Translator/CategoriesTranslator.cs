using Database;
using Domain.Database;

namespace Repositories.Translator;

internal static class CategoriesTranslator
{
    public static CategoryModel ToModel(this Category entity)
        => new(entity.Id, entity.Name);
}
