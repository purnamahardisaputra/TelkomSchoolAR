using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcodeMulaiPelajaran : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void barcodeMulaiPelajaran()
    {
        PlayerPrefs.SetInt("Activity", 3);
    }

    
}
