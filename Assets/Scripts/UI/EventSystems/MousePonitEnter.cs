using UnityEngine.EventSystems;
using UnityEngine;

public class MousePonitEnter : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public MainWnd mainWnd;

    public void OnPointerEnter(PointerEventData eventData)
    {
        mainWnd.isStop = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mainWnd.isStop = false;
    }
}
