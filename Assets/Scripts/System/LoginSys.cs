/****************************************************
    文件：LoginSys.cs
	作者：Happy-11
    日期：2020年12月11日23:29:08
	功能：登录系统业务
*****************************************************/

using UnityEngine;

public class LoginSys : SystemRoot
{
    public static LoginSys Instance = null;

    public LoginWnd loginWnd;
    public MainWnd mainWnd;
    


    public override void InitSys()
    {
        Instance = this;
        base.InitSys();
    }



    public void EnterLogin()
    {
        
    }

  
  
       


    public void RspLogin()
    {
        loginWnd.ReqCloseWnd();
    }




    
}