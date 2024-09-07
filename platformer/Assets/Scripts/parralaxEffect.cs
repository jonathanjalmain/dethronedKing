using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parralaxEffect : MonoBehaviour
{

    public Camera cam;
    public Transform followTarget;
    private Vector2 startingPosition;
    private float startingZDistance;
    private Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;
    private float zDistanceFromTarget => transform.position.z - followTarget.position.z;

    //le 1 représente la postion de la cam en z (cam.transform.position.z)
    private float clippingPlaneDistance => (1 + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    private float parralaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlaneDistance;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = new Vector2 (transform.position.x, transform.position.y);
        startingZDistance = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parralaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZDistance);
    }
}
