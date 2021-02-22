/****************************************************
    文件：PanelCreateTrust.cs
	作者：Happy-11
    日期：2021年2月22日19:52:52
	功能：Nothing
*****************************************************/

using DG.Tweening;
using UnityEngine;

public class PanelCreateTrust : WindowRoot 
{
    public Transform imgimgBgCreateTrustTrans;

    private Tween tw;

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml,imgimgBgCreateTrustTrans);
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