/****************************************************
    文件：BaseEvent.cs
	作者：Happy-11
    日期：2021年1月31日23:45:17
	功能：服务器分发事件客户端接收
*****************************************************/

//using Common;
using ExitGames.Client.Photon;
using UnityEngine;

public abstract class BaseEvent
{
    //public EventCode eventCode;
    public abstract void OnEvent(EventData eventData);


}