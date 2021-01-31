/****************************************************
    文件：Net.cs
	作者：Happy-11
    日期：2021年1月31日23:42:23
	功能：客户端的请求和服务器的响应
*****************************************************/



using System.Collections.Generic;

public class NetReqTaskList:Request
{
    //假设已经接收到了服务器的数据
    public void ReqData()
    {
        TrustDetailData trustDetailData = new TrustDetailData
        {
            id = 1000000,
            groupName = "测试组"
        };

        List<TrustDetailData> trustDetailDatasLst = new List<TrustDetailData>();
        trustDetailDatasLst.Add(trustDetailData);


        MainSys.Instance.EnterTaskList(trustDetailDatasLst);
    }
}
