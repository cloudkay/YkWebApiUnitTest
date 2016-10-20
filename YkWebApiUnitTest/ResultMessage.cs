using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YkWebApiUnitTest
{
    /// <summary>
    /// Api请求结果消息
    /// By：杨超
    /// QQ：489578430
    /// </summary>
    public class ResultMessage
    {
        /// <summary>
        /// 状态码，默认情况下，大于等于0时，表示业务成功，否则为业务失败
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 状态码对应描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 全参构造函数
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public ResultMessage(int code, string message = "success")
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// 状态为0的业务成功消息
        /// </summary>
        public ResultMessage()
        {
            Code = 0;
            Message = "success";
        }
    }
    /// <summary>
    /// Api请求结果的泛型扩展
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResultMessage<T> : ResultMessage
    {
        /// <summary>
        /// 请求的数据
        /// </summary>
        public T Data { get; set; }

        public ResultMessage(T data, int code = 0, string message = "success")
            : base(code, message)
        {
            Data = data;
        }
    }
}
