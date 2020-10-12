using Microsoft.EntityFrameworkCore;
using MyASPCoreProject.Data;
using MyASPCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPCoreProject.DAL
{
    public class EnrollmentDAL : IEnrollment
    {
        private ApplicationDbContext _context;
        public EnrollmentDAL(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Enrollment> GetAll()
        {
            //var models = _context.Enrollments.Include(s => s.MyStudent);
            var models = from e in _context.Enrollments.Include(s => s.MyStudent).Include(c=>c.Course)
                         orderby e.MyStudent.FirstMidName ascending
                         select e;

            return models;
        }

        public Enrollment GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Enrollment obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Enrollment obj)
        {
            throw new NotImplementedException();
        }
    }
}
