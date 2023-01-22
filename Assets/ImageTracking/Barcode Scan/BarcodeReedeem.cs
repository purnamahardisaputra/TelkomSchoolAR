using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarcodeReedeem : MonoBehaviour
{
    [SerializeField] private TMP_Text Activity;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBarcodeScan()
    {
        PlayerPrefs.SetInt("Activity", 7);
        int scre = PlayerPrefs.GetInt("Score", 0);
        if (scre >= 700)
            PlayerPrefs.SetInt("Score", scre - 700);
        else
            Activity.text = "Not enough points";

    }
}
