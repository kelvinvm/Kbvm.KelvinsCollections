using DevExpress.Xpo;
using System;
using System.Linq;

namespace Kbvm.DrDemento.Repository
{
	public class RepositoryBase
	{
		protected async Task CommandAsync(Func<UnitOfWork, Task> fnCommand)
		{
			using var uow = new UnitOfWork();
			uow.BeginTransaction();

			await fnCommand(uow);
			await uow.CommitChangesAsync();
		}

		protected async Task<int> CommandAsync(Func<UnitOfWork, Task<XPObject>> fnCommand)
		{
			using var uow = new UnitOfWork();
			uow.BeginTransaction();

			var result = await fnCommand(uow);
			await uow.CommitChangesAsync();

			return result.Oid;
		}

		protected async Task<int> CommandAsync(Func<UnitOfWork, XPObject> fnCommand)
		{
			using var uow = new UnitOfWork();
			uow.BeginTransaction();

			var result = fnCommand(uow);
			await uow.CommitChangesAsync();

			return result.Oid;
		}

		protected async Task<T> QueryAsync<T>(Func<UnitOfWork, Task<T>> fnQuery)
		{
			using var uow = new UnitOfWork();
			return await fnQuery(uow);
		}
	}
}
