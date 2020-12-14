/****************************************************
    文件：ResSvc.cs
	作者：Happy-11
    日期：2020年12月11日23:16:39
	功能：资源加载服务
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class ResSvc : SystemRoot 
{
    public static ResSvc Instance = null;

    public override void InitSys()
    {
        Instance = this;
    }

    //音乐资源缓存字典
    private Dictionary<string, AudioClip> audioDict = new Dictionary<string, AudioClip>();
    public AudioClip LoadAudio(string path,bool cache=false)
    {
        AudioClip au = null;
        //检查字典中是否已经有缓存
        if (!audioDict.TryGetValue(path,out au))
        {
            //不存在就加载
            au = Resources.Load<AudioClip>(path);
            //需要缓存就把它缓存起来
            if (cache)
            {
                audioDict.Add(path, au);
            }
        }

        return au;
    }
}