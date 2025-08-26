using UnityEngine;

public class CameraDisplay : MonoBehaviour
{
    void Start()
    {
        // Enable additional displays
        if (Display.displays.Length > 1)
        {
            Display.displays[1].Activate(); // activates Display 2
        }

        // Assign this camera to Display 2
        Camera cam = GetComponent<Camera>();
        cam.targetDisplay = 1; // 0 = Display 1, 1 = Display 2, etc.
    }
}
