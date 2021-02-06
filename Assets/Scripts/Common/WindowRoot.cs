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
    protected ResSvc resSvc=null;
    protected AudioSvc audioSvc=null;

    //界面开关的必要处理
    private void SetWndState(WindowRoot window,bool isActive= true)
    {
        if (isActive)
        {
            OpenWndEvent();
            SetActive(window.gameObject, true);
            OARoot.Instance.windowStack.Push(window);
        }
        else
        {
            CloseWndEvent();
            SetActive(window.gameObject, false);
            OARoot.Instance.windowStack.Pop();
        }
        
    }


    //Sys回调获取后打开界面 (无参数) 有参数的请自定义方法

    //理解为Awake
    //打开界面前处理
    public  virtual void ReqOpenWnd()
    {
        InitWnd();
        SetWndState(this, true);
        audioSvc.PlayUIAudio();
    }
    //关闭界面前处理
    public  virtual void ReqCloseWnd()
    {
        SetWndState(this, false);
        audioSvc.PlayUIAudio();
        ClearWnd();
    }

    //理解为Start
    //打开界面后的事件处理
    protected virtual void OpenWndEvent()
    {
        
    }
    //关闭界面后的事件处理
    protected virtual void CloseWndEvent()
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

    //初始化组件
    private void InitWnd()
    {
        resSvc = ResSvc.Instance;
        audioSvc = AudioSvc.Instance;
    }
    private void ClearWnd()
    {
        resSvc = null;
        audioSvc = null;
    }

    //获取一个Trans对象
    protected Transform GetTrans(Transform trans,string name)
    {
        if (trans != null)
        {
            return trans.Find(name); ;
        }
        else
        {
            OARoot.Instance.AddDynTips(gameObject,System.Reflection.MethodBase.GetCurrentMethod().Name, "寻找子物体的过程中未寻找到父物体！");
            return transform.Find(name);
        }
    }

    #region 按钮可改写方法
    public virtual void ClickCloseBtn()
    {
        SetWndState(this,false);
    }
    #endregion
}