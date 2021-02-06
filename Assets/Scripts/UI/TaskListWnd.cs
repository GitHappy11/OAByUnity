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

    
    public Transform scrollTransByTrustDetailData;
    public Transform scrollTransByElementData;

    private List<TrustDetailData> trustDetailDatasLst;
    private List<ElementData> elementDatasLst;

    private void RefreshUI()
    {
        //刷新前先把之前的先删除
        for (int i = 0; i < scrollTransByTrustDetailData.childCount; i++)
        {
            Destroy(scrollTransByTrustDetailData.GetChild(i).gameObject);
        }
        for (int i = 0; i < scrollTransByElementData.childCount; i++)
        {
            Destroy(scrollTransByElementData.GetChild(i).gameObject);
        }


        for (int i = 0; i < trustDetailDatasLst.Count; i++)
        {
            GameObject btnDetailData = resSvc.LoadPrefab(PathDefine.btnTrustDetailPrefab, true);
            btnDetailData.transform.SetParent(scrollTransByTrustDetailData);
            btnDetailData.name += "_" + i;

            TrustDetailData trustDetailData = trustDetailDatasLst[i];


            SetText(GetTrans(btnDetailData.transform, "txtTrustNumb"), trustDetailData.trustNumb);
            SetText(GetTrans(btnDetailData.transform, "txtTrustContent"), trustDetailData.trustContent);
            SetText(GetTrans(btnDetailData.transform, "txtTrustClass"), trustDetailData.trustClass);
            SetText(GetTrans(btnDetailData.transform, "txtTrustClass2"), trustDetailData.trustClass2);
            SetText(GetTrans(btnDetailData.transform, "txtDate"), trustDetailData.date);
            SetText(GetTrans(btnDetailData.transform, "txtTeam"), trustDetailData.team);

            

        }
        for (int i = 0; i < elementDatasLst.Count; i++)
        {
            GameObject btnElementPrefab = resSvc.LoadPrefab(PathDefine.btnElementPrefab, true);
            btnElementPrefab.transform.SetParent(scrollTransByElementData);
            btnElementPrefab.name += "_" + i;

            ElementData elementData = elementDatasLst[i];


            SetText(GetTrans(btnElementPrefab.transform, "txtDate"), elementData.date);
            SetText(GetTrans(btnElementPrefab.transform, "txtTitle"), elementData.title);

            SetActive(GetTrans(btnElementPrefab.transform, "imgNew"), elementData.isNew);



        }
    }


    public void ReqOpenWnd(List<TrustDetailData> trustDetailDatasLst, List<ElementData> elementDatasLst)
    {
        this.trustDetailDatasLst = trustDetailDatasLst;
        this.elementDatasLst = elementDatasLst;
        base.ReqOpenWnd();
    }

    protected override void OpenWndEvent()
    {
        RefreshUI();
    }




    public void ClickTrustDetailBtn()
    {
        //请求网络数据 假设服务器回应


        panelTrustDetails.ReqOpenWnd();
    }


}