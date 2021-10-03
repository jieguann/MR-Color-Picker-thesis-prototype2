using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using System;
using CI.HttpClient;
public class LightControl : MonoBehaviour
{
    [Serializable]
    public class LightJson
    {
        public int bri;
        
    }
    LightJson lightControl = new LightJson();
    
    public Transform objectValue;
    // Start is called before the first frame update
    void Start()
    {
        lightControl.bri = 255;
        string json = JsonUtility.ToJson(lightControl);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        //StartCoroutine(LightHttpPost());
        var client = new HttpClient();
        client.Put(new Uri("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/4/state"), content, HttpCompletionOption.AllResponseContent, r =>
        {
            // This callback is raised when the request completes
            if (r.IsSuccessStatusCode)
            {
                // Read the response content as a string if the server returned a success status code
                string responseData = r.ReadAsString();
                
                print(responseData);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

        
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