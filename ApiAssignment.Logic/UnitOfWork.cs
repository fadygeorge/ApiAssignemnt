using ApiAssignment.Data;
using ApiAssignment.Logic.Data_Access;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiAssignment.Logic
{
    public class UnitOfWork
    {
        private readonly Context dbcontext;
        public UnitOfWork(Context context)
        {
            dbcontext = context;
        }
        public void Commit()
        {
            dbcontext.SaveChanges();
        }
        #region Student
        StudentRepository student;
        public StudentRepository Student => student ?? (student = new StudentRepository(dbcontext));
        #endregion
    }
}
