/****************************************************
    文件：Request.cs
	作者：Happy-11
    日期：2021年1月31日23:48:34
	功能：客户端上传数据至服务端，以及客户端处理服务端发送的数据
*****************************************************/

using Common;
using ExitGames.Client.Photon;


public abstract class Request
{

    //标记此事件的操作类型（是干什么的）
    public OperationCode opCode=OperationCode.Default;
    //创建该事件的时候所做的操作（可带参数）
    public abstract void DefaultRequest();
    //服务端的回应处理（可带参数）
    public abstract void OnOperationResponse(OperationResponse operationResponse);

}