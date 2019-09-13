using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Blog.MQ;
using System.Security.Claims;
using Blog.Models.PSModel;
using Blog.JSONEntity;
using Blog.Helper;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace Blog.Proxy
{
    /// <summary>
    /// 能够处理异步和同步方法的拦截器的抽象类
    /// </summary>
    public abstract class BaseAsyncHandleInterceptor : IInterceptor
    {
        protected MethodInfo methodInfo = typeof(BaseAsyncHandleInterceptor).GetMethod("HandleAsync", BindingFlags.Instance | BindingFlags.NonPublic);

        /// <summary>
        /// 拦截器构造函数
        /// </summary>
        /// <param name="newFeed"></param>
        public BaseAsyncHandleInterceptor()
        {
            
        }

        /// <summary>
        /// 定义拦截行为
        /// </summary>
        /// <param name="invocation"></param>
        public abstract void Intercept(IInvocation invocation);

        /// <summary>
        /// 负责处理对异步方法的拦截处理
        /// </summary>
        /// <param name="invocation"></param>
        protected void HandleAsyncWithReflection(IInvocation invocation,params object[] par)
        {
            var resultType = invocation.Method.ReturnType.GetGenericArguments()[0];
            var mi = methodInfo.MakeGenericMethod(resultType);
            invocation.ReturnValue = mi.Invoke(this, new[] { invocation.ReturnValue,par});
        }

        /// <summary>
        /// 负责处理对异步方法的拦截处理
        /// 
        /// （acion的参数为被代理方法的返回值，使用前请按自己逻辑重写）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        protected virtual async Task<MT> HandleAsync<MT> (Task<MT> task,params object[] par)
        {
            var t = await task;
            return t;
        }

        /// <summary>
        /// 判断当前方法是异步还是同步方法
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns></returns>
        protected MethodType GetMethodType(IInvocation invocation)
        {
            var returnType = invocation.Method.ReflectedType;
            if(returnType == typeof(Task))
            {
                return MethodType.AsyncAction;
            }if(returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                return MethodType.AsyncFunction;
            }
            return MethodType.Synchronous;
        }

        /// <summary>
        /// 方法类型枚举
        /// </summary>
        protected enum MethodType
        {
            Synchronous,
            AsyncAction,
            AsyncFunction
        }
    }
}
