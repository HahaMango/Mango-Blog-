using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using Blog.Helper;
using System.Reflection;

namespace Blog.Proxy
{
    /// <summary>
    /// 日志记录拦截器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LoggingInterceptor<T> : BaseAsyncHandleInterceptor
    {
        private readonly ILogger _logger = null;

        /// <summary>
        /// 日志记录拦截器构造函数
        /// </summary>
        /// <param name="logger"></param>
        public LoggingInterceptor(ILogger<T> logger)
        {
            this._logger = logger;
            methodInfo = typeof(LoggingInterceptor<>).GetMethod("HandleAsync", BindingFlags.Instance | BindingFlags.Public);
        }

        /// <summary>
        /// 拦截行为
        /// </summary>
        /// <param name="invocation"></param>
        public override void Intercept(IInvocation invocation)
        {
            MethodType methodType = GetMethodType(invocation);
            Type returntype = invocation.Method.ReturnType;
            string methodName = invocation.Method.Name;
            string par = invocation.Arguments.ToString();

            if (methodType == MethodType.Synchronous)
            {
                _logger.LogDebug("进入方法，方法名：" + methodName + " 参数列表：{par}", par);
                try
                {                    
                    invocation.Proceed();
                }catch(Exception e)
                {                    
                    _logger.LogError("发生异常，方法名：" + methodName + " 参数列表：{par}", par);
                    _logger.LogError("异常信息：{e}", e);
                    if(returntype == typeof(Resultion))
                    {
                        invocation.ReturnValue = new Resultion()
                        {
                            IsSuccess = false
                        };
                    }
                    else
                    {
                        invocation.ReturnValue = null;
                    }
                    return;
                }

                _logger.LogDebug("成功退出方法，方法名：" + methodName + " 参数列表：{par}", par);
            }
            else if(methodType == MethodType.AsyncFunction)
            {
                _logger.LogDebug("进入方法，方法名：" + methodName + " 参数列表：{par}", par);
                invocation.Proceed();
                HandleAsyncWithReflection(invocation, methodName,par);
            }
        }

        /// <summary>
        /// 重写基类的HandleAsync
        /// </summary>
        /// <typeparam name="MT"></typeparam>
        /// <param name="task"></param>
        /// <param name="par"></param>
        /// <returns></returns>
        protected override async Task<MT> HandleAsync<MT>(Task<MT> task, params object[] par)
        {
            string methodName = (string)par[0];
            string methodpar = (string)par[1];
            MT t = default(MT);
            MT rv = (MT)(object)null;
            try
            {
                t = await task;
            }catch(Exception e)
            {
                _logger.LogError("发生异常，方法名：" + methodName + " 参数列表：{par}", methodpar);
                _logger.LogError("异常信息：{e}", e);
                if (t.GetType() == typeof(Resultion))
                {
                    rv = (MT)(object)new Resultion()
                    {
                        IsSuccess = false
                    };
                    return rv;
                }
                else
                {
                    return rv;
                }               
            }
            rv = t;
            _logger.LogDebug("成功退出方法，方法名：" + methodName + " 参数列表：{par}", methodpar);
            return rv;
        }
    }
}
