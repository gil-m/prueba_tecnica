using Database;
using Domain.Database;

namespace Repositories.Translator;

public static class ProductTranslator
{
    public static ProductModel ToModel(this Product entity)
        => new(entity.Id, entity.Name, entity.CategoryId, entity.Category.Name);

    public static Product ToEntity(this ProductModel model)
        => new() { Id = model.Id, Name = model.Name, CategoryId = model.CategoryId };

    public static void GetValues(this Product entity, ProductModel model)
    {
        entity.Id = model.Id;
        entity.Name = model.Name;
        entity.CategoryId = model.CategoryId;
    }
}
