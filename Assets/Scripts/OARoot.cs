/****************************************************
    文件：GameRoot.cs
	作者：Happy-11
    日期：2020年12月11日23:01:48
	功能：系统主程序
*****************************************************/

using System;
using UnityEngine;

public class OARoot : MonoBehaviour 
{
    public static OARoot Instance = null;

    public TipsWnd tipsWnd;

    private void Awake()
    {
        Instance = this;

        Init();
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
    }

    public void AddTips(string tips)
    {
        Instance.tipsWnd.AddTips(tips);
    }
}