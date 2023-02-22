using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Starting object for the camera to follow
    [SerializeField] private Transform player;

    [SerializeField] float zoomFactor = 1.0f;

    [SerializeField] float zoomSpeed = 5.0f;

    private float originalSize = 0f;

    private Camera thisCamera;

    void Start()
    {

        thisCamera = GetComponent<Camera>(); // grab camera component
        originalSize = thisCamera.orthographicSize; // grab default size
    }
    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z); // update camera position
        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
        }
    }

    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }

    public void UpdatePlayer(Transform newPlayer) // Change camera follow target
    {
        player = newPlayer;
    }
}
