using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GiftBox.Data.Models;
using GiftBox.Web.Areas.Administration.ViewModels.Base;
using GiftBox.Web.Infrastructure.Mapping;

namespace GiftBox.Web.Areas.Administration.ViewModels.Comments
{
    public class AdministrationCommentViewModel : AdministrationViewModel, IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string UserName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, AdministrationCommentViewModel>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}