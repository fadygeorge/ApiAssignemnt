using ApiAssignment.Data;
using ApiAssignment.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiAssignment.Logic.Data_Access
{
    public class StudentRepository : Repository<Student>
    {


        public StudentRepository(Context context) : base(context)
        {

        }
        public IEnumerable<StudentViewModel> Get()
        {
            return AsQueryable().Select(s => new StudentViewModel
            {
                id = s.id,
                name = s.name,
                gpa = s.gpa
            });

        }
        public StudentViewModel Get(int id)
        {
            return AsQueryable().Where(w => w.id == id).Select(s => new StudentViewModel
            {
                id = s.id,
                name = s.name,
                gpa = s.gpa
            }).FirstOrDefault();

        }
        public void Add(StudentViewModel model)
        {
            var student = new Student
            {
                name = model.name,
                gpa = model.gpa
            };
            Insert(student);
        }
        public void Edit(StudentViewModel model)
        {
            var student = new Student
            {
                id = model.id,
                name = model.name,
                gpa = model.gpa
            };
            Update(student);
        }
        public void Remove(int id)
        {
            var data = AsQueryable().Where(w => w.id == id).FirstOrDefault();
            Delete(data);
        }

        

    }
}
