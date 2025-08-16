using UnityEngine;

public class DoorTrig : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isOpen = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered the door trigger area.");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed.");
                if (!isOpen)
                {
                    Debug.Log("opening door.");
                    isOpen = true;
                    gameObject.transform.Rotate(new Vector3(0, 110, 0));
                    // Add code to open the door, e.g., play an animation or change the door's state
                }
                else
                {
                    Debug.Log("closing door.");
                    isOpen = false;
                    gameObject.transform.Rotate(new Vector3(0, -110, 0));
                    // Add code to close the door, e.g., play an animation or change the door's state
                }
            }
        }
    }
}
