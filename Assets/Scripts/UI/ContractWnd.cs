/****************************************************
    文件：ContractWnd.cs
	作者：Happy-11
    日期：2020年12月18日20:49:07
	功能：Nothing
*****************************************************/

using UnityEngine;
using DG.Tweening;

public class ContractWnd : WindowRoot
{
    public Transform BgCreateContract;
    Tween tw;

    private void Start()
    {
        tw = DoTweenRoot.GetDownContectAni(BgCreateContract,0.5f);
        tw.SetAutoKill(false);
        tw.Pause();
    }


    public void ClickAddBtn()
    {

        tw.PlayForward();
    }
    public void ClickCloseCreateContractBtn()
    {
        tw.PlayBackwards();
       
    }
    
}