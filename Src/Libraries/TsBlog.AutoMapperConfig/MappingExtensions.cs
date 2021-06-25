using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TsBlog.Domain.Entities;
using TsBlog.ViewModel.Post;
using AutoMapper;

namespace TsBlog.AutoMapperConfig
{
    public static class MappingExtensions
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            return AutoMapperConfiguration.Mapper.Map<TSource, TDestination>(source, destination);
        }

        public static PostViewModel ToModel(this Post entity)
        {
            return entity.MapTo<Post, PostViewModel>();
        }

        public static Post ToEntity(this PostViewModel model)
        {
            return model.MapTo<PostViewModel, Post>();
        }
    }
}
