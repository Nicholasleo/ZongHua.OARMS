using System;
using System.Collections.Generic;
using System.Web.Http;
using ZongHua.Api.Interface;

namespace ZongHua.Base.Api.Controllers
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class LoginController : ApiController,IAppLogin
    {
        [HttpGet]
        public IHttpActionResult Test(string msg)
        {
            return Ok(msg);
        }

        public IEnumerable<Student> Get()
        {
            Student[] stu = new Student[] {
                new Student{ Name="Nicholas",Age=28},
                new Student{ Name="Leo",Age=29}
            };
            return stu;
        }
        
        [HttpGet]
        public IHttpActionResult GetBackgroundImage(string orderJson)
        {
            Student[] stu = new Student[] {
                new Student{ Name="Nicholas",Age=28},
                new Student{ Name="Leo",Age=29}
            };
            return Json(stu);
        }

        [HttpPost]
        public IHttpActionResult LoginCheck(string orderJson, string userJson)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult GetOrderLists(string orderJson)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult GetMenuItems(string orderJson)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult GetSysParams(string orderJson)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IHttpActionResult GetExtMenuItems(string orderJson)
        {
            throw new NotImplementedException();
        }
    }
}
