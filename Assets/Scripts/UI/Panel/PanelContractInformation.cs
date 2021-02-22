/****************************************************
    文件：PanelContractInformation.cs
	作者：Happy-11
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using DG.Tweening;
using UnityEngine;

public class PanelContractInformation : WindowRoot
{
    public ContractData contractData;
    public Transform imgBgContractInformationTrans;

    private Tween tw;

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml, imgBgContractInformationTrans);
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