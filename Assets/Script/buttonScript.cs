using DG.Tweening;
using DG.Tweening.Core.Easing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using TiltFive;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class buttonScript : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] doors;
    public bool[] opened;
    public TextMeshPro[] UI;
    public TextMeshPro dialogUI;
    public ScenePreloader scenePreloader;
    public float rayDistance = 5f;
    private LineRenderer line;
    private TrailRenderer trail;
    public LayerMask interactLayer;
    public cutscenetimeline cutscene;
    public highlightPrisoner hightlightPrisoners;
    public TextMeshPro weaponsUI;
    public GameObject glassesThingy;


    void Start()
    {
        
        GetComponent<Renderer>().enabled = false;
        for (int i = 0; i < 3; i++)
        {
            UI[i].gameObject.SetActive(false);
        }
        dialogUI.gameObject.SetActive(false);
        weaponsUI.gameObject.SetActive(false);
        glassesThingy.SetActive(false);


        line = GetComponent<LineRenderer>();
        line.positionCount = 2; // start and end point
        line.startWidth = 0.02f;
        line.endWidth = 0.02f;
        line.material = new Material(Shader.Find("Sprites/Default")); // simple visible shader
        line.startColor = Color.red;
        line.endColor = Color.red;
        trail = GetComponent<TrailRenderer>();
        line.enabled = false;
        trail.enabled = false;
    }

    void Update()
    {

        if (GlobalInventoryManagerScript.Instance.phase == 2)
        {
            //GetComponent<Renderer>().enabled = true;
            line.enabled = true;
            trail.enabled = true;
            glassesThingy.SetActive(true);
        }    
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.origin + ray.direction * rayDistance);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);


        if (Physics.Raycast(ray, out hit, rayDistance, interactLayer) && GlobalInventoryManagerScript.Instance.phase == 2)
        {
            GameObject other = hit.collider.gameObject;
            if (other.gameObject.CompareTag("button") && GlobalInventoryManagerScript.Instance.phase == 2)
            {
                for (int i = 0; i < 3; i++)
                {

                    if (!GlobalItemComplete.allItemsCollected)
                    {
                        UI[i].text = "Collect all evidence first";

                    }
                    else
                    {
                        UI[i].text = "Press trigger to release suspect";
                    }

                    if (other.gameObject.name == buttons[i].name && !GlobalInventoryManagerScript.Instance.opened[i])
                    {
                        UI[i].gameObject.SetActive(true);
                        if (GlobalItemComplete.allItemsCollected)
                        {
                            line.startColor = Color.green;
                            line.endColor = Color.green;
                            line.material.color = Color.green;
                        }
                    }

                    if ((TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E)) && GlobalItemComplete.allItemsCollected)
                    {
                        Debug.Log("key pressed");
                        Debug.Log(other.gameObject);

                        {
                            Debug.Log(i);
                            if (other.gameObject.name == buttons[i].name)
                            {
                                Debug.Log("compare sucessful");
                                Debug.Log(i);
                                if (!GlobalInventoryManagerScript.Instance.opened[i])
                                {
                                    Debug.Log(buttons[i].name, doors[i]);
                                    Rigidbody rb = doors[i].GetComponent<Rigidbody>();
                                    if (rb != null) rb.isKinematic = true;
                                    {
                                        doors[i].transform.DOMove(doors[i].transform.position + Vector3.right * 3f, 1f);
                                        cutscene.doorOpened(i);
                                        UI[i].gameObject.SetActive(false);
                                        GlobalInventoryManagerScript.Instance.opened[i] = true;
                                    }
                                }
                            }
                        }
                    }
                }
                Debug.Log("can compare button and phase");
            }



            Debug.Log(other.gameObject.name);
            //dialog
            if (other.gameObject.name == "prisoner1" && GlobalInventoryManagerScript.Instance.phase == 2) //scammer
            {

                line.startColor = Color.green;
                line.endColor = Color.green;
                line.material.color = Color.green;
                hightlightPrisoners.highlight(0);
                dialogUI.gameObject.SetActive(true);
                Debug.Log("colliding with 1");
                if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
                {

                    Debug.Log("Scene dialog1 supposed to load");
                    SceneManager.LoadScene("dialog1");
                }
            }
            else if (other.gameObject.name == "prisoner2" && GlobalInventoryManagerScript.Instance.phase == 2)
            {
                line.startColor = Color.green;
                line.endColor = Color.green;
                line.material.color = Color.green;
                hightlightPrisoners.highlight(1);
                dialogUI.gameObject.SetActive(true);
                Debug.Log("colliding with 2");
                if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("pressed");
                    SceneManager.LoadScene("dialog2");
                }
            }
            else if (other.gameObject.name == "prisoner3" && GlobalInventoryManagerScript.Instance.phase == 2)
            {
                line.startColor = Color.green;
                line.endColor = Color.green;
                line.material.color = Color.green;
                hightlightPrisoners.highlight(2);
                dialogUI.gameObject.SetActive(true);
                Debug.Log("colliding with 3");
                if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("dialog3");
                }
            }
            else
            {
                hightlightPrisoners.dontHighlight();
                dialogUI.gameObject.SetActive(false);
                //Debug.Log("ghost");
            }


            if (other.gameObject.CompareTag("weapons") && GlobalInventoryManagerScript.Instance.phase == 2)
            {
                weaponsUI.gameObject.SetActive(true);
            }
            else
            {
                weaponsUI.gameObject.SetActive(false);
            }

        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                UI[i].gameObject.SetActive(false);
            }
            hightlightPrisoners.dontHighlight();
            dialogUI.gameObject.SetActive(false);
            weaponsUI.gameObject.SetActive(false);
            line.startColor = Color.red;
            line.endColor = Color.red;
        }
    }

    // void OnTriggerStay(Collider other)
    // {
    //     Debug.Log("collide");
    //     if (other.gameObject.CompareTag("button") && GlobalInventoryManagerScript.Instance.phase == 2)
    //     {
    //         for (int i = 0; i < 3; i++)
    //         {
    //             if (other.gameObject.name == buttons[i].name && !opened[i])
    //             {
    //                 UI[i].gameObject.SetActive(true);
    //             }
    //             if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
    //             {
    //                 Debug.Log("key pressed");
    //                 Debug.Log(other.gameObject);

    //                 {
    //                     Debug.Log(i);
    //                     if (other.gameObject.name == buttons[i].name)
    //                     {
    //                         Debug.Log("compare sucessful");
    //                         Debug.Log(i);
    //                         if (!opened[i])
    //                         {
    //                             Debug.Log(buttons[i].name, doors[i]);
    //                             Rigidbody rb = doors[i].GetComponent<Rigidbody>();
    //                             if (rb != null) rb.isKinematic = true;
    //                             {
    //                                 doors[i].transform.DOMove(doors[i].transform.position + Vector3.right * 3f, 1f);
    //                                 opened[i] = true;
    //                                 cutScene(i);
    //                             }
    //                         }
    //                     }
    //                 }
    //             }
    //         }
    //         Debug.Log("can compare button and phase");
    //     }

    //     //dialog
    //     if (other.gameObject.name == "prisoner1" && GlobalInventoryManagerScript.Instance.phase == 2) //scammer
    //     {

    //         Debug.Log("colliding with 1");
    //         if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
    //         {

    //             Debug.Log("Scene dialog1 supposed to load");
    //             // scenePreloader.ActivateScene("dialog1");
    //             SceneManager.LoadScene("dialog1");
    //         }
    //     }
    //     else if (other.gameObject.name == "prisoner2" && GlobalInventoryManagerScript.Instance.phase == 2)
    //     {
    //         if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
    //         {
    //             //scenePreloader.ActivateScene("dialog2");
    //             SceneManager.LoadScene("dialog2");
    //         }
    //     }
    //     else if (other.gameObject.name == "prisoner3" && GlobalInventoryManagerScript.Instance.phase == 2)
    //     {
    //         if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
    //         {
    //             // scenePreloader.ActivateScene("dialog3");
    //             SceneManager.LoadScene("dialog3");
    //         }
    //     }
    //     else
    //     {
    //         Debug.Log("ghost");
    //     }
    // }

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.CompareTag("button"))
    //     {
    //         for (int i = 0; i < 3; i++)
    //         {
    //             UI[i].gameObject.SetActive(false);
    //         }
    //     }
    // }

    // void cutScene(int num)// scammer
    // {
    //     if (num == 1)
    //     {
    //         Debug.Log("cut scene 1");
    //         // loses
    //     }
    //     else if (num == 2)
    //     {
    //         Debug.Log("cut scene 2");
    //     }
    //     else if (num == 3)
    //     {
    //         Debug.Log("cut scene 3");


    //     }
    //     else
    //     {
    //         Debug.Log("shit");
    //     }
    // }

}  







