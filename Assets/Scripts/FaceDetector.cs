using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class FaceDetector : MonoBehaviour
{
    WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect MyFace;
    OpenCvSharp.Rect OriginalFace;
    public float faceY;

    // Translation and Scaling factors
    public Vector3 facePositionOffset = new Vector3(0, 0, 0); // Adjust these values
    public float faceScaleFactor = 0.06f; // Adjust this value to 6%
    int screenHeight = Screen.height;

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            for (int i = 0; i < devices.Length; i++) {
                Debug.Log(devices[i].name + " , " + i.ToString());
            }
            _webCamTexture = new WebCamTexture(devices[0].name);
            _webCamTexture.requestedWidth = 640;
            _webCamTexture.requestedHeight = 480;
            _webCamTexture.Play();
            cascade = new CascadeClassifier(Application.dataPath + @"/Scripts/haarcascade_frontalface_default.xml");
        } else {
            Debug.LogError("No Webcam found");
        }
    }

    void Update()
    {
        if (_webCamTexture.didUpdateThisFrame && _webCamTexture != null)
        {
            Mat frame = OpenCvSharp.Unity.TextureToMat(_webCamTexture);
            findNewFace(frame);
            display(frame);
        }
    }

    void findNewFace(Mat frame)
    {
        if (frame != null)
        {
            var faces = cascade.DetectMultiScale(frame, 1.32, 5, HaarDetectionType.ScaleImage);
            if (faces.Length >= 1)
            {
                MyFace = faces[0];
                OriginalFace = faces[0];

                // Flip the y-coordinate to match Unity's coordinate system
                MyFace.Y = frame.Height - MyFace.Y - MyFace.Height;

                // Apply translation and scaling
                Vector3 facePosition = new Vector3(MyFace.X + MyFace.Width / 2, MyFace.Y + MyFace.Height / 2, 0);
                facePosition += facePositionOffset;
                // Debug.Log("face position before" + facePosition);
                facePosition *= faceScaleFactor;

                // Debug.Log("face position after" + facePosition);
                // Update faceY with the adjusted Y-coordinate
                // faceY = facePosition.y;

                // // Set the MyFace position to the adjusted position
                MyFace.X = (int)facePosition.x - MyFace.Width / 2;
                MyFace.Y = (int)(facePosition.y - MyFace.Height* 0.06f / 2 );
                faceY = MyFace.Y - 9;
            }
        }
    }

    void display(Mat frame)
    {
        if (OriginalFace != null)
        {
            frame.Rectangle(OriginalFace, new Scalar(250, 0, 0), 2);
        }
        Texture newTexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newTexture;
    }

    void OnDisable()
    {
        if (_webCamTexture != null)
        {
            _webCamTexture.Stop(); 
            _webCamTexture = null; 
        }

        if (cascade != null)
        {
            cascade.Dispose(); 
            cascade = null; 
        }
    }
}
