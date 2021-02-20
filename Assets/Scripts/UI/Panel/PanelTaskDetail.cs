/****************************************************
    文件：PanelTaskDetail.cs
	作者：Happy-11
    日期：2021年1月31日22:06:22
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelTaskDetail : WindowRoot 
{

    public InputField iptTeam;
    public TrustDetailData trustDetailData;

    public Transform imgTaskDetailTrans;
    private Tween tw;


    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        iptTeam.text = trustDetailData.team;
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml,imgTaskDetailTrans);
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