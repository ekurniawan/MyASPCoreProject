using Microsoft.EntityFrameworkCore;
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
            var results = from c in _context.Courses
                          select c;
            return results;
        }

        public Course GetById(string id)
        {
            var result = (from c in _context.Courses.Include(s=>s.Enrollments).ThenInclude(s=>s.MyStudent)
                          where c.CourseID == Convert.ToInt32(id)
                          select c).SingleOrDefault();
            return result;
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
            try
            {
                var result = (from c in _context.Courses
                              where c.CourseID == obj.CourseID
                              select c).SingleOrDefault();
                if(result!=null)
                {
                    result.Title = obj.Title;
                    result.Credits = obj.Credits;

                    var status = _context.SaveChanges();
                    return status;
                }
                else
                {
                    throw new Exception("Gagal update data");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
