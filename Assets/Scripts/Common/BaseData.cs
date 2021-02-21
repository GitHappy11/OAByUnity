/****************************************************
    文件：BaseData.cs
	作者：Happy-11
    日期：2021年1月31日23:23:52
	功能：数据类基类
*****************************************************/


public class BaseData
{
    public int id;
}

//直接继承无法在外部拿到，需要填写泛型
public class TrustDetailData:BaseData
{
    public string trustNumb;
    public string trustContent;
    public string trustClass;
    public string trustClass2;
    public string date;
    public string team;
}

public class ElementData:BaseData
{
    public string date;
    public string title;
    public bool isNew;
}

public class CustomerData:BaseData
{
    public string name;
}

