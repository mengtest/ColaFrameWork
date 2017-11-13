using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I18N单条数据
/// </summary>
public class I18NData : LocalDataBase
{
    public string desStr;

    public override void InitWithStr(string strData, char splitChar = ',')
    {
        string[] strs = strData.Split(splitChar);

        id = this.GetInt(strs[0]);
        desStr = strs[1];
    }
}

/// <summary>
/// I18N数据集
/// </summary>
public class I18NDataMap : ScriptableObject,ILocalDataMapBase
{
    public Dictionary<int,I18NData> I18NDataList = new Dictionary<int, I18NData>();

    public void SetMapCsv(string[] rows)
    {
        throw new System.NotImplementedException();
    }
}