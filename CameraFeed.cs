using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFeed : MonoBehaviour

{
    WebCamTexture Texture;

    // Start is called before the first frame update
    void Start()
    {
        Texture = new WebCamTexture();
        GetComponent<Renderer>().material.mainTexture = Texture;
        Texture.requestedFPS = 30;
        Texture.requestedHeight = 1080;
        Texture.requestedWidth = 1920;
        Texture.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
