using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ZongHua.Api.Interface
{
    /// <summary>
    /// 移动端登录抽象类
    /// </summary>
    public interface IAppLogin
    {
        /// <summary>
        /// 获取登陆背景图片
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        HttpResponseMessage GetBackgroundImage(string orderJson);
        /// <summary>
        /// 登录校验
        /// </summary>
        /// <param name="orderJson"></param>
        /// <param name="userJson"></param>
        /// <returns></returns>
        HttpResponseMessage LoginCheck(string orderJson, string userJson);
        /// <summary>
        /// 获取订单列表
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        HttpResponseMessage GetOrderLists(string orderJson);
        /// <summary>
        /// 获取功能菜单项
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        HttpResponseMessage GetMenuItems(string orderJson);
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        HttpResponseMessage GetSysParams(string orderJson);
        /// <summary>
        /// 获取拓展的功能项
        /// </summary>
        /// <param name="orderJson"></param>
        /// <returns></returns>
        HttpResponseMessage GetExtMenuItems(string orderJson);

    }
}
