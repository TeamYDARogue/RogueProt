using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : SingletonMonoBehaviour<ResourceManager> {

    /// <summary>
    /// リソース管理データ
    /// </summary>
    class ResourceData
    {
        public string resourceName;
        public GameObject resource;

        public ResourceData(string name,GameObject resource)
        {
            resourceName = name;
            this.resource = resource;
        }
    }

    private GameObject[] m_resouce;
    private Dictionary<string, ResourceData> m_sceneResources;



    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        m_sceneResources = new Dictionary<string, ResourceData>();

    }

    /// <summary>
    /// 指定シーンのリソースを読み込む
    /// </summary>
    /// <param name="sceneName">シーンの名前</param>
    public void ResourcesLoad(string sceneName)
    {

        m_sceneResources.Clear();


        m_resouce = Resources.LoadAll<GameObject>("Prefabs/" + sceneName);
        foreach(var obj in m_resouce)
        {
            m_sceneResources.Add(obj.name, new ResourceData("Prefabs/" + obj.name, obj));
            Debug.Log(obj.name + "Loaded!!!");
        }

        m_resouce = null;
    }

    /// <summary>
    /// シーンに必要なリソースを取得する
    /// </summary>
    /// <param name="key">リソースの名前</param>
    /// <returns>リソース</returns>
    public GameObject GetResourceScene(string key)
    {
        if(m_sceneResources.ContainsKey(key))
        {
            return m_sceneResources[key].resource;
        }

        return null;
    }

    /// <summary>
    /// 読み込んだリソースを全て破棄する
    /// </summary>
    public void ResourcesUnLoad()
    {
        StartCoroutine(UnLoadResources());
    }

    /// <summary>
    /// ResourcesUnLoad関数を利用するべし。
    /// </summary>
    /// <returns></returns>
    IEnumerator UnLoadResources()
    {
        foreach(KeyValuePair<string,ResourceData> pair in m_sceneResources)
        {
            Resources.UnloadAsset(pair.Value.resource);
            yield return null;
        }
    }
}
