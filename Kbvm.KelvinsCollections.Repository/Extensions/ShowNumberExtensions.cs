using AutoMapper;
using DevExpress.Xpo;
using Kbvm.KelvinsCollections.Models.Interfaces;
using Kbvm.KelvinsCollections.Repository.Exceptions;
using System;
using System.Linq;

namespace Kbvm.KelvinsCollections.Repository.Extensions
{
	public static class ShowNumberExtensions
	{
		public static string ToDiscNumber(this int showNumber)
		{
			return showNumber.ToString().Substring(0, 2);
		}

		public static string ToTrackNumber(this int showNumber)
		{
			return showNumber.ToString().Substring(2);
		}
	}

	public static class XpoObjectExtensions
	{
		public static async Task<TXpo> UpdateXpoObjectFromDtoAsync<TDto, TXpo>(this TDto dto, UnitOfWork uow, IMapper mapper)
			where TXpo : XPObject
			where TDto : IHaveKey
		{
			var xpObject = await LoadXpoObjectAsync<TXpo>(dto.Oid, uow);
			return mapper.Map(dto, xpObject);
		}

		private static async Task<TXpo> LoadXpoObjectAsync<TXpo>(int oid,  UnitOfWork uow)
			where TXpo : XPObject
		{
			var xpObject = await uow.GetObjectByKeyAsync<TXpo>(oid);
			if (xpObject == null)
				throw new XpoObjectCouldNotBeLoadedException(typeof(TXpo), oid);
			
			return xpObject;
		}
	}
}
