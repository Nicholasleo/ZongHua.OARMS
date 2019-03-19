using System;
using System.Web.Http;
using ZongHua.Api.Interface;

namespace ZongHua.Enterprise.Api.Controllers
{
    public class LoginController : ApiController,IAppLoginEnterprise
    {
        public IHttpActionResult GetBackgroundImage(string orderJson)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult GetExtMenuItems(string orderJson)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult GetMenuItems(string orderJson)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult GetOrderLists(string orderJson)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult GetSysParams(string orderJson)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult LoginCheck(string orderJson, string userJson)
        {
            throw new NotImplementedException();
        }
    }
}
