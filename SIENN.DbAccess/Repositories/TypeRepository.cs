using SIENN.BusinessInterfaces;
using SIENN.DbAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIENN.DbAccess.Repositories
{
    public class TypeRepository : GenericRepository<TypeDTO>, ITypeRepository
    {
        public TypeRepository(SiennContext context) : base(context)
        { }
    }
}
