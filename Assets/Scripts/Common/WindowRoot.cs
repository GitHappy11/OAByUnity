/****************************************************
    文件：WindowRoot.cs
	作者：Happy-11
    日期：2020年12月11日23:02:14
	功能：UI界面基类
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour 
{
    public void SetWndState(bool isActive=true)
    {
        if (gameObject.activeSelf!=isActive)
        {
            SetActive(gameObject, isActive);
        }

        //打开窗口的时候初始化窗口，否则清理窗口
        if (isActive)
        {
            InitWnd();
        }
        else
        {
            ClearWnd();
        } 
    }

    protected virtual void InitWnd()
    {

    }

    protected virtual void ClearWnd()
    {

    }


    #region 组件激活状态改变
    protected void SetActive(GameObject go, bool isActive = true)
    {
        go.SetActive(isActive);
    }
    protected void SetActive(Transform trans, bool state = true)
    {
        trans.gameObject.SetActive(state);
    }
    protected void SetActive(RectTransform rectTrans, bool state = true)
    {
        rectTrans.gameObject.SetActive(state);
    }
    protected void SetActive(Image img, bool state = true)
    {
        img.transform.gameObject.SetActive(state);
    }
    protected void SetActive(Text txt, bool state = true)
    {
        txt.transform.gameObject.SetActive(state);
    }
    #endregion

    #region 文字组件信息改变
    /// <summary>
    /// 更改Text组件文字信息
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="context"></param>
    protected void SetText(Text txt, string context = "")
    {
        txt.text = context;
    }
    protected void SetText(Transform trans, int num = 0)
    {
        SetText(trans.GetComponent<Text>(), num.ToString());
    }
    protected void SetText(Transform trans, string context = "")
    {
        SetText(trans.GetComponent<Text>(), context);
    }
    protected void SetText(Text txt, int num = 0)
    {
        SetText(txt, num.ToString());
    }
    #endregion
}