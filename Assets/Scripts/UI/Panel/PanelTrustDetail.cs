/****************************************************
    文件：PanelTrustDetails.cs
	作者：Happy-11
    日期：2021年1月31日22:03:52
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelTrustDetail : WindowRoot 
{
    public Text txtDate;
    public Text txtTitle;
    public ElementData elementData;

    public Transform imgBgTrustDetailTrans;
    private Tween tw;


    


    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        txtDate.text = elementData.date;
        txtTitle.text = elementData.title;
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml, imgBgTrustDetailTrans);

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