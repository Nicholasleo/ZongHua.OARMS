using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ZongHua.Base.Api.Controllers
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public class LoginController : ApiController
    {
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

        public HttpResponseMessage
    }
}
