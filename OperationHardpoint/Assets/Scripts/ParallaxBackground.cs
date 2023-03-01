using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] Vector2 paraEffectMult; // X and Y modifers for how quickly the background image will move
    private Transform cameraTransform;
    private Vector3 lastCamPos;
    private void Start()
    {
        cameraTransform = Camera.main.transform; // fetch camera
        lastCamPos = cameraTransform.position; // get the starting position of the camera
    }

    private void LateUpdate()
    {
        Vector3 DeltaMove = cameraTransform.position - lastCamPos; // calculate how much the camera has moved

        transform.position += new Vector3(DeltaMove.x * paraEffectMult.x, DeltaMove.y * paraEffectMult.y, 0); // calculate how far the object should move
        lastCamPos = cameraTransform.position; // set cam position to new position

    }
}
