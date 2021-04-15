/****************************************************
    文件：PanelCreateTrust.cs
	作者：Happy-11
    日期：2021年2月22日19:52:52
	功能：Nothing
*****************************************************/

using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelCreateTrust : WindowRoot
{
    public Transform imgimgBgCreateTrustTrans;

    private Tween tw;

    public Transform gLG;

    public InputField iptLable;
    private List<BtnNull> btnNullLst = new List<BtnNull>();

    private List<string> lableLst = new List<string>();

    public PanelSubClickSelect panelSubClickSelect;
    public PanelSubClickSelect2 panelSubClickSelect2;


    private bool isRep = false;

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml, imgimgBgCreateTrustTrans);
        tw.PlayForward();
        RefreshList();
    }

    public override void ReqCloseWnd()
    {
        tw.PlayBackwards();
        audioSvc.PlayUIAudio();
        tw.OnRewind(() =>
        {

            base.ReqCloseWnd();
        });
    }

    protected override void CloseWndEvent()
    {

    }

    public void ClickLable()
    {
        if (lableLst.Count < 7)
        {
            //获取点击的按钮
            var btnLst = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
            ////得到子物体Text
            Text txtBtnNull = btnLst.GetComponentInChildren<Text>();
            //将标签存入List 这里如果直接开始实例化对象的话，会导致整个列表都在使用一个预制体，导致改变一个对象就会改变整个List的数据
            if (lableLst.Contains(txtBtnNull.text))
            {
                OARoot.Instance.AddTips("该标签已存在！");
            }
            else
            {
                lableLst.Add(txtBtnNull.text);
            }
        }
        else
        {
            OARoot.Instance.AddTips("该委托单标签已满！");
        }
        RefreshList();

    }
    public void ClickLableSure()
    {
        if (lableLst.Count < 7)
        {
            //将标签存入List 这里如果直接开始实例化对象的话，会导致整个列表都在使用一个预制体，导致改变一个对象就会改变整个List的数据
            if (lableLst.Contains(iptLable.text))
            {
                OARoot.Instance.AddTips("该标签已存在！");
            }
            else
            {
                lableLst.Add(iptLable.text);
            }
        }
        else
        {
            OARoot.Instance.AddTips("该委托单标签已满！");
        }
        RefreshList();
    }
    public void ClickSure()
    {
        ReqCloseWnd();
    }
    public void ClickDeleteBtn()
    {
        lableLst.Clear();
        RefreshList();
    }

    public void ClickStaticContractBtn()
    {
        if (panelSubClickSelect2.gameObject.activeSelf)
        {
            panelSubClickSelect2.ReqCloseWnd();
        }
        panelSubClickSelect.ReqOpenWnd();
        
        
    }
    public void ClickAddBtn()
    {

        if (panelSubClickSelect.gameObject.activeSelf)
        {
            panelSubClickSelect.ReqCloseWnd();
        }
        panelSubClickSelect2.ReqOpenWnd();
        
        
    }

    public void RefreshList()
    {
        for (int i = 0; i < gLG.childCount; i++)
        {
            Destroy(gLG.GetChild(i).gameObject);
        }

        if (lableLst.Count == 0)
        {
            GameObject btnNullGO = resSvc.LoadPrefab(PathDefine.btnNullPrefab, false);
            BtnNull btnNull = btnNullGO.GetComponent<BtnNull>();
            btnNull.txt.text = "Null";
            btnNull.gameObject.transform.SetParent(gLG);
            btnNull.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        for (int i = 0; i < lableLst.Count; i++)
        {
            GameObject btnNullGO = resSvc.LoadPrefab(PathDefine.btnNullPrefab, false);
            BtnNull btnNull = btnNullGO.GetComponent<BtnNull>();
            btnNullGO.name = i.ToString();
            btnNull.txt.text = lableLst[i].ToString();
            btnNull.gameObject.transform.SetParent(gLG);
            btnNull.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }


    }

}