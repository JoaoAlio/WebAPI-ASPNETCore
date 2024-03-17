using AutoMapper;
using Dto;
using Models;

namespace Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tarefas, TarefasDto>();
            CreateMap<Usuario, UsuarioDto>();   
            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaRank, CategoriaRankDto>();
            CreateMap<TarefasDto, Tarefas>();
            CreateMap<UsuarioDto, Usuario>();
            CreateMap<CategoriaDto, Categoria>();
            CreateMap<CategoriaRankDto, CategoriaRank>();
        }
    }
}
