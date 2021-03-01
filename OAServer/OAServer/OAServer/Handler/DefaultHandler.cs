using Common;
using Photon.SocketServer;

namespace OAServer.Handler
{
    class DefaultHandler:BaseHandler
    {
        public DefaultHandler()
        {
            opCode = OperationCode.Default;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer clientPeer)
        {
            ServerRoot.Instance.log.Info("未找到相应的Handler处理方法,错误操作代码："+(OperationCode)operationRequest.OperationCode);
        }
    }
}
