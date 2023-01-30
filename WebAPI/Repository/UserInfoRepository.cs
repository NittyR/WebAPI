using WebAPI.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebAPI.Repository
{
    public interface IUserInfoRepository
    {
        Task<IEnumerable<UserInfo>> GetUserInfo();
        Task<UserInfo> GetUserInfoID(int ID);
        Task<UserInfo> InsertUserInfo(UserInfo objUserInfo);
        Task<UserInfo> UpdateUserInfo(UserInfo objUserInfo);
        bool DeleteUserInfo(int ID);
    }
    public class UserInfoRepository : IUserInfoRepository
    {

        private readonly APIDbContext _appDBContext;

        public UserInfoRepository(APIDbContext context)
        {
            _appDBContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<UserInfo>> GetUserInfo()
        {
            return await _appDBContext.UserInfos.ToListAsync();
        }

        public async Task<UserInfo> GetUserInfoID(int ID)
        {
            return await _appDBContext.UserInfos.FindAsync(ID);
        }

        public async Task<UserInfo> InsertUserInfo(UserInfo objUserInfo)
        {
            _appDBContext.UserInfos.Add(objUserInfo);
            await _appDBContext.SaveChangesAsync();
            return objUserInfo;
        }

        public async Task<UserInfo> UpdateUserInfo(UserInfo objUserInfo)
        {
            _appDBContext.Entry(objUserInfo).State = EntityState.Modified;
            await _appDBContext.SaveChangesAsync();
            return objUserInfo;
        }

        public  bool DeleteUserInfo(int ID)
        {
            bool result = false;
            var usersInfo = _appDBContext.UserInfos.Find(ID);
            if (usersInfo != null)
            {
                _appDBContext.Entry(usersInfo).State = EntityState.Deleted;
                _appDBContext.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}