using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraPos;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos.position;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, cameraPos.eulerAngles.y, transform.eulerAngles.z);
    }
}
