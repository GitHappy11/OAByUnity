/****************************************************
    文件：LoginWnd.cs
	作者：Happy-11
    日期：2020年12月11日23:35:03
	功能：登录界面UI逻辑
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoginWnd : WindowRoot 
{
    public InputField iptAcct;
    public InputField iptPassword;

    protected override void InitWnd()
    {
        base.InitWnd();
        //获取本地存储的账号密码
        if (PlayerPrefs.HasKey("Acct") && PlayerPrefs.HasKey("Pass"))
        {
            iptAcct.text = PlayerPrefs.GetString("Acct");
            iptPassword.text = PlayerPrefs.GetString("Pass");
        }
        else
        {
            iptAcct.text = "";
            iptPassword.text = "";
        }

    }

    public void ClickLoginBtn()
    {
        string acct = iptAcct.text;
        string password = iptPassword.text;
        if (acct!= ""&&password!="")
        {
            //更新本地存储的账号密码
            PlayerPrefs.SetString("Acct",acct);
            PlayerPrefs.SetString("Pass",password);

            //发送网络消息 这里先假设 登录成功

            LoginSys.Instance.RspLogin();

        }
        else
        {
            //账号密码不能为空tips
            OARoot.Instance.AddTips("账号密码不能为空！");

        }
    }

    public void ClickNoticeBtn()
    {

    }
}