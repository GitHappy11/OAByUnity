/****************************************************
    文件：ContractWnd.cs
	作者：Happy-11
    日期：2020年12月18日20:49:07
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractWnd : WindowRoot
{
    public PanelContractInformation panelContractInformation;
    public PanelCreateContract panelCreateContract;


    public Transform scrollTransBybtnContract;

    private List<ContractData> contractDataLst;

    private void RefreshUI()
    {
        //刷新前先把之前的先删除
        for (int i = 0; i < scrollTransBybtnContract.childCount; i++)
        {
            Destroy(scrollTransBybtnContract.GetChild(i).gameObject);
        }


        for (int i = 0; i < contractDataLst.Count; i++)
        {
            GameObject btnContract = resSvc.LoadPrefab(PathDefine.btnContractPrefab, true);
            btnContract.transform.SetParent(scrollTransBybtnContract);
            btnContract.name += "_" + i;

            ContractData contractData = contractDataLst[i];


            SetText(GetTrans(btnContract.transform, "txtContractNumb"), contractData.name);


            Button btnDetailData = btnContract.GetComponent<Button>();
            btnDetailData.onClick.AddListener(() =>
            {
                ClickCustomerBtn(contractData);
            });




        }

    }


    public void ReqOpenWnd(List<ContractData> contractDataLst)
    {
        this.contractDataLst = contractDataLst;
        base.ReqOpenWnd();
    }

    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        RefreshUI();
    }

    protected override void CloseWndEvent()
    {
        base.CloseWndEvent();
        OARoot.Instance.AddLoading();
    }





    public void ClickCreateBtn()
    {
        panelCreateContract.ReqOpenWnd();
    }




    #region 预制体生成后的信息注入点击

    private void ClickCustomerBtn(ContractData contractData)
    {
        panelContractInformation.contractData = contractData;
        panelContractInformation.ReqOpenWnd();
    }

    #endregion



}