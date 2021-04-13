/****************************************************
    文件：TrustWnd.cs
	作者：Happy-11
    日期：2020年12月18日20:48:53
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TrustWnd:WindowRoot 
{

    public PanelCreateTrust panelCreateTrust;
    public PanelInfoTrust panelInfoTrust;
    public PanelSubClickSelect panelSubClickSelect;
    public PanelSubClickSelect2 panelSubClickSelect2;
    public Transform infoBoxTrans;




    public Transform scrollTransBybtnTrust;
    public Transform btnPluging;

    private List<TrustData> TrustDataLst;

    private Tween infoBoxTw;
    private Tween btnPlugingTw;

    private void RefreshUI()
    {
        //刷新前先把之前的先删除
        for (int i = 0; i < scrollTransBybtnTrust.childCount; i++)
        {
            Destroy(scrollTransBybtnTrust.GetChild(i).gameObject);
        }


        for (int i = 0; i < TrustDataLst.Count; i++)
        {
            GameObject btnTrustDataPrefab = resSvc.LoadPrefab(PathDefine.btnTrustPrefab, true);
            btnTrustDataPrefab.transform.SetParent(scrollTransBybtnTrust);
            btnTrustDataPrefab.name += "_" + i;

            TrustData trustData = TrustDataLst[i];


            SetText(GetTrans(btnTrustDataPrefab.transform, "txtTrustNumb"), trustData.date);


            Button btnTrustData = btnTrustDataPrefab.GetComponent<Button>();
            btnTrustData.onClick.AddListener(() =>
            {
                ClickTrustBtn(trustData);
            });




        }

    }


    public void ReqOpenWnd(List<TrustData> trustDataLst)
    {
        this.TrustDataLst = trustDataLst;
        base.ReqOpenWnd();
    }

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        infoBoxTw= resSvc.LoadTween(DoTweenType.InfoBoxAni, infoBoxTrans);
        btnPlugingTw = resSvc.LoadTween(DoTweenType.TransRotate, btnPluging);

        InfoBoxAni();
        
        RefreshUI();
    }

    protected override void CloseWndEvent()
    {
        base.CloseWndEvent();
        OARoot.Instance.AddLoading();
    }





    public void ClickCreateBtn()
    {
        panelCreateTrust.ReqOpenWnd();
    }

    public void ClickStaticContractBtn()
    {
        panelSubClickSelect.ReqOpenWnd();
    }
    public void ClickAddBtn()
    {
        panelSubClickSelect2.ReqOpenWnd();
    }



    public void ClickInfoBoxAni()
    {
        InfoBoxAni();
    }

    public void InfoBoxAni()
    {
        
        if (btnPluging.transform.eulerAngles.z==0)
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


    public void ClickOrder()
    {
        //TODO
        var buttonSelf = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        //Text text = buttonSelf.Find("Text").GetComponent<Text>();
    }


    #region 预制体生成后的信息注入点击

    private void ClickTrustBtn(TrustData trustData)
    {
        panelInfoTrust.trustData = trustData;
        panelInfoTrust.ReqOpenWnd();
    }

    #endregion


}