/****************************************************
    文件：BaseData.cs
	作者：Happy-11
    日期：2021年1月31日23:23:52
	功能：数据类基类
*****************************************************/


public class BaseData<T>  
{
    public int id;
}

//直接继承无法在外部拿到，需要填写泛型
public class TrustDetailData:BaseData<TrustDetailData>
{
    public string groupName;
}