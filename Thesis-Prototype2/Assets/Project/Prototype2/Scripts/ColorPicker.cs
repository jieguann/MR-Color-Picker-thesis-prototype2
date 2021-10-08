using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProBuilder2.Common;

public class ColorPicker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject picker;
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
        print(other.GetComponent<Renderer>().material.color);
    }
}
