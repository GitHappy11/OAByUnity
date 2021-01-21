/****************************************************
    文件：panelSubClickSelect.cs
	作者：Happy-11
    日期：2021年1月21日18:12:04
	功能：Nothing
*****************************************************/

using UnityEngine;

public class PanelSubClickSelect : WindowRoot 
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //这里可以使用列表循环
            if (gameObject.activeSelf == true)
            {
                ClickClosePanel(gameObject);
            }
        }
    }
}