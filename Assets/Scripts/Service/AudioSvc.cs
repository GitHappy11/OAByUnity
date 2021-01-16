/****************************************************
    文件：AudioSvc.cs
	作者：Happy-11
    日期：2020年12月11日23:10:13
	功能：音乐系统
*****************************************************/

using UnityEngine;

public class AudioSvc : SystemRoot 
{
    public static AudioSvc Instance = null;

    public  BGMusicMode bgMusicMode=BGMusicMode.Play;

    //两个声音监听，分别播放音效和音乐
    private AudioSource bgAudio;
    private AudioSource uiAudio;

    public override void InitSys()
    {
        Instance = this;

        bgAudio = GameObject.Find("BGAudio").GetComponent<AudioSource>();
        uiAudio = GameObject.Find("UIAudio").GetComponent<AudioSource>();
    }

    /// <summary>
    /// 音乐播放服务
    /// </summary>
    /// <param name="name">音乐名</param>
    /// <param name="isLoop">是否循环</param>
    public void PlayBGMusic(string name, bool isLoop = true)
    {
        AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/BGM/" + name, true);
        
        //当前没有播放音乐或者当前播放的音乐和要播放的音乐不同，则切换的这个音乐
        if (bgAudio.clip == null || bgAudio.clip.name != audio.name)
        {
            bgAudio.clip = audio;
            bgAudio.loop = isLoop;
            bgAudio.Play();
        }
    }
    
    public void SetBGAudio(BGMusicMode bGMusicMode)
    {
        bgMusicMode = bGMusicMode;
        switch (bGMusicMode)
        {
            case BGMusicMode.Play:
                bgAudio.Play();
                break;
            case BGMusicMode.Pause:
                bgAudio.Pause();
                break;
            case BGMusicMode.Stop:
                bgAudio.Stop();
                break;
            default:
                break;
        }
    }

    

}

public  enum BGMusicMode
{
    Play,
    Pause,
    Stop
}