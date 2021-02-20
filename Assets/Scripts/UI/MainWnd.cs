/****************************************************
    文件：MainWnd.cs
	作者：Happy-11
    日期：2020年12月11日23:43:53
	功能：OA系统主界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class MainWnd : WindowRoot 
{

    public override void ReqOpenWnd()
    {
        base.ReqOpenWnd();
    }

    public void ClickWTDBtn()
    {
        NetReqCustomer netReqCustomer = new NetReqCustomer();
        netReqCustomer.ReqCustomerData();
    }

    public void ClickHTBtn()
    {
        MainSys.Instance.EnterHT();
    }

    public void ClickKHBtn()
    {
        MainSys.Instance.EnterKH();
    }

    public void ClickJABtn()
    {
        MainSys.Instance.EnterJA();
    }
    public void ClickSearchBtn()
    {
        MainSys.Instance.EnterSearch();
    }

    public void ClickTaskList()
    {
        NetReqTaskList netReqTaskList = new NetReqTaskList();
        //假设触发回调
        netReqTaskList.ReqTrustDetailData();
 
       
    }
}