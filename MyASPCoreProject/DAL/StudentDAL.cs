using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyASPCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;


namespace MyASPCoreProject.DAL
{
    public class StudentDAL : IStudentDAL
    {
        //DAL
        private IConfiguration _config;
        public StudentDAL(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnectionString()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Students order by Nim asc";
                var results = conn.Query<Student>(strSql);
                return results;
            }
        }

        /*public IEnumerable<Student> GetAll()
        {
            List<Student> lstStudent = new List<Student>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Students order by Nim asc";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstStudent.Add(new Student
                        {
                            Nim = Convert.ToInt32(dr["Nim"]),
                            Nama = dr["Nama"].ToString(),
                            Alamat = dr["Alamat"].ToString(),
                            Telp = dr["Telp"].ToString()
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lstStudent;
        }*/

        public Student GetById(string id)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from Students where Nim=@Nim";
                var param = new { Nim = id };
                var result = conn.QuerySingle<Student>(strSql, param);
                return result;
            }
        }

        public IEnumerable<Student> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(Student obj)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"insert into Students(Nama,Alamat,Telp) values(@Nama,@Alamat,@Telp)";
                var param = new { Nama = obj.Nama, Alamat = obj.Alamat, Telp = obj.Telp };
                try
                {
                    var result = conn.Execute(strSql, param);
                    return result;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception($"Error: {sqlEx.Message}");
                }
            }
        }

        public int Update(Student obj)
        {
            throw new NotImplementedException();
        }
    }
}
