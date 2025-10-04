using UnityEngine;

public class BackgroundFollowCamera : MonoBehaviour
{
    private Transform cam;
    private Vector3 startPos;

    void Start()
    {
        cam = Camera.main.transform;
        startPos = transform.position;
    }

    void LateUpdate()
    {
        // Mantén el fondo pegado a la cámara en X e Y, pero conserva la Z
        transform.position = new Vector3(cam.position.x, cam.position.y, startPos.z);
    }
}
