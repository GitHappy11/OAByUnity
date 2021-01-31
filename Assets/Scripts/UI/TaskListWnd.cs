/****************************************************
    文件：TaskListWnd.cs
	作者：Happy-11
    日期：2021年1月21日16:51:23
	功能：任务列表界面
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListWnd : WindowRoot
{

    public PanelTaskDetails panelTaskDetails;
    public PanelCreateTask panelCreatTask;
    public PanelTrustDetails panelTrustDetails;

    
    public Transform scrollTrans;

    private void RefreshUI(List<TrustDetailData> trustDetailDatasLst)
    {
        //刷新前先把之前的先删除
        for (int i = 0; i < scrollTrans.childCount; i++)
        {
            Destroy(scrollTrans.GetChild(i).gameObject);
        }


        for (int i = 0; i < trustDetailDatasLst.Count; i++)
        {
            //GameObject btnDetailData=resSvc.
        }
    }


    public void ReqOpenWnd(List<TrustDetailData> trustDetailDatasLst)
    {
        RefreshUI(trustDetailDatasLst);
        base.ReqOpenWnd();
    }

    


    public void ClickTrustDetailBtn()
    {
        //请求网络数据 假设服务器回应
        

        SetWndState(panelTrustDetails);
    }


}