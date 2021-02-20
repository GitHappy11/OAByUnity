/****************************************************
    文件：DoTweenRoot.cs
	作者：Happy-11
    日期：2020年12月18日21:25:40
	功能：DoTween插件使用
*****************************************************/

using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DoTweenRoot : MonoBehaviour 
{
    public static Tween GetContectAni(Transform trans,float sec,Vector2 vec2)
    {
        trans.localPosition = vec2;
        Tween tw = trans.DOLocalMove(new Vector2(0, 0), sec);
        tw.SetAutoKill(false);
        return tw;
    }

    public static Sequence GetColorSeq(Image img,float sec)
    {
        Sequence seq=DOTween.Sequence();
        seq.Append(img.DOFade(1,0));
        seq.Append(img.DOFade(0,sec));
      
        return seq;
    }

}

public enum DoTweenType
{
    PanelNoraml
}