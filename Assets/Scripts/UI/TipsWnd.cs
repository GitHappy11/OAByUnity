/****************************************************
    文件：TipsWnd.cs
	作者：Happy-11
    日期：2020年12月11日23:54:31
	功能：动态tips界面
*****************************************************/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsWnd : WindowRoot 
{
    public Text txtTips;
    public Animation ani;
    private AnimationClip aniTips;

    private void Awake()
    {
        aniTips = ani.GetClip("aniTips");
    }

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        SetActive(txtTips, false); 
    }

    //tips信息队列
    private Queue<string> tipsQue = new Queue<string>();
    private bool isTipsShow = false;
    //将需要显示的tips加入到队列中
    public void AddTips(string tips)
    {
        //线程锁，防止多个tips同时进入
        lock (tipsQue)
        {
            //限制tips队列数量
            if (tipsQue.Count<2)
            {
                tipsQue.Enqueue(tips);
            }
        }
    }

    //将队列中的tips一个个显示出来
    private void SetTips(string tips)
    {
        SetActive(txtTips);

        SetText(txtTips, tips);
        ani.Play();
        //TODO 播放一个过渡的动画
        StartCoroutine(AniPlayDone(aniTips.length,() =>
         {
             SetActive(txtTips, false);
             isTipsShow = false;
         }));
    }

    private IEnumerator AniPlayDone(float sec,Action cb)
    {
        //延时时间
        yield return new WaitForSeconds(sec);
        cb?.Invoke();
    }

    private void Update()
    {
        if (tipsQue.Count>0&&isTipsShow==false)
        {
            lock (tipsQue)
            {
                string tips = tipsQue.Dequeue();
                isTipsShow = true;
                SetTips(tips);
            }
        }
    }
}