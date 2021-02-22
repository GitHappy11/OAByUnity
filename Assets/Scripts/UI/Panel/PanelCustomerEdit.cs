﻿/****************************************************
    文件：PanelCustomerEdit.cs
	作者：Happy-11
    日期：2021年2月14日16:49:33
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelCustomerEdit : WindowRoot 
{
    public List<GameObject> iptLst;
    public List<Button> btnLst;
    public List<Tween> twLst=new List<Tween>();

    public CustomerData customerData;
    private bool isReg = false;
    private int nowTw;
    private Tween tw;


    public override void ReqOpenWnd()
    {
        base.ReqOpenWnd();
        RegBtn();
        
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml, transform);
        tw.PlayForward();
    }

    private void RegBtn()
    {
        if (isReg==false)
        {
            for (int i = 0; i < btnLst.Count ; i++)
            {
                RegIptAni(iptLst[i].transform);


                int index = i;
                btnLst[i].onClick.AddListener(() =>
                {
                    ClickIptBtn(index);
                });
            
            }
            isReg = true;
        }
    }

    private void RegIptAni(Transform trans)
    {
        Tween tw = resSvc.LoadTween(DoTweenType.IptMove, trans);
        tw.Pause();
        twLst.Add(tw);
    }
    private void ClickIptBtn(int i)
    {
        
        twLst[i].PlayForward();
        if (nowTw != i)
        {
            if (twLst[nowTw] != null)
            {
                twLst[nowTw].PlayBackwards();
            }
        }
        nowTw = i;
    }
    public override void ReqCloseWnd()
    {
        tw.PlayBackwards();
        audioSvc.PlayUIAudio();
        foreach (Tween tw in twLst)
        {
            tw.PlayBackwards();
        }
        tw.OnRewind(() =>
        {
            base.ReqCloseWnd();
        });
    }

    protected override void CloseWndEvent()
    {
        
    }

  
}