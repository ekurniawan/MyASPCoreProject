using MyASPCoreProject.Data;
using MyASPCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPCoreProject.DAL
{
    public class CourseDAL : ICourse
    {
        private ApplicationDbContext _context;
        public CourseDAL(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public Course GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Course obj)
        {
            try
            {
                _context.Courses.Add(obj);
                int result = _context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int Update(Course obj)
        {
            throw new NotImplementedException();
        }
    }
}
