using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BullySquasher.DTOs;
using BullySquasher.Models;

namespace BullySquasher.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Child, ChildDto>();
            Mapper.CreateMap<Parent, ParentDto>();


        }
    }
}