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


    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        Tween tw = DoTweenRoot.GetDownContectAni(imgimgBgCreateTaskTrans, 2);
        tw.PlayForward();
    }
}