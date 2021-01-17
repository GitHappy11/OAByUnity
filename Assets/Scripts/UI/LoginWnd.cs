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
    public GameObject notice;
    public Animation anibtnBGMusic;

    public bool isAutoLogin=true;

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
        AudioSvc.Instance.PlayUIAudio(Constants.audioUIByUIClickBtn);

        string acct = iptAcct.text;
        string password = iptPassword.text;
        if (acct!= ""&&password!="")
        {
            //更新本地存储的账号密码
            PlayerPrefs.SetString("Acct",acct);
            PlayerPrefs.SetString("Pass",password);

            if (LocalData.statusCode==ExitGames.Client.Photon.StatusCode.Connect)
            {
                //发送网络消息 这里先假设 登录成功

                LoginSys.Instance.RspLogin();
            }
            else
            {
                OARoot.Instance.AddDynTips("检测到当前服务端未响应！进入离线测试模式！", "网络警告");
                LoginSys.Instance.RspLogin();
            }
            

        }
        else
        {
            //账号密码不能为空tips
            OARoot.Instance.AddTips("账号密码不能为空！");

        }
    }

    public void ClickNextLoginConfirm(Image img)
    {
        AudioSvc.Instance.PlayUIAudio(Constants.audioUIByUIClickBtn);

        if (img.color.a==1)
        {
            img.color = new Color(1, 1, 1, 0);
            isAutoLogin = false;
        }
        else
        {
            img.color = new Color(1, 1, 1, 1);
            isAutoLogin = true;
        }
    
    
             
    }

    public void ClickNoticeBtn()
    {
        AudioSvc.Instance.PlayUIAudio(Constants.audioUIByUIClickBtn);
        notice.SetActive(true);
    }

    public void ClickCloseNoice()
    {
        AudioSvc.Instance.PlayUIAudio(Constants.audioUIByUIClickBtn);
        notice.SetActive(false);
    }
    
    public void ClickSetMusic(Image img)
    {
        AudioSvc.Instance.PlayUIAudio(Constants.audioUIByUIClickBtn);
        if (AudioSvc.Instance.bgMusicMode==BGMusicMode.Play)
        {
            anibtnBGMusic.Stop();
            img.sprite = Resources.Load<Sprite>(PathDefine.spriteStopMusic);
            AudioSvc.Instance.SetBGAudio(BGMusicMode.Pause);
        }
        else
        {
            anibtnBGMusic.Play();
            img.sprite = Resources.Load<Sprite>(PathDefine.spriteStartMusic);
            AudioSvc.Instance.SetBGAudio(BGMusicMode.Play);
        }
        
    }
}