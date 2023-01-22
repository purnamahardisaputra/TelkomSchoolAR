using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MultiTargetManager : MonoBehaviour
{
    [SerializeField] private ARTrackedImageManager arTrackedImageManager;
    [SerializeField] private GameObject[] arModelsToPlace;
    private Dictionary<string, GameObject> arModels = new Dictionary<string, GameObject>();
    private Dictionary<string, bool> modelStates = new Dictionary<string, bool>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var arModel in arModelsToPlace)
        {
            GameObject newARModel = Instantiate(arModel, Vector3.zero, Quaternion.identity);
            newARModel.name = arModel.name;
            arModels.Add(arModel.name, newARModel);
            newARModel.SetActive(false);
            modelStates.Add(arModel.name, false);
        }
    }

    private void OnEnable()
    {
        arTrackedImageManager.trackedImagesChanged += imageFound;
    }

    private void OnDisable()
    {
        arTrackedImageManager.trackedImagesChanged -= imageFound;
    }

    private void imageFound(ARTrackedImagesChangedEventArgs eventData)
    {
        foreach (var trackedImage in eventData.added)
        {
            ShowARModel(trackedImage);
        }
        foreach (var trackedImage in eventData.updated)
        {
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                if (modelStates[trackedImage.referenceImage.name])
                {
                    ShowARModel(trackedImage);
                    
                }
            }
            else if (trackedImage.trackingState == TrackingState.Limited)
            {
                HideARModel(trackedImage);
            }
        }
    }

    private void ShowARModel(ARTrackedImage trackedImage)
    {
        bool isModelActive = arModels[trackedImage.referenceImage.name].activeSelf;
        if (!isModelActive)
        {
            GameObject arModel = arModels[trackedImage.referenceImage.name];
            arModel.transform.position = trackedImage.transform.position;
            arModel.SetActive(true);
            modelStates[trackedImage.referenceImage.name] = true;
        }
        else
        {
            GameObject arModel = arModels[trackedImage.referenceImage.name];
            arModel.transform.position = trackedImage.transform.position;
        }
    }

    private void HideARModel(ARTrackedImage trackedImage)
    {
        bool isModelActive = arModels[trackedImage.referenceImage.name].activeSelf;
        if (isModelActive)
        {
            GameObject arModel = arModels[trackedImage.referenceImage.name];
            arModel.transform.position = trackedImage.transform.position;
            arModel.SetActive(false);
            modelStates[trackedImage.referenceImage.name] = false;
        }
    }

    private void Update()
    {
        // arModelsToPlace[]
    }

}
