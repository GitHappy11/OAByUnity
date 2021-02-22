/****************************************************
    文件：MainSys.cs
	作者：Happy-11
    日期：2020年12月18日20:40:52
	功能：主要界面
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class MainSys : SystemRoot 
{
    public static MainSys Instance=null;
    public override void InitSys()
    {
        base.InitSys();
        Instance = this;
    }


    public TaskListWnd taskListWnd;
    public TrustWnd trustWnd;
    public ContractWnd contractWnd;
    public CustomerWnd customerWnd;
    public OverTaskWnd overTaskWnd;
    public SearchWnd searchWnd;


    public void EnterWTD(List<CustomerData> customerDataLst)
    {
        customerWnd.ReqOpenWnd(customerDataLst);
    }

    public void EnterHT(List<ContractData> contractDataLst)
    {
        contractWnd.ReqOpenWnd(contractDataLst);
    }

    public void EnterKH(List<TrustData> trustDataLst)
    {
        trustWnd.ReqOpenWnd(trustDataLst);
    }

    public void EnterJA()
    {
        OARoot.Instance.AddTips("此功能暂未开放。");
    }
    public void EnterSearch()
    {
        OARoot.Instance.AddTips("此功能暂未开放。");
    }

    //网络消息接收
    public void EnterTaskList(List<TrustDetailData> trustDetailDatasLst,List<ElementData> elementDatasLst)
    {
        //网络消息接收到后再打开界面传送参数
        taskListWnd.ReqOpenWnd(trustDetailDatasLst,elementDatasLst);
    }
}