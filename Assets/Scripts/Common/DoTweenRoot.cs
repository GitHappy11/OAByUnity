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
    public static Tween GetDownContectAni(Transform transform,float sec)
    {
        Tween dt = transform.DOLocalMove(new Vector2(0, 0), sec);

        return dt;
    }
}