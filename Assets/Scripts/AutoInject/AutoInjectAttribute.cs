using System;
using System.Reflection;


/// <summary>
/// 自动注入标签（打上该标签的都可以参与自动注入）
/// </summary>
public class AutoInjectAttribute : Attribute
{
    public string name { set; get; }
    public Type type { set; get; }
    public FieldInfo fi { set; get; }
    public AutoInjectAttribute(string name = null)
    {
        this.name = name;
    }
}
