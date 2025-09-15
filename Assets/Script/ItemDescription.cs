using Unity.Mathematics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections;
using TiltFive;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LineRenderer))]

public class ItemDescription : MonoBehaviour
{
    public Vector3 originalposition;
    public GameObject backbutton;
    public Vector3 originalboardposition;
    public Quaternion originalrotation;
    public GameObject ObjectToInspect;
    public GameObject board;
    public bool inspectormode = false;
    public GameObject description;
    public GameObject alarm;
    public GameObject keys;
    public GameObject diary;
    public GameObject shoe;
    public GameObject whiteboard;
    public GameObject letter;
    public GameObject USB;
    public GameObject usd;
    public float rayDistance = 5f;
    private LineRenderer line;
    public GameObject target;
    public float yoffset = 1.5f; // Offset to position the description above the item
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        board = GameObject.Find("Tilt Five Game Board");
        originalboardposition = board.transform.position;
        line = GetComponent<LineRenderer>();
        line.positionCount = 2; // start and end point
        line.startWidth = 0.02f;
        line.endWidth = 0.02f;
        line.material = new Material(Shader.Find("Sprites/Default")); // simple visible shader
        line.startColor = Color.red;
        line.endColor = Color.red;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.origin + ray.direction * rayDistance);
        // Create a ray starting from this object's position going forward
        UnityEngine.RaycastHit hit;

        // Draw the ray in the Scene view (red line for debugging)
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        if (inspectormode)
        {
            if (TiltFive.Input.GetStickTilt().x > 0.5 || UnityEngine.Input.GetKey(KeyCode.RightArrow))
            {
                ObjectToInspect.transform.rotation *= quaternion.Euler(0, 1.2f * Time.deltaTime, 0);
            }
            if (TiltFive.Input.GetStickTilt().x < -0.5 || UnityEngine.Input.GetKey(KeyCode.LeftArrow))
            {
                ObjectToInspect.transform.rotation *= quaternion.Euler(0, -1.2f * Time.deltaTime, 0);
            }
            if (TiltFive.Input.GetStickTilt().y > 0.5 || UnityEngine.Input.GetKey(KeyCode.UpArrow))
            {
                ObjectToInspect.transform.rotation *= quaternion.Euler(1.2f * Time.deltaTime, 0, 0);
            }
            if (TiltFive.Input.GetStickTilt().y < -0.5 || UnityEngine.Input.GetKey(KeyCode.DownArrow))
            {
                ObjectToInspect.transform.rotation *= quaternion.Euler(-1.2f * Time.deltaTime, 0, 0);
            }
        }
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Y) || UnityEngine.Input.GetKeyDown(KeyCode.E))
        {
            if (inspectormode)
            {
                inspectormode = false;
                Debug.Log("inspector off");
                ObjectToInspect.transform.position = originalposition;
                ObjectToInspect.transform.rotation = originalrotation;
                ObjectToInspect.GetComponent<Rigidbody>().isKinematic = false;
                board.transform.position = originalboardposition;
                board.transform.localScale = new Vector3(1.39f, 1.39f, 1.39f);
                
            }
            else
            {
                if (Physics.Raycast(ray, out hit, rayDistance))
                {
                    inspectormode = true;
                    target = hit.collider.gameObject;
                    Debug.Log("inspector on");
                    originalposition = target.transform.position;
                    originalrotation = target.transform.rotation;
                    ObjectToInspect = target;
                    ObjectToInspect.transform.position = originalposition + new Vector3(0, 3f, 0);
                    ObjectToInspect.GetComponent<Rigidbody>().isKinematic = true;
                    board.transform.position = ObjectToInspect.transform.position + new Vector3(0, -0.3f, 0);
                    board.transform.localScale = new Vector3(0.42f, 0.42f, 0.42f);
                    
                }
            }
        }
        if (Physics.Raycast(ray, out hit, rayDistance))
        {


            target = hit.collider.gameObject;
            if ((target.CompareTag("pickable") || target.CompareTag("evidence"))&& inspectormode == false)
            {
                description.transform.position = target.transform.position + new Vector3(0, 0 + yoffset, 0);
                if (target == alarm)
                {
                    description.GetComponent<TextMeshPro>().text = "Wake Up Alarm";
                }
                else if (target == keys)
                {
                    description.GetComponent<TextMeshPro>().text = "Secret Room Keys";
                }
                else if (target == diary)
                {
                    description.GetComponent<TextMeshPro>().text = "James's social engineering book";
                }
                else if (target == shoe)
                {
                    description.GetComponent<TextMeshPro>().text = "Small Shoe";
                }
                else if (target == whiteboard)
                {
                    description.GetComponent<TextMeshPro>().text = "Scammer's Whiteboard";
                }
                else if (target == letter)
                {
                    description.GetComponent<TextMeshPro>().text = "Suspicious Letter";
                }
                else if (target == USB)
                {
                    description.GetComponent<TextMeshPro>().text = "Malware USB";
                }
                else if (target == usd)
                {
                    description.GetComponent<TextMeshPro>().text = "Counterfeit USD";
                }
            }
        }

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.gameObject == backbutton)
            {
                if (!inspectormode)
                {
                    if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.One))
                    {
                        Debug.Log("hi");
                        SceneManager.LoadScene(toInventory.currentscene);
                    }
                }
            }
        }
    
        if (target == null)
            {
                description.GetComponent<TextMeshPro>().text = "";
            }
            else if (!hit.collider.gameObject.CompareTag("pickable") && !hit.collider.gameObject.CompareTag("evidence"))
            {
                description.GetComponent<TextMeshPro>().text = "";
            }

        

    }
}
