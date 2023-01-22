using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TogleManager : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    public GameObject profil1, profil2, profil3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void cekToggle()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        Debug.Log(toggle.name);
        if(toggle.name == "1")
        {

            profil1.SetActive(false);
            profil2.SetActive(true);
            profil3.SetActive(false);
        }
        else if(toggle.name == "2")
        {

            profil1.SetActive(false);
            profil2.SetActive(false);
            profil3.SetActive(true);
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
