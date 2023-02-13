using AutoMapper;
using Nop.Core.Domain.Catalog;
using Nop.Core.Infrastructure.Mapper;
using Sync = Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Models.Sync;

namespace Nop.Plugin.Misc.SyncCatalog.Areas.Admin.Infrastructure.Mapper
{
    public class MapperConfiguration : Profile, IOrderedMapperProfile
    {
        #region Ctor

        public MapperConfiguration()
        {
            #region Catalog

            CreateMap<Category, Sync.Category>()
                 .ReverseMap();  
            
            CreateMap<Product, Sync.ProductSync>()
                 .ReverseMap();

            #endregion

        }



        #endregion

        #region Properties

        /// <summary>
        /// Order of this mapper implementation
        /// </summary>
        public int Order => 1;

        #endregion
    }
}
