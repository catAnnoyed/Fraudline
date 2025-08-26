using DG.Tweening;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TiltFive;
using TMPro;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] doors;
    public bool[] opened;
    public TextMeshPro[] UI;
    public cutScenes cutScenes;
    public ScenePreloader scenePreloader;

    void Start()
    {
        opened = new bool[3];
        GetComponent<Renderer>().enabled = false;
        for (int i = 0; i < 3; i++)
        {
            opened[i] = false;
            UI[i].gameObject.SetActive(false);
        }
        scenePreloader.PreloadScene("dialog1");
    }

    void Update()
    {
        if (GlobalInventoryManagerScript.Instance.phase == 2)
        {
            GetComponent<Renderer>().enabled = true;
        }
        if (!opened[1] && opened[2] && opened[3])
        {
            //won
        }
    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("collide");
        if (other.gameObject.CompareTag("button") && GlobalInventoryManagerScript.Instance.phase == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                if (other.gameObject.name == buttons[i].name && !opened[i])
                {
                    UI[i].gameObject.SetActive(true);
                }
                if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("key pressed");
                    Debug.Log(other.gameObject);

                    {
                        Debug.Log(i);
                        if (other.gameObject.name == buttons[i].name)
                        {
                            Debug.Log("compare sucessful");
                            Debug.Log(i);
                            if (!opened[i])
                            {
                                Debug.Log(buttons[i].name, doors[i]);
                                Rigidbody rb = doors[i].GetComponent<Rigidbody>();
                                if (rb != null) rb.isKinematic = true;
                                {
                                    doors[i].transform.DOMove(doors[i].transform.position + Vector3.right * 3f, 1f);
                                    opened[i] = true;
                                    cutScene(i);
                                }
                            }
                        }
                    }
                }
            }
            Debug.Log("can compare button and phase");
        }

        //dialog
        if (other.gameObject.name == "prisoner1" && GlobalInventoryManagerScript.Instance.phase == 2) //scammer
        {

            Debug.Log("colliding with 1");
            if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {

                Debug.Log("Scene dialog1 supposed to load");
                // scenePreloader.ActivateScene("dialog1");
                SceneManager.LoadScene("dialog1");
            }
        }
        else if (other.gameObject.name == "prisoner2" && GlobalInventoryManagerScript.Instance.phase == 2)
        {
            if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                //scenePreloader.ActivateScene("dialog2");
                SceneManager.LoadScene("dialog2");
            }
        }
        else if (other.gameObject.name == "prisoner3" && GlobalInventoryManagerScript.Instance.phase == 2)
        {
            if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                // scenePreloader.ActivateScene("dialog3");
                SceneManager.LoadScene("dialog3");
            }
        }
        else
        {
            Debug.Log("ghost");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("button"))
        {
            for (int i = 0; i < 3; i++)
            {
                UI[i].gameObject.SetActive(false);
            }
        }
    }

    void cutScene(int num)// scammer
    {
        if (num == 1)
        {
            Debug.Log("cut scene 1");
            // loses
        }
        else if (num == 2)
        {
            Debug.Log("cut scene 2");
        }
        else if (num == 3)
        {
            Debug.Log("cut scene 3");


        }
        else
        {
            Debug.Log("shit");
        }
    }

}  







