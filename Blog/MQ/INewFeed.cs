using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models.PSModel;

namespace Blog.MQ
{
    /// <summary>
    /// 消息推送接口
    /// </summary>
    public interface INewFeed
    {
        void PushMessage(Message Message);
    }
}
