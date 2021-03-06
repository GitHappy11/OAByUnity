﻿/****************************************************
    文件：TaskListWnd.cs
	作者：Happy-11
    日期：2021年1月21日16:51:23
	功能：任务列表界面
*****************************************************/

using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskListWnd : WindowRoot
{

    public PanelTaskDetail panelTaskDetail;
    public PanelCreateTask panelCreatTask;
    public PanelTrustDetail panelTrustDetail;

    
    public Transform scrollTransByTrustDetailData;
    public Transform scrollTransByElementData;
    public Transform btnPluging;
    public Transform infoBoxTrans;

    public Transform btnNewTrans;
    public Transform btnFinishTrans;



    private List<TrustDetailData> trustDetailDatasLst;
    private List<ElementData> elementDatasLst;
    private Tween infoBoxTw;
    private Tween btnPlugingTw;

    private bool isShowNew=true;

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
            GameObject btnDetailDataPrefab = resSvc.LoadPrefab(PathDefine.btnTrustDetailPrefab, true);
            btnDetailDataPrefab.transform.SetParent(scrollTransByTrustDetailData);
            btnDetailDataPrefab.name += "_" + i;

            TrustDetailData trustDetailData = trustDetailDatasLst[i];


            SetText(GetTrans(btnDetailDataPrefab.transform, "txtTrustNumb"), trustDetailData.trustNumb);
            SetText(GetTrans(btnDetailDataPrefab.transform, "txtTrustContent"), trustDetailData.trustContent);
            SetText(GetTrans(btnDetailDataPrefab.transform, "txtTrustClass"), trustDetailData.trustClass);
            SetText(GetTrans(btnDetailDataPrefab.transform, "txtTrustClass2"), trustDetailData.trustClass2);
            SetText(GetTrans(btnDetailDataPrefab.transform, "txtDate"), trustDetailData.date);
            SetText(GetTrans(btnDetailDataPrefab.transform, "txtTeam"), trustDetailData.team);

            Button btnDetailData = btnDetailDataPrefab.GetComponent<Button>();
            btnDetailData.onClick.AddListener(() =>
            {
                ClickTrustDetailBtn(trustDetailData);
            });




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

            Button btnElement = btnElementPrefab.GetComponent<Button>();
            btnElement.onClick.AddListener(() =>
            {
                ClikcElementBtn(elementData);
            });


            RefreshBtnUI();
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
        base.OpenWndEvent();
        infoBoxTw = resSvc.LoadTween(DoTweenType.InfoBoxAni, infoBoxTrans);
        btnPlugingTw = resSvc.LoadTween(DoTweenType.TransRotate, btnPluging);
        RefreshUI();
    }

    protected override void CloseWndEvent()
    {
        base.CloseWndEvent();
        OARoot.Instance.AddLoading();
    }





    public void ClickCreateBtn()
    {
        panelCreatTask.ReqOpenWnd();
    }

    public void ClickInfoBoxAni()
    {
        InfoBoxAni();
    }

    public void ClickIsShowNew()
    {
        isShowNew = true;
        RefreshBtnUI();
    }

    public void ClickIsShowFinish()
    {
        isShowNew = false;
        RefreshBtnUI();
    }

    private void RefreshBtnUI()
    {
        if (isShowNew)
        {
            btnNewTrans.localScale = new Vector3(-1, 1, 1);
            btnFinishTrans.localScale = new Vector3(-0.7f, 1, 1);
        }
        else
        {
            btnNewTrans.localScale = new Vector3(-0.7f, 1, 1);
            btnFinishTrans.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void InfoBoxAni()
    {

        if (btnPluging.transform.eulerAngles.z == 0)
        {
            infoBoxTw.PlayForward();
            btnPlugingTw.PlayForward();
        }
        else
        {
            infoBoxTw.PlayBackwards();
            btnPlugingTw.PlayBackwards();
        }
    }


    #region 预制体生成后的信息注入点击
    private void ClikcElementBtn(ElementData elementData)
    {
        panelTrustDetail.elementData = elementData;
        panelTrustDetail.ReqOpenWnd();
        
    }
    private void ClickTrustDetailBtn(TrustDetailData trustDetailData)
    {
        panelTaskDetail.trustDetailData = trustDetailData;
        panelTaskDetail.ReqOpenWnd();
    }

    #endregion


}