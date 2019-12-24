using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    float offsetY = 45f;
    float offsetZ = -40f;

    [SerializeField]
    GameObject Player;
    Vector3 cameraPosition;

    private void LateUpdate()
    {
        cameraPosition.y = Player.transform.position.y + offsetY;
        cameraPosition.z = Player.transform.position.z + offsetZ;

        transform.position = cameraPosition;
    }
}
