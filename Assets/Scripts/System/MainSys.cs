﻿/****************************************************
    文件：MainSys.cs
	作者：Happy-11
    日期：2020年12月18日20:40:52
	功能：主要界面
*****************************************************/

using UnityEngine;

public class MainSys : SystemRoot 
{
    public static MainSys Instance=null;
    public override void InitSys()
    {
        base.InitSys();
        Instance = this;
    }


    public TaskListWnd taskListWnd;
    public TrustWnd trustWnd;
    public ContractWnd contractWnd;
    public CustomerWnd customerWnd;
    public OverTaskWnd overTaskWnd;
    public SearchWnd searchWnd;


    public void EnterWTD()
    {
        trustWnd.SetWndState();
    }

    public void EnterHT()
    {
        contractWnd.SetWndState();
    }

    public void EnterKH()
    {
        customerWnd.SetWndState();
    }

    public void EnterJA()
    {
        overTaskWnd.SetWndState();
    }
    public void EnterSearch()
    {
        searchWnd.SetWndState();
    }
}