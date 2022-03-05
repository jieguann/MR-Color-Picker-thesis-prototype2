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
        public float[] xy;
        
    }
    LightJson lightControl = new LightJson();
    public ColorPicker picker;
    
    void Start()
    {
        lightControl.xy = new float[2];
        
    }

    //Access this for other to control light
    public IEnumerator HttpPutLight(float x, float y)
    {
            lightControl.xy[0] = x;
            lightControl.xy[1] = y;
            lightControl.bri = 100;
            updateLight();
            //picker.b = false;
        
            yield return null;
    }

   private void updateLight()
    {
        httpPostLight("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/4/state");
        httpPostLight("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/3/state");
        httpPostLight("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/2/state");
        httpPostLight("http://192.168.2.49/api/zx9NNIegikmyEgZZOQmR-FTTzTomumRr4nzjyoWc/lights/1/state");
       
    }

    private void httpPostLight(string url)
    {
        var client = new HttpClient();
        string json = JsonUtility.ToJson(lightControl);
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        client.Put(new Uri(url), content, HttpCompletionOption.AllResponseContent, r =>
        {   // This callback is raised when the request completes
            if (r.IsSuccessStatusCode)
            {    // Read the response content as a string if the server returned a success status code
                string responseData = r.ReadAsString();
                //print(responseData);
            }
        });
    }
   

}

    