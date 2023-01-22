using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarcodeHalte : MonoBehaviour
{



    void Update()
    {

    }

    private void Awake()
    {

        // activityMain = 1;
    }

    public void barcodeHalte()
    {
        PlayerPrefs.SetInt("Activity", 2);
        GameObject.FindWithTag("MainCamera").GetComponent<CharacterController>().enabled = true;
        GameObject.FindWithTag("MainCamera").GetComponent<WalkingPedometer>().enabled = true;


    }


}
