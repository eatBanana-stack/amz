using System;
using AlibabaCloud.SDK.Address_purification20191118;
using AlibabaCloud.SDK.Address_purification20191118.Models;
using AlibabaCloud.TeaUtil;
using AlibabaCloud.TeaUtil.Models;
using Tea;

namespace AddressPurificationExample
{
    public static class AddressPurificationHelper
    {
        /// <summary>
        /// 初始化客户端
        /// </summary>
        /// <param name="accessKeyId">阿里云 AccessKey ID</param>
        /// <param name="accessKeySecret">阿里云 AccessKey Secret</param>
        /// <returns>AddressPurificationClient 实例</returns>
        public static AlibabaCloud.SDK.Address_purification20191118.Client CreateClient(string accessKeyId, string accessKeySecret)
        {
            AlibabaCloud.OpenApiClient.Models.Config config = new AlibabaCloud.OpenApiClient.Models.Config
            {
                AccessKeyId = accessKeyId,
                AccessKeySecret = accessKeySecret
            };
            // 访问的域名
            config.Endpoint = "address-purification.cn-hangzhou.aliyuncs.com";
            return new AlibabaCloud.SDK.Address_purification20191118.Client(config);
        }

        /// <summary>
        /// 查询地址对应的邮编
        /// </summary>
        /// <param name="accessKeyId">阿里云 AccessKey ID</param>
        /// <param name="accessKeySecret">阿里云 AccessKey Secret</param>
        /// <param name="address">要查询的地址</param>
        /// <returns>查询结果</returns>
        public static string QueryPostCode(string address, string accessKeyId = "LTAI5tNLT64vcmwjYtjGqDAY", string accessKeySecret = "nRVvqQlHKNzUEggf73zKkNgztiS2fS")
        {
            AlibabaCloud.SDK.Address_purification20191118.Client client = CreateClient(accessKeyId, accessKeySecret);
            GetZipcodeRequest postAddressRequest = new GetZipcodeRequest
            {
                AppKey="68llqzxdor0v",
                ServiceCode="addrp",
                Text=address,
            };


            // 调用 API 进行邮编查询
            var response =  client.GetZipcode(postAddressRequest).Body.Data;
            return response;

        }
    }


    public class aliZipCode
    {
        public string zipcode { get; set; }
        public string status { get; set; }
        public Time_Used time_used { get; set; }
    }

    public class Time_Used
    {
        public Rt rt { get; set; }
        public float start { get; set; }
    }

    public class Rt
    {
        public float basic_chunking { get; set; }
        public float zipcode { get; set; }
        public float segment { get; set; }
        public float address_correct { get; set; }
        public float complete { get; set; }
        public float structure { get; set; }
    }

}