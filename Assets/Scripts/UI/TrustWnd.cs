/****************************************************
    文件：TrustWnd.cs
	作者：Happy-11
    日期：2020年12月18日20:48:53
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrustWnd:WindowRoot 
{

    public PanelCreateTrust panelCreateTrust;
    public PanelInfoTrust panelInfoTruc;




    public Transform scrollTransBybtnTrust;

    private List<TrustData> TrustDataLst;

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




    #region 预制体生成后的信息注入点击

    private void ClickTrustBtn(TrustData trustData)
    {
        panelInfoTruc.trustData = trustData;
        panelInfoTruc.ReqOpenWnd();
    }

    #endregion


}