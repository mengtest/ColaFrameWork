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

    public int GetCount()
    {
        if (null == I18NDataList) return 0;
        return I18NDataList.Count;
    }

    public void SetMapCsv(string[] rows)
    {
        I18NDataList.Clear();

        for (int i = 0; i < rows.Length; i++)
        {
            I18NData data = new I18NData();
            data.InitWithStr(rows[i]);
            I18NDataList.Add(data.id,data);
        }
    }

    public I18NData GetDataById(int id)
    {
        I18NData data = null;
        if (null != I18NDataList)
        {
            I18NDataList.TryGetValue(id, out data);
        }
        return data;
    }
}