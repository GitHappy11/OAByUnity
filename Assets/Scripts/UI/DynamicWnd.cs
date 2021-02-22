/****************************************************
    文件：DynamicWnd.cs
	作者：Happy-11
    日期：2021年1月16日21:29:01
	功能：弹窗式Tips
*****************************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot
{
    public Text txtTitle;
    public Text txtTips;
    public Button btnSure;

    public Animator animator;
    AnimatorStateInfo info;

    public delegate void Exit();
  

    public override void ReqCloseWnd()
    {
        animator.Play("aniCloseDynameWnd");
        audioSvc.PlayUIAudio();
        StartCoroutine(CloseAni());

    }

    IEnumerator CloseAni()
    {
        yield return new WaitForSeconds(0.6f);
        base.ReqCloseWnd();
    }



    public void AddDynTips(string title, string tips, UnityAction ua=null)
    {
        if (gameObject.activeSelf!=true)
        {
            ReqOpenWnd();
          
        }
        else
        {
            
        }

        txtTips.text = tips;
        txtTitle.text = title;
        if (ua != null)
        {
            btnSure.onClick.AddListener(ua);
        }

    }

    public override void ClickCloseBtn()
    {
        ReqCloseWnd();
    }

    protected override void CloseWndEvent()
    {
        
    }

    
   
}