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


    public override void RspOpenWnd()
    {
        base.RspOpenWnd();
    }

    
    //按钮点击后
    public void ClickOpenWnd()
    {
        //测试使用 假设网络消息已经接收完毕
        MainSys.Instance.EnterTaskList();
    }


}