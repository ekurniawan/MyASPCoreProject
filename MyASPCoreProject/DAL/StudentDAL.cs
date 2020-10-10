using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MyASPCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyASPCoreProject.DAL
{
    public class StudentDAL : IStudentDAL
    {
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
            List<Student> lstStudent = new List<Student>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select from Students order by Nim asc";
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
        }

        public Student GetById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int Insert(Student obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Student obj)
        {
            throw new NotImplementedException();
        }
    }
}
