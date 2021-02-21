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

    public bool isAutoLogin = true;



    protected override void OpenWndEvent()
    {
        audioSvc.PlayBGMusic(Constants.audioBGByElectricRomeo);
        base.OpenWndEvent();
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
        audioSvc.PlayUIAudio(Constants.audioUIByUIClickBtn);

        string acct = iptAcct.text;
        string password = iptPassword.text;
        if (acct != "" && password != "")
        {
            //更新本地存储的账号密码
            PlayerPrefs.SetString("Acct", acct);
            PlayerPrefs.SetString("Pass", password);


            //发送网络消息 这里先假设 登录成功
            LoginSys.Instance.RspLogin();



        }
        else
        {
            //账号密码不能为空tips
            OARoot.Instance.AddTips("账号密码不能为空！");

        }
    }
    


    public void ClickNextLoginConfirm(Image img)
    {
        audioSvc.PlayUIAudio(Constants.audioUIByUIClickBtn);

        if (img.color.a == 1)
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
        if (notice!=null)
        {
            OARoot.Instance.AddDynTips("当前暂无公告！", "公告");
        }
        else
        {
            OARoot.Instance.AddDynTips(gameObject, System.Reflection.MethodBase.GetCurrentMethod().Name, "未找到实例对象！");
        }
        
    }

    public void ClickCloseNoice()
    {
        audioSvc.PlayUIAudio(Constants.audioUIByUIClickBtn);
        notice.SetActive(false);
    }

    public void ClickSetMusic(Image img)
    {
        audioSvc.PlayUIAudio(Constants.audioUIByUIClickBtn);
        if (audioSvc.bgMusicMode == BGMusicMode.Play)
        {
            anibtnBGMusic.Stop();
            img.sprite = Resources.Load<Sprite>(PathDefine.spriteStopMusic);
            audioSvc.SetBGAudio(BGMusicMode.Pause);
        }
        else
        {
            anibtnBGMusic.Play();
            img.sprite = Resources.Load<Sprite>(PathDefine.spriteStartMusic);
            audioSvc.SetBGAudio(BGMusicMode.Play);
        }

    }
}