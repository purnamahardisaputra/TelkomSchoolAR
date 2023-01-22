using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ToggleGroup toggleGroup;
    [SerializeField] private GameObject Login;
    [SerializeField] private GameObject panelSetup, panelHint, loading;
    [SerializeField] private TMP_Text _name, _class;

    private void firstSetup()
    {
        if (PlayerPrefs.HasKey("name") && PlayerPrefs.HasKey("class"))
        {
            panelSetup.SetActive(false);
            loading.SetActive(true);
        }
        else
        {
            panelSetup.SetActive(true);
            loading.SetActive(false);
        }


    }

    public void loginButton()
    {
        Toggle toggle = toggleGroup.ActiveToggles().FirstOrDefault();
        //Toggle toggle = toggleGroup.ActiveToggles().

        // Debug.Log(toggle.name + " - " + toggle.GetComponentInChildren<Text>().text);
        if (_name.text != "" && _class.text != "" && toggle.name != "")
        {
            PlayerPrefs.SetString("name", _name.text);
            PlayerPrefs.SetString("class", _class.text);
            PlayerPrefs.SetString("gender", toggle.name);


            Debug.Log("Name: " + PlayerPrefs.GetString("name"));
            Debug.Log("Class: " + PlayerPrefs.GetString("class"));
            Debug.Log("Gender: " + PlayerPrefs.GetString("gender"));

            panelHint.SetActive(true);
            panelSetup.SetActive(false);
        }





    }

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
    }

    private void Start()
    {
        firstSetup();
    }

    private void Update()
    {

    }




}
