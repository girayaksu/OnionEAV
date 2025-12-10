using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
using OnionEAV.Persistence.ContextClasses;

namespace OnionEAV.Persistence.RepositoryConcretes
{
    public class ProductAttributeRepository : BaseRepository<ProductAttribute>, IProductAttributeRepository
    {
        public ProductAttributeRepository(MyContext context) : base(context)
        {
        }
    }
}
