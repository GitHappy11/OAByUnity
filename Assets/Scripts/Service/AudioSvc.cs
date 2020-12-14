﻿/****************************************************
    文件：AudioSvc.cs
	作者：Happy-11
    日期：2020年12月11日23:10:13
	功能：音乐系统
*****************************************************/

using UnityEngine;

public class AudioSvc : SystemRoot 
{
    public static AudioSvc Instance = null;

    public override void InitSys()
    {
        Instance = this;
    }

    //两个声音监听，分别播放音效和音乐
    public AudioSource bgAudio;
    public AudioSource uiAudio;
}