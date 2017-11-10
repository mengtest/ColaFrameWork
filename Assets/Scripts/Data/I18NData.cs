using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I18NData : LocalDataBase
{
    public override void InitWithStr(string strData, char splitChar = ',')
    {
        throw new System.NotImplementedException();
    }
}


public class I18NDataMap : ILocalDataMapBase
{
    public void SetMapCsv(string[] rows)
    {
        throw new System.NotImplementedException();
    }
}