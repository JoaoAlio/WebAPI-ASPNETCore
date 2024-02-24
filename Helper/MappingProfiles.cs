﻿using AutoMapper;
using Dto;
using Models;

namespace Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tarefas, TarefasDto>();
        }
    }
}
