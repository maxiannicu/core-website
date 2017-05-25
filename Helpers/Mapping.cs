using BlogApp.Entities;
using BlogApp.Models;

namespace BlogApp.Helpers
{
    public static class Mapping
    {
        public static PostModel EntityToModel(Post entity)
        {
            return new PostModel
            {
                FullDescription = entity.FullDescription,
                Id = entity.Id,
                Title = entity.Title,
                ShortDescription = entity.ShortDescription
            };
        }

        public static BlogModel EntityToModel(Blog blog)
        {
            return new BlogModel
            {
                Id = blog.Id,
                Author = blog.Author,
                Title = blog.Title
            };
        }

        public static void ModelToEntity(BlogModel model, Blog entity)
        {
            entity.Author = model.Author;
            entity.Title = model.Title;
        }

        public static void ModelToEntity(PostModel model, Post entity)
        {
            entity.Title = model.Title;
            entity.ShortDescription = model.ShortDescription;
            entity.FullDescription = model.FullDescription;
        }
    }
}