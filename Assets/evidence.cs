using Unity.Mathematics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TiltFive;

[RequireComponent(typeof(LineRenderer))]

public class evidence : MonoBehaviour
{
    public GameObject evidenceobject;
    public GameObject description;
    public GameObject alarm;
    public GameObject keys;
    public GameObject diary;
    public GameObject shoe;
    public GameObject whiteboard;
    public GameObject letter;
    public GameObject USB;
    public GameObject usd;
    public float rayDistance = 50f;
    private LineRenderer line;
    public GameObject target;
    public int choosecounter;
    public bool evidenceselected = false;
    public GameObject[] chosen = new GameObject[3];

    public float yoffset = 1.5f; // Offset to position the description above the item
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        line = GetComponent<LineRenderer>(); // ✅ get the LineRenderer
        description.GetComponent<TextMeshPro>().text = "";
        line.positionCount = 2;
        line.startWidth = 0.02f;
        line.endWidth = 0.02f;
        line.material = new Material(Shader.Find("Sprites/Default"));
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

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("evidence"))
            {
                target = hit.collider.gameObject;
                target.GetComponent<Outline>().enabled = true;
                line.startColor = Color.green;
                line.endColor = Color.green;
                description.transform.position = target.transform.position + new Vector3(0, 0 + yoffset, 0);
                description.GetComponent<TextMeshPro>().text = "press B to choose item as evidence";
            }
            else
            {
                target.GetComponent<Outline>().enabled = false;
                line.startColor = Color.red;
                line.endColor = Color.red;
                description.GetComponent<TextMeshPro>().text = "";
            }
            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B) || UnityEngine.Input.GetKeyDown(KeyCode.B))
            {
                if (hit.collider.gameObject.CompareTag("evidence") && choosecounter < 3)
                {
                    hit.collider.gameObject.tag = "chosen";
                    description.GetComponent<TextMeshPro>().text = "";
                    choosecounter += 1;
                    chosen[choosecounter - 1] = target;
                    target = null;

                }
            }
        }
        else
        {
            target.GetComponent<Outline>().enabled = false;
            line.startColor = Color.red;
            line.endColor = Color.red;
            description.GetComponent<TextMeshPro>().text = "";
        }


        if (choosecounter == 3)
        {
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B) || UnityEngine.Input.GetKeyDown(KeyCode.B))
                {
                    if (hit.collider.gameObject.name == "confirm")
                    {
                        //change scene
                    }
                }
            }
        }
    }
}

