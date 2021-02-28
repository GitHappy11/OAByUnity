/****************************************************
    文件：NetSvc.cs
	作者：Happy-11
    日期：2020年12月12日23:37:10
	功能：网络服务
*****************************************************/

using ExitGames.Client.Photon;
using System;
using UnityEngine;


public class NetSvc : SystemRoot,IPhotonPeerListener 
{
    public static NetSvc Instance;

    //无法在Editor界面编辑
    [HideInInspector]
    public StatusCode statusCode;
    private bool isReClient = false;

    private PhotonPeer peer;

    public override void InitSys()
    {
        Instance = this;
    }

    

    private void ServerSetup()
    {
        //服务器初始化
        //通过Listender接收服务器端的响应(监听服务器的类就是this)  链接方式（Udp）
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        //设置链接的服务器IP和端口  要连接的服务器名
        peer.Connect("127.0.0.1:5055", "OA");

    }
    #region 监听服务器方法
    public void OnEvent(EventData eventData)
    {
       
    }

    public void OnOperationResponse(OperationResponse operationResponse)
    {
        
    }
    //服务器状态改变的时候执行的方法
    public void OnStatusChanged(StatusCode statusCode)
    {
        this.statusCode = statusCode;
        switch (statusCode)
        {
            case StatusCode.Connect:
                OARoot.Instance.AddDynTips("服务器链接成功！", "服务器连接状态");
                isReClient = false;
                break;
            case StatusCode.Disconnect:
                if (isReClient==false)
                {
                    OARoot.Instance.AddDynTips("当前网络状态不佳，无法连接服务器，正在重新链接！进入离线模式！", "服务器连接状态");
                }
                isReClient = true;
                break;
            case StatusCode.Exception:
                break;
            case StatusCode.ExceptionOnConnect:
                break;
            case StatusCode.SecurityExceptionOnConnect:
                break;
            case StatusCode.QueueOutgoingReliableWarning:
                break;
            case StatusCode.QueueOutgoingUnreliableWarning:
                break;
            case StatusCode.SendError:
                break;
            case StatusCode.QueueOutgoingAcksWarning:
                break;
            case StatusCode.QueueIncomingReliableWarning:
                break;
            case StatusCode.QueueIncomingUnreliableWarning:
                break;
            case StatusCode.QueueSentWarning:
                break;
            case StatusCode.ExceptionOnReceive:
                break;
            case StatusCode.TimeoutDisconnect:
                break;
            case StatusCode.DisconnectByServer:
                break;
            case StatusCode.DisconnectByServerUserLimit:
                break;
            case StatusCode.DisconnectByServerLogic:
                break;
            case StatusCode.EncryptionEstablished:
                break;
            case StatusCode.EncryptionFailedToEstablish:
                break;
            default:
                break;
        }
        if (isReClient)
        {
            ServerSetup();
        }

    }
    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.LogWarning("ServerInfo:" + "--Level:" + level + "--Message:" + message);
    }
    #endregion





    private void Start()
    {
        ServerSetup();
    }
    private void Update()
    {

        peer.Service();
        
    }

}

//服务器响应后回调（测试使用）


