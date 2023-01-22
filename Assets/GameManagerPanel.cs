// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using UnityEngine.Animations;

// public class GameManagerPanel : MonoBehaviour
// {
//     private int _score = 0;
//     [SerializeField] private TMP_Text stepCount;
//     public int activityMain = 0;

//     private void Awake()
//     {
//         stepCount = GameObject.Find("Canvas/Step").GetComponent<TMP_Text>();
//         activityMain = 1;
//     }

//     public void barcodeHalte()
//     {
//         activityMain = 2;
//         StartCoroutine(barcodeHalteCouritine());
//     }

//     public void mulaiPelajaran()
//     {
//         activityMain = 3;
//     }

//     IEnumerator barcodeHalteCouritine()
//     {
//         int step = int.Parse(stepCount.text);
//         yield return new WaitUntil(() => activityMain == 3);
//         if (step >= 1000)
//         {
//             _score += 350;
//             PlayerPrefs.SetInt("Score", _score);
//         }
//         else if (step >= 500)
//         {
//             _score += 200;
//             PlayerPrefs.SetInt("Score", _score);
//         }
//         else if (step >= 100)
//         {
//             _score += 100;
//             PlayerPrefs.SetInt("Score", _score);
//         }
//         else
//         {
//             _score += 50;
//             PlayerPrefs.SetInt("Score", _score);
//         }
//         yield return new WaitForSeconds(2f);
//         StopAllCoroutines();
//     }
// }
