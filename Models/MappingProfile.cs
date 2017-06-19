using AutoMapper;
using BlogApp.Entities;
using BlogApp.Models.Shared;

namespace BlogApp.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.User, UserLayoutModel>();
            
            CreateBiMap<Blog.CreateOrUpdateModel, Entities.Blog>();
            CreateMap<Entities.User,Blog.IndexEntryAuthorModel>();
            CreateMap<Entities.Blog,Blog.IndexEntryModel>();
            CreateMap<Entities.Blog,Blog.ViewModel>();
            CreateMap<Entities.User,Blog.ViewAuthorModel>();
            CreateMap<Entities.Post,Blog.ViewPostModel>();
            
            CreateBiMap<Post.CreateOrUpdateModel, Entities.Post>();
            CreateMap<Entities.Post,Post.ViewModel>();
        }

        private void CreateBiMap<T1, T2>()
        {
            CreateMap<T1, T2>();
            CreateMap<T2, T1>();
        }
    }
}