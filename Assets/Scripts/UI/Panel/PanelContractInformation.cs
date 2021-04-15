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
    public GameObject imgNodeBox;
    public GameObject[] lightImagelst;
    private Tween tw;
    private bool isEdit=false;

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
    public void ClickEdit()
    {
        isEdit = !isEdit;
        foreach (GameObject light in lightImagelst)
        {
            SetActive(light, isEdit);
        }
    }
}