using System;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace OAServer
{
    public class Peer : ClientPeer
    {
        public Peer(InitRequest initRequest):base(initRequest)
        {

        }

        //客户端断开的操作（一般做一些清理操作）
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            
        }

        //客户端链接上的操作
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            
        }
    }
}
