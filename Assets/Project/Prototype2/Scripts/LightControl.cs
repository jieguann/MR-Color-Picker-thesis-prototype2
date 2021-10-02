using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;

public class LightControl : MonoBehaviour
{
    [Serializable]
    public class LightJson
    {
        public float bri;
        
    }
    LightJson lightControl = new LightJson();



    public Transform objectValue;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(LightHttpPost());
    }

    // Update is called once per frame
    void Update()
    {
        if (objectValue.hasChanged)
        {
            lightControl.bri = objectValue.position.y;
            string json = JsonUtility.ToJson(lightControl);
            byte[] myData = System.Text.Encoding.UTF8.GetBytes(json);
            using (UnityWebRequest www = UnityWebRequest.Put("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/4/state", myData))
            {
                //yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log("Upload complete!");
                }
            }
        }

    }

    

   
}



/*
public WWW POST()
    {
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        // convert json string to byte
        var formData = System.Text.Encoding.UTF8.GetBytes(jsonStr);

        www = new WWW(POSTAddUserURL, formData, postHeader);
        StartCoroutine(WaitForRequest(www));
        return www;
    }
    IEnumerator WaitForRequest(WWW data)
    {
        yield return data; // Wait until the download is done
        if (data.error != null)
        {
            MainUI.ShowDebug("There was an error sending request: " + data.error);
        }
        else
        {
            MainUI.ShowDebug("WWW Request: " + data.text);
        }
    }  
*/