namespace GiftBox.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;
    
    public class AddCommentViewModel : IMapFrom<Comment>
    {
        public AddCommentViewModel()
        {
        }

        public AddCommentViewModel(int? homeId, int? needId)
        {
            this.HomeId = homeId;
            this.NeedId = needId;
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        [StringLength(150), MinLength(2)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        // [Required]
        public string AuthorId { get; set; }
        
        public int? HomeId { get; set; }

        public int? NeedId { get; set; }
    }
}