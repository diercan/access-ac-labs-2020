using System;
using System.Collections.Generic;
using System.Text;
using Infra.Free;
using static IOExt;
using Persistence.Abstractions;

namespace Persistence
{
    public static class Database
    {
        public static IO<AddOrUpdateResult.IAddOrUpdateResult> AddOrUpdate<T>(T item)
            => NewIO<AddOrUpdateCmd, AddOrUpdateResult.IAddOrUpdateResult>(new AddOrUpdateCmd(item));

        public static IO<DeleteResult.IDeleteResult> Delete<T>(T item)
            => NewIO<DeleteCmd, DeleteResult.IDeleteResult>(new DeleteCmd(item));

        public static IO<TResult> Query<TQuery, TResult>(TQuery query) => NewIO<TQuery, TResult>(query);
    }
}
