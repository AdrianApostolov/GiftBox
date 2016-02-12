namespace GiftBox.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    using AutoMapper;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? HomeId { get; set; }

        public int? NeedId { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(m => m.AuthorName, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}