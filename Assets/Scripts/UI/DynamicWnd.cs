/****************************************************
    文件：DynamicWnd.cs
	作者：Happy-11
    日期：2021年1月16日21:29:01
	功能：弹窗式Tips
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot 
{
    public Text txtTitle;
    public Text txtTips;
    

    public void AddDynTips(string title, string tips)
    {
        SetWndState();
        txtTips.text = tips;
        txtTitle.text = title;
    }

    public void ClickSureBtn()
    {
        SetWndState(false);
    }
}