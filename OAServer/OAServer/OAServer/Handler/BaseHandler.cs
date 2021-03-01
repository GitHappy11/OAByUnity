
using Common;
using Photon.SocketServer;

namespace OAServer.Handler
{
    public abstract class BaseHandler
    {
        //来表明是处理客户端的哪一个请求
        public OperationCode opCode = OperationCode.Default;
        //处理客户端发来的数据   三个参数分别为，客户端发来的数据包，服务端的一些数据包设置，在服务端上该客户端的数据
        public abstract void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer clientPeer);
      
    }
}
