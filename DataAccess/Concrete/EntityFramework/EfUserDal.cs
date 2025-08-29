using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, PortfolioContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new PortfolioContext())
            {
                var result = from operationClam in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClam.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClam.Id, Name = operationClam.Name };
                return result.ToList();
            }
        }

        public User GetUserByEmail(string email)
        {
            using (var context = new PortfolioContext())
            {
                var result = (from user in context.Users
                              where user.Email == email
                              select user).FirstOrDefault();
                return result;
            }
        }
    }
}
