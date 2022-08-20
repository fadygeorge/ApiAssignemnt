using IdentityAuthhApi.Data;
using IdentityAuthhApi.Logic;
using IdentityAuthhApi.Logic.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace IdentityAuthApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        UnitOfWork unitofwork;
      
        public StudentController(Context context)
        {
            unitofwork = new UnitOfWork(context);
        }
        
        public IEnumerable<StudentViewModel> Get()
        {
            var model = unitofwork.Student.Get();
            return model;
        }

        public ResultViewModel Add(StudentViewModel s)
        {
            unitofwork.Student.Add(s);
            unitofwork.Commit();
            return new ResultViewModel { IsSuccess = true, };
        }

        public StudentViewModel GetS(int id)
        {
            return unitofwork.Student.Get(id);
        }

        //[Authorize]
        public ResultViewModel Edit(StudentViewModel s)
        {
            unitofwork.Student.Edit(s);
            unitofwork.Commit();
            return new ResultViewModel { IsSuccess = true, };
        }

        public ResultViewModel Delete(int id)
        {
            unitofwork.Student.Remove(id);
            unitofwork.Commit();
            return new ResultViewModel { IsSuccess = true, };
        }
        
    }


}
