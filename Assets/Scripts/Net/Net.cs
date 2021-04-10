/****************************************************
    文件：Net.cs
	作者：Happy-11
    日期：2021年1月31日23:42:23
	功能：客户端的请求和服务器的响应
*****************************************************/



using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common;


public class NetLogin:Request
{
    private readonly string _account;
    private readonly string _password;
    //初始化
    public NetLogin(string account,string password)
    {
        opCode = OperationCode.Login;
        _account = account;
        _password = password;
        DefaultRequest();
    }
    //发送带参数事件给服务端
    public override void DefaultRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)UserCode.Account, _account);
        data.Add((byte)UserCode.password, _password);
        NetSvc.Instance.SendRequset(opCode, data, this);
    }

    //服务端回应
    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        switch ((LoginCode)operationResponse.ReturnCode)
        {
            case LoginCode.Success:
                OARoot.Instance.AddTips("登录成功！");
                LoginSys.Instance.RspLogin();
                NetReqMainData netReqMainData = new NetReqMainData();
                break;
            case LoginCode.AccountNothing:
                OARoot.Instance.AddTips("账号不存在！");
                break;
            case LoginCode.PasswordError:
                OARoot.Instance.AddTips("账号和密码不匹配！");
                break;
            case LoginCode.Online:
                OARoot.Instance.AddTips("该账号已经在线！");
                break;
            default:
                break;
        }
        NetSvc.Instance.DeleteRequest(this);
    }
}

public class NetReqMainData : Request
{

    public NetReqMainData()
    {
        opCode = OperationCode.MainData;


        PresentData pd = new PresentData
        {
            id = 11,
            date = "202104110000",
            projectName = "三维建模",
            userName = "Happy-11"

        };

        List<PresentData> PresentDataLst = new List<PresentData>();
        PresentDataLst.Add(pd);
        PresentDataLst.Add(pd);
        PresentDataLst.Add(pd);
        PresentDataLst.Add(pd);
        PresentDataLst.Add(pd);
        PresentDataLst.Add(pd);
        PresentDataLst.Add(pd);
        PresentDataLst.Add(pd);
        PresentDataLst.Add(pd);
        LocalData.presentDataLst = PresentDataLst;


        DefaultRequest();
    }

    public override void DefaultRequest()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        
        NetSvc.Instance.SendRequset(opCode, data, this);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }

    //假设已经接收到了服务器的数据
    public void ReqTrustDetailData()
    {
        


       
    }
}

public class NetReqTaskList:Request
{
    public override void DefaultRequest()
    {
        throw new System.NotImplementedException();
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }

    //假设已经接收到了服务器的数据
    public void ReqTrustDetailData()
    {
        TrustDetailData trustDetailData = new TrustDetailData
        {
            id = 1000000,
            trustNumb="202102062231",
            trustContent="某某路，某某街，项目建设用地",
            trustClass="水面",
            trustClass2="用水勘测定界",
            date="已经进行作业：100日",
            team="Happy11"
        };

        List<TrustDetailData> trustDetailDatasLst = new List<TrustDetailData>();
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);
        trustDetailDatasLst.Add(trustDetailData);

        ElementData elementData = new ElementData
        {
            date = "202102062231",
            title = "Unity游戏开发计划外包合同",
            isNew = false,
        };

        List<ElementData> elementDatasLst = new List<ElementData>();
        elementDatasLst.Add(elementData);


        MainSys.Instance.EnterTaskList(trustDetailDatasLst, elementDatasLst);
    }
    
}

public class NetReqCustomer : Request
{
    public override void DefaultRequest()
    {
        throw new System.NotImplementedException();
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }

    public void ReqCustomerData()
    {
        CustomerData customerData = new CustomerData
        {
            id = 100,
            name = "东相上工作室",
        };

        List<CustomerData> customerDataLst = new List<CustomerData>();
        customerDataLst.Add(customerData);

        MainSys.Instance.EnterWTD(customerDataLst);
    }
}

public class NetReqContract:Request
{
    public override void DefaultRequest()
    {
        throw new System.NotImplementedException();
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }

    public void ReqContractData()
    {
        ContractData contractData = new ContractData
        {
            id = 0,
            name = "Test-2021-001"
        };
        List<ContractData> contractDataLst = new List<ContractData>();
        contractDataLst.Add(contractData);
        contractDataLst.Add(contractData);
        contractDataLst.Add(contractData);
        contractDataLst.Add(contractData);
        contractDataLst.Add(contractData);
        contractDataLst.Add(contractData);
        contractDataLst.Add(contractData);
        contractDataLst.Add(contractData);
        MainSys.Instance.EnterHT(contractDataLst);
    }
}

public class NetReqTrust:Request
{
    public override void DefaultRequest()
    {
        throw new System.NotImplementedException();
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }

    public void ReqTrustData()
    {


        TrustData trustData = new TrustData()
        {
            id = 1,
            date = "202102222007"
        };
        List<TrustData> trustDataLst = new List<TrustData>();
        trustDataLst.Add(trustData);
        trustDataLst.Add(trustData);
        trustDataLst.Add(trustData);
        trustDataLst.Add(trustData);
        trustDataLst.Add(trustData);
        trustDataLst.Add(trustData);
        trustDataLst.Add(trustData);
        trustDataLst.Add(trustData);
        MainSys.Instance.EnterKH(trustDataLst);
    }
}
