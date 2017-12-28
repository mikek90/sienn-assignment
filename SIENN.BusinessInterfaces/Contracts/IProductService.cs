using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.BusinessInterfaces.Contracts
{
    public interface IProductService : IBaseCrudService<ProductDTO>
    {
        ProductDTO GetDetailed(int id);
        IEnumerable<ProductDTO> GetAvailable(int pageNo, int itemsCount);
        IEnumerable<ProductDTO> Search(ProductSearchCriteria criteria);
    }
}
