using UnityEngine;
using DG.Tweening;
using TiltFive;
using UnityEngine.UI;
using TMPro;

public class Locked_room : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isOpen = false;
    float rotationY = 0f;
    float doorspeed = 1f; // Speed at which the door opens/closes
    private bool doorFullState = true;

    public GameObject key;
    public GameObject canvasUI;
    public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;

    void Start()
    {
        canvasUI = GameObject.Find("CanvasUI");
        
    }

    // Update is called once per frame
    void Update()
    {
        key = GameObject.Find("Keys");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.One) || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E pressed.");
                if (key == null)
                {
                    if (!isOpen)
                    {
                        if (doorFullState)
                        {
                            Debug.Log("opening door.");
                            isOpen = true;
                            doorFullState = false;
                            doorOpenSound.Play();
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
                            isOpen = false;
                            doorFullState = false;
                            doorCloseSound.Play();
                            gameObject.transform.DORotate(new Vector3(0, -90, 0), 1f, RotateMode.WorldAxisAdd)
                            .OnComplete(() =>
                            {
                                doorFullState = true;
                            });
                        }
                    }

                    // Add code to close the door, e.g., play an animation or change the door's state
                }
                else
                {
                    canvasUI.GetComponent<TextMeshPro>().text = "Key Required!";
                    Debug.Log("Key required!");
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {  
        canvasUI.GetComponent<TextMeshPro>().text = "";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canvasUI.GetComponent<TextMeshPro>().text == "")
        {
            canvasUI.GetComponent<TextMeshPro>().text = "Press '1' to open/close the door";
            Debug.Log("Player entered the door trigger area.");
        }
        if (other.CompareTag("Player") && canvasUI.GetComponent<TextMeshPro>().text == "")
        {
            canvasUI.GetComponent<TextMeshPro>().text = "Press '1' to open/close the door";
        }
    }
}
