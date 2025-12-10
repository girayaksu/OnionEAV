using OnionEAV.Contract.RepositoryInterfaces;
using OnionEAV.Domain.Entities;
using OnionEAV.Persistence.ContextClasses;

namespace OnionEAV.Persistence.RepositoryConcretes
{
    public class ProductAttributeValueRepository : BaseRepository<ProductAttributeValue>, IProductAttributeValueRepository
    {
        public ProductAttributeValueRepository(MyContext context) : base(context)
        {
        }
    }
}
