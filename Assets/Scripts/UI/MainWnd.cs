/****************************************************
    文件：MainWnd.cs
	作者：Happy-11
    日期：2020年12月11日23:43:53
	功能：OA系统主界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainWnd : WindowRoot
{

    public new Animation animation;
    public Scrollbar bar;
    public float speed;
    public bool isStop = false;

    public Transform scrollTransBybtnPresent;

    private List<PresentData> presentDataLst = new List<PresentData>();

    public void ReqOpenWnd(List<PresentData> lst)
    {
        base.ReqOpenWnd();
        OARoot.Instance.AddLoading();
        presentDataLst = lst;
        RefreshUI();
    }
    public void ClickWTDBtn()
    {
        NetReqTrust netReqTrust = new NetReqTrust();
        
        OARoot.Instance.AddLoading();
    }
    public void ClickHTBtn()
    {
        NetReqContract netReqContract = new NetReqContract();
        netReqContract.ReqContractData();
        OARoot.Instance.AddLoading();
    }
    public void ClickKHBtn()
    {
        NetReqCustomer netReqCustomer = new NetReqCustomer();
        OARoot.Instance.AddLoading();
        
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
        OARoot.Instance.loadingWnd.ReqOpenWnd();
    }

    public void ClickTaskBox()
    {
        MainSys.Instance.EnterTastBox();
    }



    public override void RefreshAni()
    {
        base.RefreshAni();
        PlayerMainWndAni();



    }

    public void PlayerMainWndAni()
    {
        animation.Play("aniMainWnd");

    }

    private void FixedUpdate()
    {
        if (!isStop)
        {
            bar.value -= speed;
            if (bar.value <= 0)
            {
                bar.value = 1;
            }
        }


    }

 

    public void RefreshUI()
    {
        //刷新前先把之前的先删除
        for (int i = 0; i < scrollTransBybtnPresent.childCount; i++)
        {
            Destroy(scrollTransBybtnPresent.GetChild(i).gameObject);
        }


        for (int i = 0; i < presentDataLst.Count; i++)
        {
            GameObject btnPresentPrefab = resSvc.LoadPrefab(PathDefine.btnPresentPrefab, true);
            btnPresentPrefab.transform.SetParent(scrollTransBybtnPresent);
            btnPresentPrefab.name += "_" + i;

            PresentData pd = presentDataLst[i];


            SetText(GetTrans(btnPresentPrefab.transform, "Text"), pd.date);


            Button btnDetailData = btnPresentPrefab.GetComponent<Button>();
            btnDetailData.onClick.AddListener(() =>
            {
                ClickPresentBtn();
            });
        }
    }

    private void ClickPresentBtn()
    {
        OARoot.Instance.AddTips("该窗口暂未开放");
    }
}