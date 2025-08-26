using UnityEngine;
using DG.Tweening;
using TiltFive;
using UnityEngine.UI;
using TMPro;

public class DoorTrig : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isOpen = false;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
    float rotationY = 0f;
    float doorspeed = 1f; // Speed at which the door opens/closes
    private bool doorFullState = true;
    private GameObject ui;

    void Start()
    {
        ui = GameObject.Find("CanvasUI");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.GetComponent<TextMeshPro>().text = "Press A to open/close the door";
            Debug.Log("Player entered the door trigger area.");
            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A) || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed.");
                if (!isOpen)
                {
                    if (doorFullState)
                    {
                        Debug.Log("opening door.");
                        doorOpenSound.Play();
                        isOpen = true;
                        doorFullState = false;
                        gameObject.transform.DORotate(new Vector3(0, 90, 0), 1f, RotateMode.WorldAxisAdd)
                        .OnComplete(() =>
                        {
                            doorFullState = true;
                        });
                    }

                    // Add code to open the door, e.g., play an animation or change the door's state
                }
                else
                {
                    if (doorFullState)
                    {
                        Debug.Log("closing door.");
                        doorCloseSound.Play();
                        isOpen = false;
                        doorFullState = false;
                        gameObject.transform.DORotate(new Vector3(0, -90, 0), 1f, RotateMode.WorldAxisAdd)
                        .OnComplete(() =>
                        {
                            doorFullState = true;
                        });
                    }

                    // Add code to close the door, e.g., play an animation or change the door's state
                }
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        ui.GetComponent<TextMeshPro>().text = "";
    }
}
