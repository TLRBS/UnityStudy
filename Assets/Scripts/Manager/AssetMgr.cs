using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetMgr {

    private Dictionary<string, GameObject> loadAssets = new Dictionary<string, GameObject>();

    private static AssetMgr ins;

    public const string UIPathStr = "Prefab/UI/";

    private readonly string TAG = "[AssetMgr]:";
    public static AssetMgr GetInstance()
    {
        if (ins == null)
        {
            ins = new AssetMgr();
        }

        return ins;
    }

    public GameObject LoadAsset(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            Debug.LogError(TAG +　"路径为空!");
            return null;
        }
        GameObject o = null;

        if (!loadAssets.ContainsKey(path))
        {
            // 新加载界面资源
            o = LoadAssetByResource(path);
            if (o == null)
            {
                Debug.LogError(TAG + "加载资源对象为空.");
            }            
        }
        else
        {
            // 已存在资源直接获取
            o = loadAssets[path];
        }
        return o;
    }

    private GameObject LoadAssetByResource(string path) {
        GameObject o;

        o = Resources.Load(path) as GameObject ;
        o = GameObject.Instantiate(o);
        return o;
    }
}
