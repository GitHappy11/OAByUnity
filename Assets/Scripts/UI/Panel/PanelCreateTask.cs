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
    public Transform imgBgCreateTaskTrans;
    public GameObject goSearchPanel;
    public GameObject goSearchPanel2;

    public InputField iptName;
    private Tween tw;

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        tw = resSvc.LoadTween(DoTweenType.PanelNoraml,imgBgCreateTaskTrans);
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

    public void ClickSetSearchPanel()
    {
        SetActive(goSearchPanel, !goSearchPanel.activeSelf);
    }
    public void ClickSetSearchPanel2()
    {
        SetActive(goSearchPanel2, !goSearchPanel2.activeSelf);
    }

    public void ClickIptName()
    {
        //获取点击的按钮
        var btnLst = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        ////得到子物体Text
        Text txt = btnLst.GetComponentInChildren<Text>();
        iptName.text = txt.text;
    }


}