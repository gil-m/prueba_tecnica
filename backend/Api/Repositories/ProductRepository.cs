using Database;
using Domain.Database;
using Repositories.Translator;

namespace Repositories;

public class ProductRepository(LocalContext localContext)
{
    public List<ProductModel> List()
        => [.. localContext.Products.Select(x => x.ToModel())];

    public ProductModel? Find(int id)
        => localContext.Products.Find(id)?.ToModel();

    public ProductModel? Create(ProductModel model)
    {
        var entity = model.ToEntity();
        localContext.Products.Add(entity);
        localContext.SaveChanges();
        return entity.ToModel();
    }

    public ProductModel? Update (ProductModel model)
    {
        var entity = localContext.Products.Find(model.Id);

        if (entity is null)
            return null;

        entity.GetValues(model);

        localContext.Update(entity);
        localContext.SaveChanges();

        return entity.ToModel();
    }

    public ProductModel? Remove(int id)
    {
        var entity = localContext.Products.Find(id);

        if (entity is null)
            return null;

        localContext.Remove(entity);
        localContext.SaveChanges();

        return entity.ToModel();
    }
}
