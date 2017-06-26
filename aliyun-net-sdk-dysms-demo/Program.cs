using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System;

namespace aliyun_net_sdk_dysms_demo
{
    #region -   版   权   信   息  -
    //======================================================
    //
    //      创 建 人：小渣渣
    //      创建时间：2017/06/26 09:40:01
    //      邮    箱：help@itsvse.com
    //      个人网站：http://www.itsvse.com
    //      功    能：
    //      修改纪录：
    // 
    //======================================================
    #endregion
    class Program
    {
        private const String _accessKey = "<your access key id>";
        private const String _accessSecret = "<your access key secret>";
        private const String _product = "Dysmsapi";
        private const String _domain = "dysmsapi.aliyuncs.com";
        static void Main(string[] args)
        {
            SendSms();
            Console.ReadKey();    
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        static void SendSms()
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-shanghai", _accessKey, _accessSecret);
            //一定要加!!!
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", _product, _domain);
            IAcsClient client = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                request.PhoneNumbers = "<your phoneNumbers>";
                request.SignName = "<your signname>";
                request.TemplateCode = "<your templatecode>";
                request.TemplateParam = "<your templateparam>";
                SendSmsResponse httpResponse = client.GetAcsResponse(request);
                Console.WriteLine(httpResponse.Code);
                Console.WriteLine(httpResponse.BizId);
                Console.WriteLine(httpResponse.Message);
                Console.WriteLine(httpResponse.RequestId);
            }
            catch (ServerException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
            }
            catch (ClientException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
            }
        }
    }
}
