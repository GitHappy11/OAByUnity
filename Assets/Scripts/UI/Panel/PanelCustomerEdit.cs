/****************************************************
    文件：PanelCustomerEdit.cs
	作者：Happy-11
    日期：2021年2月14日16:49:33
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelCustomerEdit : WindowRoot 
{
    public List<GameObject> iptList;
    public List<Button> btnList;

    public CustomerData customerData;


    public override void ReqOpenWnd()
    {
        base.ReqOpenWnd();
        RegBtn();
    }

    private void RegBtn()
    {
        Debug.Log("启动注册");
        for (int i = 0; i <btnList.Count-1; i++)
        {

            btnList[i].onClick.AddListener(() =>
            {
                ClickIptBtn(iptList[i].transform);
            });
        }
        
    }

    private void IptAni(Transform trans,bool isStart=true)
    {
        Tween tw = DoTweenRoot.GetContectAni(trans, 1, trans.position, new Vector2(trans.position.x + 935,trans.position.y));
        if (isStart)
        {
            tw.PlayForward();
        }
        else
        {
            tw.IsBackwards();
        }
    }
    private void ClickIptBtn(Transform trans)
    {
        IptAni(trans);
    }

    public void Update()
    {
        OARoot.Instance.AddTestDebugLog(btnList.Count.ToString());
    }
}