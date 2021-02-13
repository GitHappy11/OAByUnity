/****************************************************
    文件：TestWnd.cs
	作者：Happy-11
    日期：2021年2月13日23:14:57
	功能：测试窗口
*****************************************************/

using UnityEngine;

public class TestWnd : WindowRoot 
{
    public GameObject go;
    

    public void ClickErrorBtn()
    {
        go.SetActive(true);
    }
}