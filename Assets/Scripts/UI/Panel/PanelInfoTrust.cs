/****************************************************
    文件：PanelInfoTrust.cs
	作者：Happy-11
    日期：2021年2月22日19:54:07
	功能：Nothing
*****************************************************/

using DG.Tweening;
using UnityEngine;

public class PanelInfoTrust : WindowRoot 
{
    public Transform imgBgInfoTrustTrans;
    public TrustData trustData;

    private Tween tw;

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml, imgBgInfoTrustTrans);
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