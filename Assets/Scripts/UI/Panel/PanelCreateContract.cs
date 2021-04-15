/****************************************************
    文件：PanelCreateContract.cs
	作者：Happy-11
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using DG.Tweening;
using UnityEngine;

public class PanelCreateContract : WindowRoot 
{
    public Transform imgBgCreateComtractTrans;
    public GameObject imgNodeBox;
    private Tween tw;

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml, imgBgCreateComtractTrans);
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

    public void ClickOpenNoteBox()
    {
        if (!imgNodeBox.activeSelf)
        {
            SetActive(imgNodeBox);
        }
    }
    public void ClickNoteBoxSure()
    {
        SetActive(imgNodeBox, false);
    }
}