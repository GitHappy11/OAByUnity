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
            trustNumb="202102062231",
            trustContent="某某路，某某街，项目建设用地",
            trustClass="水面",
            trustClass2="用水勘测定界",
            date="已经进行作业：100日",
            team="Happy11"
        };

        List<TrustDetailData> trustDetailDatasLst = new List<TrustDetailData>();
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);

        ElementData elementData = new ElementData
        {
            date = "202102062231",
            title = "Unity游戏开发计划外包合同",
            isNew = false,
        };

        List<ElementData> elementDatasLst = new List<ElementData>();
        elementDatasLst.Add(elementData);


        MainSys.Instance.EnterTaskList(trustDetailDatasLst, elementDatasLst);
    }
}
