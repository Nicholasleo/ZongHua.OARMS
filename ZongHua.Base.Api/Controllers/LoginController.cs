using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        //public IHttpActionResult Test(string msg)
        //{
        //    return Ok(msg);
        //}

        //public IEnumerable<Student> Get()
        //{
        //    Student[] stu = new Student[] {
        //        new Student{ Name="Nicholas",Age=28},
        //        new Student{ Name="Leo",Age=29}
        //    };
        //    return stu;
        //}

        [HttpGet]
        public HttpResponseMessage GetBackgroundImage(string orderJson)
        {
            Student[] stu = new Student[] {
                new Student{ Name="Nicholas",Age=28},
                new Student{ Name="Leo",Age=29}
            };
            return WebApiConfig.ToJson(stu);
        }

        [HttpPost]
        public HttpResponseMessage LoginCheck(string orderJson, string userJson)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public HttpResponseMessage GetOrderLists(string orderJson)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public HttpResponseMessage GetMenuItems(string orderJson)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public HttpResponseMessage GetSysParams(string orderJson)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public HttpResponseMessage GetExtMenuItems(string orderJson)
        {
            throw new NotImplementedException();
        }
    }
}
