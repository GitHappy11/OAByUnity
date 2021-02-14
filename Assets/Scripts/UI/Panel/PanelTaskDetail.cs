/****************************************************
    文件：PanelTaskDetail.cs
	作者：Happy-11
    日期：2021年1月31日22:06:22
	功能：Nothing
*****************************************************/

using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PanelTaskDetail : WindowRoot 
{

    public InputField iptTeam;
    public TrustDetailData trustDetailData;
    


    protected override void OpenWndEvent()
    {
        base.OpenWndEvent();
        

        iptTeam.text = trustDetailData.team;
    }
}