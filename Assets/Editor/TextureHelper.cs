using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Texture 工具类
/// </summary>
public static class TextureHelper
{

    [MenuItem("Tools/生成图片的Alpah通道数据")]
    public static void GenTextureAlpha()
    {
        //获取选中的资源
        object[] selections = Selection.GetFiltered(typeof(Texture2D), SelectionMode.DeepAssets);
        //遍历选中项
        foreach (var selection in selections)
        {
            Texture2D texture2D = selection as Texture2D;
            string asspath = AssetDatabase.GetAssetPath(texture2D);
            TextureImporter textureImporter = AssetImporter.GetAtPath(asspath) as TextureImporter;
            textureImporter.isReadable = true;
            AssetDatabase.ImportAsset(asspath, ImportAssetOptions.ForceUpdate);

            //抽取出Alpha通道信息
            if (null != texture2D)
            {
                Color32[] colorData = texture2D.GetPixels32();
                byte []alphaData = new byte[colorData.Length];

                for (int i = 0; i < colorData.Length; i++)
                {
                    alphaData[i] = colorData[i].a;
                }

                string path = AssetDatabase.GetAssetPath(texture2D);
                File.WriteAllBytes(path+".alpha.bytes",alphaData);
            }
        }
    }
}
