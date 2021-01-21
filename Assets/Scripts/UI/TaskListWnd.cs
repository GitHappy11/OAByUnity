/****************************************************
    文件：TaskListWnd.cs
	作者：Happy-11
    日期：2021年1月21日16:51:23
	功能：任务列表界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class TaskListWnd : WindowRoot
{

    public GameObject panelTaskDetail;
    public GameObject panelCreatTask;
    public GameObject panelTrustDetails;



    

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //这里可以使用列表循环
            if (panelTaskDetail.activeSelf == true||panelCreatTask.activeSelf == true ||panelTrustDetails.activeSelf == true)
            {
                ClickClosePanel(panelTrustDetails);
                ClickClosePanel(panelCreatTask);
                ClickClosePanel(panelTaskDetail);
            }
         
        }
          
    }
}