using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;
    [SerializeField] float zoomOutSpeed = 10.0f;
    [SerializeField] float zoomInSpeed = 5.0f;
    [SerializeField] float maxZoomOutSize = 10.0f;
    [SerializeField] float minZoomInSize = 5.0f;
    [SerializeField] float defaultZoom;
    float zoomLevel;
    float zoomSet;
    float playerSpeed;
    private Rigidbody2D playerRigidbody;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        zoomSet = 12.5f;
    }

    private void Update()
    {
        playerSpeed = playerRigidbody.velocity.magnitude;

        // Zoom out when the player is moving fast
        if (playerSpeed > zoomOutSpeed)
        {
            zoomLevel = Mathf.Clamp(defaultZoom * playerSpeed / zoomOutSpeed, defaultZoom, maxZoomOutSize);
            if (zoomSet < zoomLevel) 
                Invoke("IncreaseZoom", 0.01f);
            virtualCamera.m_Lens.OrthographicSize = zoomSet;
            
        }
        // Zoom in when the player is moving slow
        else if (playerSpeed < zoomInSpeed)
        {
            zoomLevel = Mathf.Clamp(defaultZoom * playerSpeed / zoomInSpeed, minZoomInSize, defaultZoom);
            if (zoomSet > zoomLevel) 
                Invoke("DecreaseZoom", 0.01f);
            virtualCamera.m_Lens.OrthographicSize = zoomSet;
        }
    }

    void IncreaseZoom () {
        zoomSet += 0.01f;
    }

    void DecreaseZoom () {
        zoomSet -= 0.01f;
    }
}
