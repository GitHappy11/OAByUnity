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


    //白名单窗口
    public List<WindowRoot> whiteWindows;


    //显示在最上方的窗口
    public WindowRoot topWindow;

    [HideInInspector]
    public Stack<WindowRoot> windowStack;




    private void Awake()
    {
        Instance = this;
        windowStack = new Stack<WindowRoot>();

        Init();
        LoadSet();
    }

    private void Start()
    {
        topWindow.RspOpenWnd();
    }

    private void Update()
    {

        topWindow = windowStack.Peek();
        



        Debug.Log("当前栈数：" + windowStack.Count + "---顶部窗口：" + topWindow.name);
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

                if (whiteWindows.Contains(window))
                {
                    AddTips("此窗口无法被快捷关闭！");
                }
                else
                {
                    window.RspCloseWnd();
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

    public void LoadSet()
    {
        AudioSvc.Instance.PlayBGMusic(Constants.audioBGByElectricRomeo);
    }

    public void AddTips(string tips)
    {
        tipsWnd.AddTips(tips);
    }

    public void AddDynTips(string tips, string title = "提示")
    {
        dynamicWnd.AddDynTips(title, tips);
    }
}