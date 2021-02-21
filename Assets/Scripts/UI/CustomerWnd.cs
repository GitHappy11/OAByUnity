/****************************************************
    文件：CustomerWnd.cs
	作者：Happy-11
    日期：2020年12月18日20:49:20
	功能：Nothing
*****************************************************/

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerWnd : WindowRoot 
{
    public PanelCreateCustomer panelCreateCustomer;
    public PanelCustomerEdit panelCustomerEdit;


    public Transform scrollTransBybtnCustomer;
  
    private List<CustomerData> customerDataLst;

    private void RefreshUI()
    {
        //刷新前先把之前的先删除
        //for (int i = 0; i < scrollTransBybtnCustomer.childCount; i++)
        //{
        //    Destroy(scrollTransBybtnCustomer.GetChild(i).gameObject);
        //}
   

        for (int i = 0; i < customerDataLst.Count; i++)
        {
            GameObject btnDetailDataPrefab = resSvc.LoadPrefab(PathDefine.btnCustomerPrefab, true);
            btnDetailDataPrefab.transform.SetParent(scrollTransBybtnCustomer);
            btnDetailDataPrefab.name += "_" + i;

            CustomerData customerData = customerDataLst[i];


            SetText(GetTrans(btnDetailDataPrefab.transform, "txtCompanyName"), customerData.name);
     

            Button btnDetailData = btnDetailDataPrefab.GetComponent<Button>();
            btnDetailData.onClick.AddListener(() =>
            {
                ClickCustomerBtn(customerData);
            });




        }
       
    }


    public void ReqOpenWnd(List<CustomerData> customerDataLst)
    {
        this.customerDataLst = customerDataLst;
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
        panelCreateCustomer.ReqOpenWnd();
    }




    #region 预制体生成后的信息注入点击

    private void ClickCustomerBtn(CustomerData customerData)
    {
        panelCustomerEdit.customerData = customerData;
        panelCustomerEdit.ReqOpenWnd();
    }

    #endregion






}