using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultiTarget : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager aRTrackedImageManager;
    [SerializeField] private GameObject[] aRModelsToPlace;
    [SerializeField] private TMP_Text Activity;
    [SerializeField] private TMP_Text Score;
    [SerializeField] private int currentActivity;
    [SerializeField] CharacterController controller;
    [SerializeField] WalkingPedometer walkingPedometer;

    // private int _score = 0;
    // [SerializeField] private TMP_Text stepCount;

    private Dictionary<string, GameObject> aRModels = new Dictionary<string, GameObject>();
    private Dictionary<string, bool> modelState = new Dictionary<string, bool>();
    // private bool halteActive = false;

    private void Awake()
    {

    }

    private void Start()
    {
        foreach (var aRModel in aRModelsToPlace)
        {
            GameObject newARModel = Instantiate(aRModel, Vector3.zero, Quaternion.identity);
            newARModel.name = aRModel.name;
            aRModels.Add(aRModel.name, newARModel);
            newARModel.SetActive(false);
            modelState.Add(aRModel.name, false);
        }
        currentActivity = 1;
        PlayerPrefs.SetInt("Activity", currentActivity);
    }

    private void Update()
    {
        if (scorewait == false)
        {
            StartCoroutine(scoreWait());
        }
        if (activitywait == false)
        {
            StartCoroutine(activityWait());
        }

        // if (PlayerPrefs.GetInt("Activity", 0) == 3 && halteActive == false)
        // {
        //     StartCoroutine(barcodeHalteCouritine());
        //     if (halteActive == true)
        //     {
        //         StopCoroutine(barcodeHalteCouritine());
        //     }
        // }

    }

    bool scorewait = false;
    bool activitywait = false;

    IEnumerator scoreWait()
    {
        Score.text = "Score: " + PlayerPrefs.GetInt("Score", 0);
        Debug.Log("Score: " + PlayerPrefs.GetInt("Score", 0));
        scorewait = true;
        yield return new WaitForSeconds(10f);
        StopCoroutine(scoreWait());
        scorewait = false;
    }

    IEnumerator activityWait()
    {
        Activity.text = "Activity: " + PlayerPrefs.GetInt("Activity", 0);
        Debug.Log("Activity: " + PlayerPrefs.GetInt("Activity", 0));
        activitywait = true;
        yield return new WaitForSeconds(10f);
        StopCoroutine(activityWait());
        activitywait = false;
    }

    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += ImageFound;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= ImageFound;
    }

    // IEnumerator barcodeHalteCouritine()
    // {
    //     halteActive = true;
    //     int step = int.Parse(stepCount.text);
    //     Debug.Log("step: " + step);
    //     yield return new WaitUntil(() => PlayerPrefs.GetInt("Activity", 0) == 3);
    //     Debug.Log("Coruutine jalan");
    //     if (step >= 1000)
    //     {
    //         _score += 500;
    //         PlayerPrefs.SetInt("Score", _score);
    //     }
    //     else if (step >= 500)
    //     {
    //         _score += 500;
    //         PlayerPrefs.SetInt("Score", _score);
    //     }
    //     else if (step >= 100)
    //     {
    //         _score += 100;
    //         PlayerPrefs.SetInt("Score", _score);
    //     }
    //     else
    //     {
    //         _score += 50;
    //         PlayerPrefs.SetInt("Score", _score);
    //     }
    //     yield return new WaitForSeconds(2f);
    // }

    private void ImageFound(ARTrackedImagesChangedEventArgs eventData)
    {
        foreach (var trackedImage in eventData.added)
        {
            ShowARModel(trackedImage);
        }
        foreach (var trackedImage in eventData.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                ShowARModel(trackedImage);
            }
            else if (trackedImage.trackingState == TrackingState.Limited)
            {
                HideARModel(trackedImage);
            }
        }
    }

    private void ShowARModel(ARTrackedImage trackedImage)
    {
        bool isModelActivated = modelState[trackedImage.referenceImage.name];
        if (!isModelActivated)
        {
            GameObject aRModel = aRModels[trackedImage.referenceImage.name];
            aRModel.transform.position = trackedImage.transform.position;
            aRModel.SetActive(true);
            modelState[trackedImage.referenceImage.name] = true;
            if (aRModels[trackedImage.referenceImage.name].name == "barcodemulaipelajaran" || aRModels[trackedImage.referenceImage.name].name == "ktm")
            {
                controller.enabled = false;
                walkingPedometer.enabled = false;
            }
        }
        else
        {
            GameObject aRModel = aRModels[trackedImage.referenceImage.name];
            aRModel.transform.position = trackedImage.transform.position;
        }
    }

    private void HideARModel(ARTrackedImage trackedImage)
    {
        bool isModelActivated = modelState[trackedImage.referenceImage.name];
        if (isModelActivated)
        {
            GameObject aRModel = aRModels[trackedImage.referenceImage.name];
            aRModel.transform.position = trackedImage.transform.position;
            aRModel.SetActive(false);
            modelState[trackedImage.referenceImage.name] = false;
        }
    }

}
