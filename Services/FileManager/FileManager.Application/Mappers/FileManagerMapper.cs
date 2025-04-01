using AutoMapper;

namespace FileManager.Application.Mappers
{
    public class FileManagerMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(static () =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<FileManagerMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
