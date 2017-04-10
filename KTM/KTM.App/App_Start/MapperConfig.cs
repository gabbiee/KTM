namespace KTM.App
{
    using System.Linq;
    using AutoMapper;
    using Models.ViewModels;
    using KTM.Models;

    public static class MapperConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.CreateMap<Motorcycle, ConciseMotorcycleViewModel>()
                .ForMember(vm => vm.CoverImageUrl, opt => opt.MapFrom(g => g.ImageUrls.FirstOrDefault().Url))
                .ForMember(vm => vm.Rating, opt => opt.MapFrom(g => g.Ratings.Any() ? g.Ratings.Average(r => r.Value) : 0));

            Mapper.CreateMap<News, ConciseNewsViewModel>()
                .ForMember(vm => vm.CoverImageUrl, opt => opt.MapFrom(g => g.ImageUrls.FirstOrDefault().Url));
            Mapper.CreateMap<Review, ReviewViewModel>()
                .ForMember(vm => vm.Author, opt => opt.MapFrom(r => r.Author.UserName))
                .ForMember(vm => vm.MotorcycleId, opt => opt.MapFrom(r => r.Motorcycle.Id))
                .ForMember(vm => vm.MotorcycleTitle, opt => opt.MapFrom(r => r.Motorcycle.Title));
            Mapper.CreateMap<Motorcycle, MotorcycleDetailsViewModel>()
                .ForMember(vm => vm.CategoryId, opt => opt.MapFrom(g => g.Category.Id))
                .ForMember(vm => vm.CategoryName, opt => opt.MapFrom(g => g.Category.Name))
                .ForMember(vm => vm.Rating,
                    opt => opt.MapFrom(g => g.Ratings.Any() ? g.Ratings.Average(r => r.Value) : 0))
                .ForMember(vm => vm.ImageUrls, opt => opt.MapFrom(g => g.ImageUrls.Select(u => u.Url)));
                  Mapper.CreateMap<News, NewsDetailsViewModel>()
                .ForMember(vm => vm.ImageUrls, opt => opt.MapFrom(g => g.ImageUrls.Select(u => u.Url)));
            Mapper.CreateMap<Review, ConciseReviewViewModel>()
                .ForMember(vm => vm.Author, opt => opt.MapFrom(r => r.Author.UserName));
            Mapper.CreateMap<Rating, RatingViewModel>();
        }
    }
}