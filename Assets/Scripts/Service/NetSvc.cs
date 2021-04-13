/****************************************************
    文件：NetSvc.cs
	作者：Happy-11
    日期：2020年12月12日23:37:10
	功能：网络服务
*****************************************************/

using ExitGames.Client.Photon;
using System.Collections.Generic;
using UnityEngine;
using Common;


public class NetSvc : SystemRoot,IPhotonPeerListener 
{
    public static NetSvc Instance;

    //无法在Editor界面编辑
    [HideInInspector]
    public StatusCode statusCode;
    private StatusCode oldStatusCode;
    //保存所有的Request事件
    public Dictionary<OperationCode, Request> RequestDict = new Dictionary<OperationCode, Request>();
    //保存所有的Event事件
    public Dictionary<EventCode, BaseEvent> EventDict = new Dictionary<EventCode, BaseEvent>();
    private bool isReClient = false;
    public static PhotonPeer peer { get; private set; }


    #region 客户端连接服务端的方法
    private void ServerSetup()
    {
        //服务器初始化
        //通过Listender接收服务器端的响应(监听服务器的类就是this)  链接方式（Udp）
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        //设置链接的服务器IP和端口  要连接的服务器名
        peer.Connect("127.0.0.1:5055", "OA");

    }
    #endregion
    #region 监听服务器方法
    public void OnEvent(EventData eventData)
    {
        EventCode code = (EventCode)eventData.Code;
        BaseEvent e = null;

        if (EventDict.TryGetValue(code, out e))
        {
            e.OnEvent(eventData);
        }
      
    }
    public void OnOperationResponse(OperationResponse operationResponse)
    {
        OperationCode opCode = (OperationCode)operationResponse.OperationCode;
        Request request = null;
        bool temp = RequestDict.TryGetValue(opCode, out request);
        if (temp)
        {
            request.OnOperationResponse(operationResponse);
        }
        else
        {
           
        }

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
            //ServerSetup();
            //Debug.Log("正在重新连接");
        }

    }
    public void DebugReturn(DebugLevel level, string message)
    {
        
        if (oldStatusCode!=statusCode)
        {
            Debug.LogWarning("ServerInfo:" + "--Level:" + level + "--Message:" + message);
            oldStatusCode = statusCode;
        }
        
    }
    #endregion
    #region 服务器在Unity中运行的机制
    private void Start()
    {
        ServerSetup();
    }
    private void Update()
    {
        peer.Service(); 
    }
    #endregion
    #region 客户端处理事件响应的方法
    private void AddRequest(Request request)
    {
        Request _request = null;
        //将事件加入事件字典，等待处理
        if (RequestDict.TryGetValue(request.opCode,out _request))
        {
            OARoot.Instance.AddTips("操作过于频繁，请稍后。");
        }
        else
        {
            RequestDict.Add(request.opCode, request);
        }
        
    }

    private void RemoveRequest(Request request)
    {
        //处理完的事件移除事件字典
        RequestDict.Remove(request.opCode);
    }
#endregion

    //处理向服务端发出的请求
    public void SendRequset(OperationCode opCode,Dictionary<byte,object> data,Request request)
    {
        if (statusCode==StatusCode.Connect)
        {
            peer.OpCustom((byte)opCode, data, true);
            AddRequest(request);
        }
        //如果不是在连接状态就说明客户端是离线模式
        else
        {
            switch (opCode)
            {
                case OperationCode.Default:
                    break;
                case OperationCode.Login:
                    OARoot.Instance.AddTips("当前处于离线模式！无法登录，进入观赏UI模式，所有数据均为缓存数据，不具有时效性。");
                    LoginSys.Instance.RspLogin();
                    NetReqMainData netReqMainData = new NetReqMainData();
                    break;
                case OperationCode.MainData:
                    MainSys.Instance.EnterMain(LocalData.presentDataLst);
                    break;
                case OperationCode.Customer:
                    MainSys.Instance.EnterWTD(LocalData.customerDataLst);
                    break;
                case OperationCode.Trust:
                    MainSys.Instance.EnterKH(LocalData.trustDataLst);
                    break;

                default:
                    break;
            }

        }
        
    }
    //服务端向客户端的回应处理后的方法
    public void DeleteRequest(Request request)
    {
        RemoveRequest(request);
    }

    //网络服务初始化
    public override void InitSys()
    {
        Instance = this;
    }
}




