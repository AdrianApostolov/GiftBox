using AutoMapper;
using GiftBox.Web.ViewModels;
using GiftBox.Web.ViewModels.Account;

namespace GiftBox.Web.Areas.Administration.ViewModels.Institution
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Areas.Administration.ViewModels.Base;
    using GiftBox.Web.Infrastructure.Mapping;

    public class AdministrationInstitutionViewModel : AdministrationViewModel, IMapFrom<Home>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactInfo { get; set; }

        public bool IsApproved { get; set; }
    }
}