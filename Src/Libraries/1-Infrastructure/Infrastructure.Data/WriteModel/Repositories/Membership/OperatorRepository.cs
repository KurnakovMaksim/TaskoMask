﻿using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskoMask.Domain.WriteModel.Membership.Data;
using TaskoMask.Domain.WriteModel.Membership.Entities;
using TaskoMask.Infrastructure.Data.Common.Repositories;
using TaskoMask.Infrastructure.Data.WriteModel.DbContext;

namespace TaskoMask.Infrastructure.Data.WriteModel.Repositories.Membership
{
    public class OperatorRepository : BaseRepository<Operator>, IOperatorRepository
    {
        #region Fields

        protected readonly IMongoCollection<Operator> _operators;

        #endregion

        #region Ctors

        public OperatorRepository(IWriteDbContext dbContext) : base(dbContext)
        {
            _operators = dbContext.GetCollection<Operator>();
        }

        #endregion

        #region Public Methods



        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Operator>> GetListByRoleIdAsync(string roleId)
        {
            return await _operators.Find(u => u.RolesId.Contains(roleId)).ToListAsync();
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<long> CountByRoleIdAsync(string roleId)
        {
            return await _operators.CountDocumentsAsync(e => e.RolesId.Contains(roleId));
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
