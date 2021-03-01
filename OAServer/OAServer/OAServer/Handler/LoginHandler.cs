
using Photon.SocketServer;
using Common;
using Common.Tools;
using OAServer.Manager;

namespace OAServer.Handler
{
    class LoginHandler : BaseHandler
    {
        public LoginHandler()
        {
            opCode = OperationCode.Login;
        }
        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer clientPeer)
        {
            
            //从客户端发来的数据包中提取数据
            string account = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)UserCode.Account) as string;
            string password = DictTool.GetValue<byte, object>(operationRequest.Parameters, (byte)UserCode.password) as string;
            //从数据库中验证数据
            UserManager userManager = new UserManager();
            //这里暂时只验证账号密码是否完全正确，其他情况另行补充
            bool isSuccess = userManager.VerifyUser(account, password);

            
            //将结果打包，准备发给客户端
            OperationResponse response = new OperationResponse(operationRequest.OperationCode);
            if (isSuccess)
            {
                response.ReturnCode = (short)LoginCode.Success;
            }
            else
            {
                response.ReturnCode = (short)LoginCode.PasswordError;
            }

            clientPeer.SendOperationResponse(response, sendParameters);

            
        }
    }
}
