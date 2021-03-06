﻿/****************************************************
    文件：PanelCreateCustomer.cs
	作者：Happy-11
    日期：2021年2月14日16:49:22
	功能：Nothing
*****************************************************/

using DG.Tweening;
using UnityEngine;

public class PanelCreateCustomer : WindowRoot 
{
    public Transform imgBgCreateCustomer;

    private Tween tw;

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml, imgBgCreateCustomer);
        tw.PlayForward();
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
}