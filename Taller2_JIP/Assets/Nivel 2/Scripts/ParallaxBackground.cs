using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [System.Serializable]
    public class ParallaxLayer
    {
        public Transform layer;       // El objeto (sprite)
        public float parallaxFactor;  // Qué tan lento se mueve (0 = fijo, 1 = igual que cámara)
    }

    public ParallaxLayer[] layers;
    private Transform cam;
    private Vector3 lastCamPos;

    void Start()
    {
        cam = Camera.main.transform;
        lastCamPos = cam.position;
    }

    void LateUpdate()
    {
        Vector3 delta = cam.position - lastCamPos;
        foreach (var l in layers)
        {
            if (l.layer != null)
                l.layer.position += new Vector3(delta.x * l.parallaxFactor, delta.y * l.parallaxFactor, 0);
        }
        lastCamPos = cam.position;
    }
}
