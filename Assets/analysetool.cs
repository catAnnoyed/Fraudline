using Unity.Mathematics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections;
using TiltFive;
using UnityEditor.ProjectWindowCallback;

[RequireComponent(typeof(LineRenderer))]

public class analysetool : MonoBehaviour
{
    public float rayDistance = 5f;
    private LineRenderer line;
    public GameObject social;
    public GameObject engineering;
    public GameObject invoice;
    public GameObject trojan;
    public GameObject notes;
    public GameObject holidayphoto;
    public GameObject target;
    public GameObject takecontrol;
    public GameObject ransom;
    public GameObject virus;
    public GameObject fakeinvoice;
    public GameObject credentials;
    public bool keypoint1;
    public bool keypoint2;
    public bool keypoint3;
    public bool keypoint4;
    public bool keypoint5;
    public bool keypoint6;
    public bool keypoint7;
    public bool keypoint8;

    void Start()
    {
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
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            target = hit.collider.gameObject;
            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.X) || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                if (hit.collider.gameObject.name == "social")
                {
                    Renderer rend = social.GetComponent<Renderer>();
                    Color col = rend.material.color;   // get the color
                    col.a = 0.5f;                      // change the alpha
                    rend.material.color = col;         // assign it back
                    keypoint1 = true;

                }
                if (hit.collider.gameObject.name == "engineering")
                {
                    Renderer rend = engineering.GetComponent<Renderer>();
                    Color col = rend.material.color;   // get the color
                    col.a = 0.5f;                      // change the alpha
                    rend.material.color = col;         // assign it back
                    keypoint2 = true;
                }
                if (hit.collider.gameObject.name == "invoice")
                {
                    keypoint3 = false;
                    Renderer rend = invoice.GetComponent<Renderer>();
                    Color col = rend.material.color;
                    col.a = 0.5f;
                    rend.material.color = col;

                    Renderer rend2 = trojan.GetComponent<Renderer>();
                    Color col2 = rend2.material.color;
                    col2.a = 0f;
                    rend2.material.color = col2;

                    Renderer rend3 = notes.GetComponent<Renderer>();
                    Color col3 = rend3.material.color;
                    col3.a = 0f;
                    rend3.material.color = col3;

                    Renderer rend4 = holidayphoto.GetComponent<Renderer>();
                    Color col4 = rend4.material.color;
                    col4.a = 0f;
                    rend4.material.color = col4;
                }
                if (hit.collider.gameObject.name == "trojan")
                {
                    keypoint3 = true;

                    // Trojan - make it semi-transparent
                    Renderer rendTrojan = trojan.GetComponent<Renderer>();
                    Color colTrojan = rendTrojan.material.color;
                    colTrojan.a = 0.5f;
                    rendTrojan.material.color = colTrojan;

                    // Invoice - make invisible
                    Renderer rendInvoice = invoice.GetComponent<Renderer>();
                    Color colInvoice = rendInvoice.material.color;
                    colInvoice.a = 0f;
                    rendInvoice.material.color = colInvoice;

                    // Notes - make invisible
                    Renderer rendNotes = notes.GetComponent<Renderer>();
                    Color colNotes = rendNotes.material.color;
                    colNotes.a = 0f;
                    rendNotes.material.color = colNotes;

                    // Holiday photo - make invisible
                    Renderer rendHoliday = holidayphoto.GetComponent<Renderer>();
                    Color colHoliday = rendHoliday.material.color;
                    colHoliday.a = 0f;
                    rendHoliday.material.color = colHoliday;

                }
                if (hit.collider.gameObject.name == "notes")
                {
                    keypoint3 = false;

                    // Notes - semi-transparent
                    Renderer rendNotes = notes.GetComponent<Renderer>();
                    Color colNotes = rendNotes.material.color;
                    colNotes.a = 0.5f;
                    rendNotes.material.color = colNotes;

                    // Invoice - invisible
                    Renderer rendInvoice = invoice.GetComponent<Renderer>();
                    Color colInvoice = rendInvoice.material.color;
                    colInvoice.a = 0f;
                    rendInvoice.material.color = colInvoice;

                    // Trojan - invisible
                    Renderer rendTrojan = trojan.GetComponent<Renderer>();
                    Color colTrojan = rendTrojan.material.color;
                    colTrojan.a = 0f;
                    rendTrojan.material.color = colTrojan;

                    // Holiday photo - invisible
                    Renderer rendHoliday = holidayphoto.GetComponent<Renderer>();
                    Color colHoliday = rendHoliday.material.color;
                    colHoliday.a = 0f;
                    rendHoliday.material.color = colHoliday;

                }
                if (hit.collider.gameObject.name == "holidayphoto")
                {
                    keypoint3 = false;

                    // Holiday photo - semi-transparent
                    Renderer rendHoliday = holidayphoto.GetComponent<Renderer>();
                    Color colHoliday = rendHoliday.material.color;
                    colHoliday.a = 0.5f;
                    rendHoliday.material.color = colHoliday;

                    // Invoice - invisible
                    Renderer rendInvoice = invoice.GetComponent<Renderer>();
                    Color colInvoice = rendInvoice.material.color;
                    colInvoice.a = 0f;
                    rendInvoice.material.color = colInvoice;

                    // Trojan - invisible
                    Renderer rendTrojan = trojan.GetComponent<Renderer>();
                    Color colTrojan = rendTrojan.material.color;
                    colTrojan.a = 0f;
                    rendTrojan.material.color = colTrojan;

                    // Notes - invisible
                    Renderer rendNotes = notes.GetComponent<Renderer>();
                    Color colNotes = rendNotes.material.color;
                    colNotes.a = 0f;
                    rendNotes.material.color = colNotes;

                }
                if (hit.collider.gameObject.name == "takecontrol")
                {
                    Renderer rend = takecontrol.GetComponent<Renderer>();
                    Color col = rend.material.color;   // get the color
                    col.a = 0.5f;                      // change the alpha
                    rend.material.color = col;         // assign it back
                    keypoint4 = true;

                }
                if (hit.collider.gameObject.name == "virus")
                {
                    Renderer rend = virus.GetComponent<Renderer>();
                    Color col = rend.material.color;   // get the color
                    col.a = 0.5f;                      // change the alpha
                    rend.material.color = col;         // assign it back
                    keypoint6 = true;

                }
                if (hit.collider.gameObject.name == "ransom")
                {
                    Renderer rend = ransom.GetComponent<Renderer>();
                    Color col = rend.material.color;   // get the color
                    col.a = 0.5f;                      // change the alpha
                    rend.material.color = col;         // assign it back
                    keypoint5 = true;

                }
                if (hit.collider.gameObject.name == "credentials")
                {
                    Renderer rend = credentials.GetComponent<Renderer>();
                    Color col = rend.material.color;   // get the color
                    col.a = 0.5f;                      // change the alpha
                    rend.material.color = col;         // assign it back
                    keypoint7 = true;

                }
                if (hit.collider.gameObject.name == "fakeinvoice")
                {
                    Renderer rend = fakeinvoice.GetComponent<Renderer>();
                    Color col = rend.material.color;   // get the color
                    col.a = 0.5f;                      // change the alpha
                    rend.material.color = col;         // assign it back
                    keypoint8 = true;

                }
            }

        }



        if (cursorHighlight.cursor == 1)
        {
            if (cursorHighlight.platform1Obj.name == "Diario")
            {
                if (keypoint1 && keypoint2)
                {
                    rating.score = 100; //newcode
                }
            }
            if (cursorHighlight.platform1Obj.name == "USB")
            {
                if (keypoint3)
                {
                    rating.score = 100;//newcode
                }
                else
                {
                    rating.score = 60;
                }
            }
            if (cursorHighlight.platform1Obj.name == "Letter")
            {
                if (keypoint4 && keypoint5 && keypoint6)
                {
                    rating.score = 100; //newcode
                }
            }
            if (cursorHighlight.platform1Obj.name == "whiteboard")
            {
                if (keypoint7 && keypoint8)
                {
                    rating.score = 100; //newcode
                }
            }
        }
        if (cursorHighlight.cursor == 2)
        {
            if (cursorHighlight.platform2Obj.name == "Diario")
            {
                if (keypoint1 && keypoint2)
                {
                    rating2.score = 100; //newcode
                }
            }
            if (cursorHighlight.platform2Obj.name == "USB")
            {
                if (keypoint3)
                {
                    rating2.score = 100;//newcode
                }
                else
                {
                    rating2.score = 60;
                }
            }
            if (cursorHighlight.platform2Obj.name == "Letter")
            {
                if (keypoint4 && keypoint5 && keypoint6)
                {
                    rating2.score = 100; //newcode
                }
            }
            if (cursorHighlight.platform2Obj.name == "whiteboard")
            {
                if (keypoint7 && keypoint8)
                {
                    rating2.score = 100; //newcode
                }
            }
        }
        if (cursorHighlight.cursor == 3)
        {
            if (cursorHighlight.platform3Obj.name == "Diario")
            {
                if (keypoint1 && keypoint2)
                {
                    rating3.score = 100; //newcode
                }
            }
            if (cursorHighlight.platform3Obj.name == "USB")
            {
                if (keypoint3)
                {
                    rating3.score = 100;//newcode
                }
                else
                {
                    rating3.score = 60;
                }
            }
            if (cursorHighlight.platform3Obj.name == "Letter")
            {
                if (keypoint4 && keypoint5 && keypoint6)
                {
                    rating3.score = 100; //newcode
                }
            }
            if (cursorHighlight.platform3Obj.name == "whiteboard")
            {
                if (keypoint7 && keypoint8)
                {
                    rating3.score = 100; //newcode
                }
            }
        }
    }
}