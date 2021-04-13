/****************************************************
    文件：OARoot.cs
	作者：Happy-11
    日期：2020年12月11日23:01:48
	功能：系统主程序
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OARoot : MonoBehaviour
{
    public static OARoot Instance = null;

    public DynamicWnd dynamicWnd;
    public TipsWnd tipsWnd;
    public LoadingWnd loadingWnd;


    //右键白名单窗口
    public List<WindowRoot> whiteRightWindows;
    //栈白名单窗口
    public List<WindowRoot> whiteStackWindows;

    //[HideInInspector]
    public Stack<WindowRoot> windowStack;


    //显示在最上方的窗口
    public WindowRoot topWindow;
    //当前窗口
    private WindowRoot nowWindow;

    
    

   




    private void Awake()
    {
        Init();
        
        Instance = this;
        windowStack = new Stack<WindowRoot>();
        
    }

    private void Start()
    {
        InitStack();
       
    }

    private void Update()
    {
        if (windowStack.Count>=1)
        {
            topWindow = windowStack.Peek();

            if (nowWindow != topWindow)
            {
                Debug.Log("当前栈数：" + windowStack.Count + "---顶部窗口：" + topWindow.name);
                nowWindow = topWindow;
            }

            InputMouse();
        }
        
        



        //foreach (WindowRoot window in windowStack)
        //{

        //    if (window == topWindow)
        //    {
        //        window.SetActive(window.gameObject, true);
        //    }
        //}



    }


    private void InputMouse()
    {
        if (windowStack.Count > 1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (loadingWnd.gameObject.activeSelf == false)
                {
                    WindowRoot window = topWindow;

                    if (whiteRightWindows.Contains(window))
                    {
                        AddTips("此窗口无法被快捷关闭！");
                    }
                    else
                    {
                        window.ReqCloseWnd();
                    }
                }
                else
                {
                    AddTips("正在加载，请勿频繁操作！");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityAction UA = new UnityAction(ExitGame);
            AddDynTips("你确定要退出吗？", "退出程序",UA);
           
        }
        
    }

    private void Init()
    {
        //服务模块初始化
        ResSvc resSvc = GetComponent<ResSvc>();
        resSvc.InitSys();
        AudioSvc audioSvc = GetComponent<AudioSvc>();
        audioSvc.InitSys();
        NetSvc netSvc = GetComponent<NetSvc>();
        netSvc.InitSys();
        //业务模块初始化
        LoginSys loginSys = GetComponent<LoginSys>();
        loginSys.InitSys();

        MainSys mainSys = GetComponent<MainSys>();
        mainSys.InitSys();
    }
    private void InitStack()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            WindowRoot wnd = canvas.GetChild(i).gameObject.GetComponent<WindowRoot>();
            if (wnd==null)
            {
                break;
            }
            if (wnd.gameObject.activeSelf ==true&&wnd!=null&&!whiteStackWindows.Contains(wnd))
            {
                wnd.gameObject.SetActive(false);
            }
        }

        topWindow.ReqOpenWnd();
    }
    public void IntoStack(WindowRoot wnd)
    {
        if (!whiteStackWindows.Contains(wnd))
        {
            windowStack.Push(wnd);
        }  
    }
    public void ExitStack(WindowRoot wnd)
    {
        if (!whiteStackWindows.Contains(wnd))
        {
            windowStack.Pop();
        }
    }
    public void AddTestDebugLog(string str,string tips="暂无调试说明")
    {
        Debug.LogWarning("调试内容：---" + str + "---" + tips);
    }
    public void AddLoading()
    {
        loadingWnd.ReqOpenWnd();
    }
    public void AddTips(string tips)
    {
        tipsWnd.AddTips(tips);
    }
    public void AddDynTips(string tips, string title = "提示", UnityAction a=null)
    {
        dynamicWnd.AddDynTips(title, tips,a);
    }
    public void AddDynTips(GameObject go, string methotName, string reason, string title = "发生程序性错误！请报告程序员！")
    {
        string tips = "错误发生对象：" + go.name + "\n\n" + "错误方法：" + methotName + "\n\n" + "错误原因：" + reason + "\n\n" + "请按Q打开开发者控制台查看详情!";
        dynamicWnd.AddDynTips(title, tips);
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.LogWarning("程序已经被退出！");
    }
}