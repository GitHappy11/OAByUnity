/****************************************************
    文件：LoadingWnd.cs
	作者：Happy-11
    日期：2021年2月20日23:07:38
	功能：Nothing
*****************************************************/

using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public  class  LoadingWnd:WindowRoot,IPointerClickHandler
{
    private Tween tw;
    public Image img;


   

   


    public override void ReqOpenWnd()
    {
        SetActive(gameObject,true);
        Sequence seq = DOTween.Sequence();
        seq = DoTweenRoot.GetColorSeq(img, 0.3f);
        seq.PlayForward();
        seq.OnComplete(() =>
        {
            SetActive(gameObject, false);
        });
    }

    protected override void OpenWndEvent()
    {
        
    }

    protected override void CloseWndEvent()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OARoot.Instance.AddTips("正在加载，请勿频繁操作！");
    }
}