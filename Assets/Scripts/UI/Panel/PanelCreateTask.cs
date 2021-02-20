/****************************************************
    文件：PanelCreateTask.cs
	作者：Happy-11
    日期：2021年1月31日22:05:45
	功能：创建任务界面
*****************************************************/

using DG.Tweening;
using UnityEngine.UI;
using UnityEngine;

public class PanelCreateTask : WindowRoot
{
    public Transform imgimgBgCreateTaskTrans;

    private Tween tw;

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml,imgimgBgCreateTaskTrans);
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