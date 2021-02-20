/****************************************************
    文件：LoadingWnd.cs
	作者：Happy-11
    日期：2021年2月20日23:07:38
	功能：Nothing
*****************************************************/

using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public  class  LoadingWnd:MonoBehaviour 
{
    private Tween tw;
    public Image img;


    private void OnEnable()
    {

        Sequence seq = DOTween.Sequence();
        seq = DoTweenRoot.GetColorSeq(img,0.5f);
        seq.PlayForward();
        seq.OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }

    
}