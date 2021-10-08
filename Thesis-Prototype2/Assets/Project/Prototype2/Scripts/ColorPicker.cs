using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProBuilder2.Common;

public class ColorPicker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject picker;
    Color col = new Color(0f, .7f, 1f, 1f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
        picker.GetComponent<Renderer>().material.color = other.GetComponent<Renderer>().material.color;
        col = other.GetComponent<Renderer>().material.color;
        pb_XYZ_Color xyz = pb_XYZ_Color.FromRGB(col);
        pb_CIE_Lab_Color lab = pb_CIE_Lab_Color.FromXYZ(xyz);
        //Calculate the xy values from the XYZ values

        //float x = X / (X + Y + Z); float y = Y / (X + Y + Z);
        //https://github.com/johnciech/PhilipsHueSDK/blob/master/ApplicationDesignNotes/RGB%20to%20xy%20Color%20conversion.md
        float x = xyz.x / (xyz.x + xyz.y + xyz.z);
        float y = xyz.y / (xyz.x + xyz.y + xyz.z);
        print(col);
        print(x);
        print(y);

        
    }
}
