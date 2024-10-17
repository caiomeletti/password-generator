using AutoMapper;
using PwdGen.API.ViewModels;
using PwdGen.Services.DTO;

namespace PwdGen.API.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreatePasswordViewModel, PasswordDTO>();

            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
