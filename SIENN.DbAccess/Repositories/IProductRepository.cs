﻿using SIENN.BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public interface IProductRepository : IBaseRepository<ProductDTO>
    {
        //ProductDTO AddProduct(ProductDTO entity);
        IEnumerable<ProductDTO> Search(ProductSearchCriteria criteria);
    }
}
