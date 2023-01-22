using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcodeSelesaiPraktikum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void barcodeSelesaiPraktikum()
    {
        PlayerPrefs.SetInt("Activity", 6);
        int scre = PlayerPrefs.GetInt("Score", 0);
        PlayerPrefs.SetInt("Score", scre + 250);
    }
}
