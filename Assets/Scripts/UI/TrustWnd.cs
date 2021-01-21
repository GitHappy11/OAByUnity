/****************************************************
    文件：TrustWnd.cs
	作者：Happy-11
    日期：2020年12月18日20:48:53
	功能：Nothing
*****************************************************/

using UnityEngine;

public class TrustWnd:WindowRoot 
{

    public GameObject panelCreateTrust;
    public GameObject panelInfoTruc;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //这里可以使用列表循环
            if (panelCreateTrust.activeSelf == true || panelInfoTruc.activeSelf == true )
            {
                ClickClosePanel(panelCreateTrust);
                ClickClosePanel(panelInfoTruc);
            }

        }

    }



}