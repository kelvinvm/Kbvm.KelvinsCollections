using AutoMapper;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Kbvm.KelvinsCollections.UI.ViewModels;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Show, ShowDto>();
			CreateMap<ShowDto, Show>()
				.DisableCtorValidation()
				.ForMember(x => x.Tracks, opt => opt.Ignore());

			CreateMap<Track, TrackDto>();
			CreateMap<TrackDto, Track>()
				.DisableCtorValidation();
				
			CreateMap<ShowDto, ShowViewModel>()
				.ForMember(d => d.BroadcastDate, opt => opt.MapFrom(src => DateTime.SpecifyKind(src.BroadcastDate, DateTimeKind.Utc)));
			CreateMap<ShowViewModel, ShowDto>()
				.ForMember(d => d.BroadcastDate, opt => opt.MapFrom(src => src.BroadcastDate.DateTime));
			
			CreateMap<TrackDto, TrackViewModel>().ReverseMap();
		}
	}
}
