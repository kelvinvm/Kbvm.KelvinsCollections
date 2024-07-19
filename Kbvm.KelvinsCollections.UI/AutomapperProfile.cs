using AutoMapper;
using Kbvm.KelvinsCollections.Models.Models.DrDemento;
using Kbvm.KelvinsCollections.UI.ViewModels;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.UI
{
	public class AutomapperProfile : Profile
	{
		public AutomapperProfile()
		{
			CreateMap<Show, ShowDto>().ReverseMap();
			CreateMap<Track, TrackDto>().ReverseMap();
			CreateMap<ShowDto, ShowViewModel>().ReverseMap();
			CreateMap<TrackDto, TrackViewModel>().ReverseMap();
		}
	}
}
