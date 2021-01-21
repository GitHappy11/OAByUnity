/****************************************************
    文件：PanelCreateTrust.cs
	作者：Happy-11
    日期：2021年1月21日18:34:33
	功能：Nothing
*****************************************************/

using UnityEngine;

public class PanelCreateTrust : WindowRoot 
{
    public GameObject panelSubClickSelect;
    public GameObject panelSubClickSelect2;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //这里可以使用列表循环
            if (panelSubClickSelect.activeSelf == true || panelSubClickSelect2.activeSelf == true)
            {
                ClickClosePanel(panelSubClickSelect);
                ClickClosePanel(panelSubClickSelect2);
            }

        }
    }

}