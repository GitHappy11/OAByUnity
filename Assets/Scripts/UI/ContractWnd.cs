/****************************************************
    文件：ContractWnd.cs
	作者：Happy-11
    日期：2020年12月18日20:49:07
	功能：Nothing
*****************************************************/

using UnityEngine;


public class ContractWnd : WindowRoot
{
    public GameObject ContractInformationPage;
    public GameObject CreateContractPage;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //这里可以使用列表循环
            if (ContractInformationPage.activeSelf == true || CreateContractPage.activeSelf == true )
            {
                ClickClosePanel(ContractInformationPage);
                ClickClosePanel(CreateContractPage);
            }

        }

    }



}