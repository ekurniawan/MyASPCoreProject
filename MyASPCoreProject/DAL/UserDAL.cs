using Microsoft.Extensions.Configuration;
using MyASPCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MyASPCoreProject.DAL
{
    public class UserDAL : IUser
    {
        private IConfiguration _config;
        public UserDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public bool CekLogin(User user)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Users where Username=@Username and Password=@Password";
                var param = new { Username = user.Username, Password = user.Password };
                var result = conn.QuerySingleOrDefault<User>(strSql,param);
                if (result != null)
                    return true;
                else
                    return false;
            }
        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int Insert(User obj)
        {
            throw new NotImplementedException();
        }

        public int Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
