using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelTrustList : MonoBehaviour
{
    public RectTransform content;
    public float moveDis;
    public float moveTime;

    public void ClickDown()
    {

        content.DOAnchorPos(new Vector2(content.anchoredPosition.x , content.anchoredPosition.y + moveDis), moveTime);

    }

    public void ClickUp()
    {
        content.DOAnchorPos(new Vector2(content.anchoredPosition.x , content.anchoredPosition.y - moveDis), moveTime);

    }
}
