using Unity.VisualScripting;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject leftEyeCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the GameObjects for the left and right eye cameras by their names.
    }

    // Update is called once per frame
    void Update()
    {
        if (leftEyeCamera == null)
        {
            leftEyeCamera = GameObject.Find("Left Eye Camera");
        }
        transform.LookAt(leftEyeCamera.transform.position);
        transform.Rotate(180f, 0f, 180f); // rotate 180° on X axis
    }
}

