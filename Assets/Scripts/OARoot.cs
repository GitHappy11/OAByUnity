/****************************************************
    文件：OARoot.cs
	作者：Happy-11
    日期：2020年12月11日23:01:48
	功能：系统主程序
*****************************************************/

using System;
using UnityEngine;

public class OARoot : MonoBehaviour 
{
    public static OARoot Instance = null;

    public DynamicWnd dynamicWnd;
    public TipsWnd tipsWnd;

    private void Awake()
    {
        Instance = this;

        Init();
        LoadSet();
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

    public void AddDynTips(string tips ,string title= "提示")
    {
        dynamicWnd.AddDynTips(title, tips);
    }
}