using Infra.Free;
using Persistence.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using static IOExt;
using static Persistence.Abstractions.AddOrUpdateEntityResult;
using static Persistence.Abstractions.DeleteEntityResult;
using static Persistence.Abstractions.UpdateEntityResult;

namespace Persistence
{
    public class Database
    {
        public static IO<IAddOrUpdateEntityResult> AddNewEntity<T>(T entity) =>
            NewIO<AddOrUpdateEntityCmd, IAddOrUpdateEntityResult>(new AddOrUpdateEntityCmd(entity));

        public static IO<IUpdateEntityResult> UpdateEntity<T>(T entity) =>
            NewIO<UpdateEntityCmd, IUpdateEntityResult>(new UpdateEntityCmd(entity));

        public static IO<IDeteleEntityResult> DeleteEntity<T>(T entity) =>
            NewIO<DeleteEntityCmd, IDeteleEntityResult>(new DeleteEntityCmd(entity));

        public static IO<TResult> Query<TQuery, TResult>(TQuery query) => NewIO<TQuery, TResult>(query);
    }
}