/****************************************************
    文件：NetSvc.cs
	作者：Happy-11
    日期：2020年12月12日23:37:10
	功能：网络服务
*****************************************************/

using ExitGames.Client.Photon;
using UnityEngine;


public class NetSvc : SystemRoot,IPhotonPeerListener 
{
    public static NetSvc Instance;

    //无法在Editor界面编辑
    [HideInInspector]
    public StatusCode statusCode;

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