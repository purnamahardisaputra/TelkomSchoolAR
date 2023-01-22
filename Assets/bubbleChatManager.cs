using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;
public class bubbleChatManager : MonoBehaviour
{
    [SerializeField] private GameObject chat1, chat2, chat3, chat4, chat5, chat6, buttonNext;

    private void Start()
    {
        chat1.SetActive(false);
        chat2.SetActive(false);
        chat3.SetActive(false);
        chat4.SetActive(false);
        chat5.SetActive(false);
        chat6.SetActive(false);
        buttonNext.SetActive(false);

        chat1.GetComponentInChildren<TMP_Text>().text = "Hello " + PlayerPrefs.GetString("name") + "!";

        StartCoroutine(chat1Coroutine());
    }

    IEnumerator chat1Coroutine()
    {
        chat1.SetActive(true);
        yield return new WaitForSeconds(3);
        chat2.SetActive(true);
        yield return new WaitForSeconds(3);
        chat3.SetActive(true);
        yield return new WaitForSeconds(3);
        chat1.SetActive(false);
        chat4.SetActive(true);
        yield return new WaitForSeconds(3);
        chat2.SetActive(false);
        chat5.SetActive(true);
        yield return new WaitForSeconds(3);
        chat3.SetActive(false);
        chat6.SetActive(true);
        yield return new WaitForSeconds(3);
        buttonNext.SetActive(true);
    }



}
