using MyASPCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPCoreProject.DAL
{
    public interface IStudentDAL : ICrud<Student>
    {
        IEnumerable<Student> GetByName(string name);
    }
}
