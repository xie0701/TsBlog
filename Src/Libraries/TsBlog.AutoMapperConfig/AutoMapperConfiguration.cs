using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TsBlog.Domain.Entities;
using TsBlog.ViewModel.Post;

namespace TsBlog.AutoMapperConfig
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper {get;private set;}

        public static MapperConfiguration MapperConfiguration{get;private set;}
        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>{
                cfg.CreateMap<Post, PostViewModel>().ForMember(d => d.IsDeleted, d => d.MapFrom(s => s.IsDeleted ? "是" : "否"));
                cfg.CreateMap<PostViewModel, Post>();
            });
            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}
