using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// I18N单条数据
/// </summary>
public class I18NData : LocalDataBase
{
    public override void InitWithStr(string strData, char splitChar = ',')
    {
        throw new System.NotImplementedException();
    }
}

/// <summary>
/// I18N数据集
/// </summary>
public class I18NDataMap : ScriptableObject,ILocalDataMapBase
{
    public void SetMapCsv(string[] rows)
    {
        throw new System.NotImplementedException();
    }
}