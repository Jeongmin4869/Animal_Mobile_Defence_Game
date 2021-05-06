using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager 
{
    private static DataManager Instance;
    private Dictionary<int, RawData> dicData = new Dictionary<int, RawData>();

    private DataManager() { }

    public static DataManager GetInstance()
    {
        if (DataManager.Instance == null)
        {
            DataManager.Instance = new DataManager();
        }
        return DataManager.Instance;
    }

    public void LoadData<T>(string path) where T : RawData
    {
        var textAsset = Resources.Load<TextAsset>(path); // 잘 가져옴
        var json = textAsset.text;
        Debug.Log(json);
        var arrData = JsonConvert.DeserializeObject<T[]>(json);
        Debug.Log(arrData);
        foreach (var data in arrData)
        {
            if (!this.dicData.ContainsKey(data.id))
            {
                this.dicData.Add(data.id, (T)data);
            }
        }
    }


    public T GetData<T>(int key) where T : RawData
    {
        var data = this.dicData[key];
        return (T)data;
    }

}

