using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 资源路径信息类
/// </summary>
class ResPathData:LocalDataBase
{
    public override void InitWithStr(string strData, char splitChar = ',')
    {
        throw new NotImplementedException();
    }
}


/// <summary>
/// ResPathData的数据集类
/// </summary>
class ResPathDataMap : ILocalDataMapBase
{
    public void SetMapCsv(string[] rows)
    {
        throw new NotImplementedException();
    }
}