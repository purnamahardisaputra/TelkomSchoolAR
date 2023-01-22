using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ProfilManager : MonoBehaviour
{
    public GameObject profilLaki, profilCewe;
    public TMP_Text nama, kelas, gender;
    // Start is called before the first frame update
    void Start()
    {
        nama.text = PlayerPrefs.GetString("name");
        kelas.text = PlayerPrefs.GetString("class");
        if (PlayerPrefs.GetString("gender") == "1")
        {
            profilLaki.SetActive(true);
            profilCewe.SetActive(false);
            gender.text = "Male";
        }else if (PlayerPrefs.GetString("gender") == "2")
        {
            profilLaki.SetActive(false);
            profilCewe.SetActive(true);
            gender.text = "Female";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void keluar()
    {
        SceneManager.LoadScene(0);
        PlayerPrefs.DeleteAll();
    }
}
