using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InfoBox : MonoBehaviour
{
    public RectTransform content;
    public float moveDis;
    public float moveTime;

    public void ClickLeft()
    {

        content.DOAnchorPos(new Vector2(content.anchoredPosition.x +moveDis, content.anchoredPosition.y), moveTime);

    }

    public void ClickRight()
    {
        content.DOAnchorPos(new Vector2(content.anchoredPosition.x - moveDis, content.anchoredPosition.y), moveTime);
        
    }
}
