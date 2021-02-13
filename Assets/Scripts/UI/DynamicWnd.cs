/****************************************************
    文件：DynamicWnd.cs
	作者：Happy-11
    日期：2021年1月16日21:29:01
	功能：弹窗式Tips
*****************************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot
{
    public Text txtTitle;
    public Text txtTips;

    public Animator animator;
    AnimatorStateInfo info;


  

    public void CloseWnd()
    {
        animator.Play("aniCloseDynameWnd");
        audioSvc.PlayUIAudio();
        StartCoroutine(CloseAni());

    }

    IEnumerator CloseAni()
    {
        yield return new WaitForSeconds(0.6f);
        ReqCloseWnd();
    }



    public void AddDynTips(string title, string tips)
    {
        ReqOpenWnd();
        txtTips.text = tips;
        txtTitle.text = title;
    }

    public override void ClickCloseBtn()
    {
        CloseWnd();
    }

    protected override void CloseWndEvent()
    {
        
    }
   
}