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
            //一定要加!!!
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", _product, _domain);
            //发送短信
            var SendSmsResponse = SendSms();
            //查询状态
            QuerySendDetails("<your phoneNumbers>", "<your bizid>");
            //example
            QuerySendDetails("<your phoneNumbers>", SendSmsResponse.BizId);
            Console.ReadKey();    
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <returns></returns>
        static SendSmsResponse SendSms()
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", _accessKey, _accessSecret);
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
                return httpResponse;
            }
            catch (ServerException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
                throw e;
            }
            catch (ClientException e)
            {
                Console.WriteLine(e.ErrorCode);
                Console.WriteLine(e.ErrorMessage);
                throw e;
            }
        }

        /// <summary>
        /// 短信发送查询
        /// </summary>
        /// <param name="phone">发送手机号</param>
        /// <param name="bizid">业务编号</param>
        static void QuerySendDetails(string phone, string bizid)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", _accessKey, _accessSecret);
            IAcsClient client = new DefaultAcsClient(profile);
            QuerySendDetailsRequest request = new QuerySendDetailsRequest();
            try
            {
                request.PhoneNumber = phone;
                request.BizId = bizid;
                request.SendDate = DateTime.Now.ToString("yyyyMMdd");
                request.PageSize = 10L;
                request.CurrentPage = 1L;
                QuerySendDetailsResponse httpResponse = client.GetAcsResponse(request);
                Console.WriteLine(httpResponse.Code);
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
