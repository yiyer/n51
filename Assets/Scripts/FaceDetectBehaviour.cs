using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceDetectBehaviour : MonoBehaviour
{

    string cameraName;
    WebCamDevice[] devices;
    WebCamTexture cameraTexture;
    bool isPlay;

    // Use this for initialization
    private static string sMainCamera = "HoloLensCamera";

    Plane pointHandler;
    Camera mainCamera;


    void Start()
    {
        mainCamera = GameObject.Find(sMainCamera).GetComponent<Camera>();
        StartCoroutine(StartCamera(mainCamera.pixelWidth, mainCamera.pixelHeight));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (isPlay)
        {
            GUI.DrawTexture(new Rect(0, 0, mainCamera.pixelWidth, mainCamera.pixelHeight), cameraTexture, ScaleMode.ScaleToFit);
        }


    }

    IEnumerator StartCamera(int mPreviewWidth = 320, int mPreviewHeight = 160, int mPreviewFPS = 30)
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);//调用外部摄像头  
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            devices = WebCamTexture.devices;
            if (0 != devices.Length)
            {
                cameraTexture = new WebCamTexture(devices[0].name, mPreviewWidth, mPreviewHeight, mPreviewFPS);

                cameraTexture.Play();
                isPlay = true;
            }
        }
    }


}
