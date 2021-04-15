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
    protected ResSvc resSvc = null;
    protected AudioSvc audioSvc = null;




    //界面开关的必要处理
    private void SetWndState(WindowRoot wnd, bool isActive = true)
    {


        if (isActive)
        {
            OpenWndEvent();
            SetActive(wnd.gameObject, true);
            OARoot.Instance.IntoStack(wnd);
            //OARoot.Instance.windowStack.Push(wnd);
        }
        else
        {
            CloseWndEvent();
            SetActive(wnd.gameObject, false);
            OARoot.Instance.ExitStack(wnd);
        }

        //刷新当前Wnd


        if (OARoot.Instance.windowStack.Count!=0)
        {
            OARoot.Instance.windowStack.Peek().RefreshAni();
        }







    }


    //Sys回调获取后打开界面 (无参数) 有参数的请自定义方法

    //理解为Awake
    //打开界面前处理
    public virtual void ReqOpenWnd()
    {
        InitWnd();
    }
    //关闭界面前处理
    public virtual void ReqCloseWnd()
    {
        ClearWnd();
    }
    //理解为Start
    //打开界面后的事件处理
    protected virtual void OpenWndEvent()
    {
        audioSvc.PlayUIAudio();

    }
    //关闭界面后的事件处理
    protected virtual void CloseWndEvent()
    {
        audioSvc.PlayUIAudio();
    }

    //初始化组件
    private void InitWnd()
    {
        resSvc = ResSvc.Instance;
        audioSvc = AudioSvc.Instance;
        SetWndState(this, true);
    }
    private void ClearWnd()
    {
        SetWndState(this, false);
        //resSvc = null;
        //audioSvc = null;
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



    public virtual void RefreshAni()
    {

    }


    //获取一个Trans对象
    protected Transform GetTrans(Transform trans, string name)
    {
        if (trans != null)
        {
            return trans.Find(name); ;
        }
        else
        {
            OARoot.Instance.AddDynTips(gameObject, System.Reflection.MethodBase.GetCurrentMethod().Name, "寻找子物体的过程中未寻找到父物体！");
            return transform.Find(name);
        }
    }

    #region 按钮可改写方法
    public virtual void ClickCloseBtn()
    {
        ReqCloseWnd();
    }
    #endregion
}