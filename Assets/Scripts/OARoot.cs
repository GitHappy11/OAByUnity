/****************************************************
    文件：OARoot.cs
	作者：Happy-11
    日期：2020年12月11日23:01:48
	功能：系统主程序
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

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


    //显示在最上方的窗口
    public WindowRoot topWindow;
    //当前窗口
    private WindowRoot nowWindow;

    [HideInInspector]
    public Stack<WindowRoot> windowStack;

   




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
        
        topWindow = windowStack.Peek();

        if (nowWindow!=topWindow)
        {
            Debug.Log("当前栈数：" + windowStack.Count + "---顶部窗口：" + topWindow.name);
            nowWindow = topWindow;
        }

        
        InputMouse();



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

    public void AddTips(string tips)
    {
        tipsWnd.AddTips(tips);
    }

    public void AddDynTips(string tips, string title = "提示")
    {
        dynamicWnd.AddDynTips(title, tips);
    }
    public void AddDynTips(GameObject go,string methotName , string reason,string title="发生程序性错误！请报告程序员！")
    {
        string tips = "错误发生对象：" + go.name + "\n\n" + "错误方法：" +methotName+ "\n\n" + "错误原因：" + reason+ "\n\n"+ "请按Q打开开发者控制台查看详情!";
        dynamicWnd.AddDynTips(title, tips);
    }
}