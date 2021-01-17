/****************************************************
    文件：MainWnd.cs
	作者：Happy-11
    日期：2020年12月11日23:43:53
	功能：OA系统主界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class MainWnd : WindowRoot 
{
    public void ClickWTDBtn()
    {
        MainSys.Instance.EnterWTD();
    }

    public void ClickHTBtn()
    {
        MainSys.Instance.EnterHT();
    }

    public void ClickKHBtn()
    {
        MainSys.Instance.EnterKH();
    }

    public void ClickJABtn()
    {
        MainSys.Instance.EnterJA();
    }
    public void ClickSearchBtn()
    {
        MainSys.Instance.EnterSearch();
    }

    public void ClickTaskList()
    {
        MainSys.Instance.EnterTaskList();
    }
}