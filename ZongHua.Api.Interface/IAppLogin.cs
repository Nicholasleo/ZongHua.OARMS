using System.Net.Http;
using System.Web.Http;

namespace ZongHua.Api.Interface
{
    /// <summary>
    /// 移动端登录接口
    /// </summary>
    public interface IAppLogin
    {
        /// <summary>
        /// 获取登陆背景图片
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpGet]
        IHttpActionResult GetBackgroundImage(string orderJson);
        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="orderJson"></param>
        /// <param name="userJson"></param>
        /// <returns></returns>
        [HttpPost]
        IHttpActionResult LoginCheck(string orderJson, string userJson);
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpGet]
        IHttpActionResult GetOrderLists(string orderJson);
        /// <summary>
        /// 获取功能菜单项
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpGet]
        IHttpActionResult GetMenuItems(string orderJson);
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpGet]
        IHttpActionResult GetSysParams(string orderJson);
        /// <summary>
        /// 获取拓展的功能项
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        [HttpGet]
        IHttpActionResult GetExtMenuItems(string orderJson);

    }
}
