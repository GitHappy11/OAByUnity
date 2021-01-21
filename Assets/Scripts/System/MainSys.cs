/****************************************************
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
        AudioSvc.Instance.PlayUIAudio();
        trustWnd.SetWndState();
    }

    public void EnterHT()
    {
        AudioSvc.Instance.PlayUIAudio();
        contractWnd.SetWndState();
    }

    public void EnterKH()
    {
        AudioSvc.Instance.PlayUIAudio();
        customerWnd.SetWndState();
    }

    public void EnterJA()
    {
        AudioSvc.Instance.PlayUIAudio();
        OARoot.Instance.AddTips("该界面暂未实现！");
        //overTaskWnd.SetWndState();
    }
    public void EnterSearch()
    {
        AudioSvc.Instance.PlayUIAudio();
        OARoot.Instance.AddTips("该界面暂未实现！");
        //searchWnd.SetWndState();
    }

    public void EnterTaskList()
    {
        AudioSvc.Instance.PlayUIAudio();
        taskListWnd.SetWndState();
    }
}