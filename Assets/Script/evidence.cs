using Unity.Mathematics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using JetBrains.Annotations;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TiltFive;
using UnityEditor.Experimental.GraphView;

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
    public static string[] chosen = new string[3];
    public GameObject laseron;
    public GameObject confirmUI;
    public Renderer confrimRenderer;
    public GameObject Confirm;
    public Renderer [] renderers;
    public Renderer renderer;

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
        choosecounter = 0;
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
        //if (choosecounter != 3)
        //{
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.gameObject.CompareTag("evidence"))
            {
                target = hit.collider.gameObject;
                //target.GetComponent<Outline>().enabled = true;
                highlight(target);
                line.startColor = Color.green;
                line.endColor = Color.green;
                description.transform.position = target.transform.position + new Vector3(0, 0 + yoffset, 0);
                description.GetComponent<TextMeshPro>().text = "press '2' to choose item as evidence";
            }
            else
            {
                //target.GetComponent<Outline>().enabled = false;
                dontHighlight(target);
                line.startColor = Color.red;
                line.endColor = Color.red;
                description.GetComponent<TextMeshPro>().text = "";
            }

            if (TiltFive.Input.GetButtonUp(TiltFive.Input.WandButton.Two) || UnityEngine.Input.GetKeyDown(KeyCode.B))
            {
                if (hit.collider.gameObject.CompareTag("evidence") && choosecounter < 3)
                {
                    hit.collider.gameObject.tag = "chosen";
                    description.GetComponent<TextMeshPro>().text = "";
                    choosecounter += 1;
                    chosen[choosecounter - 1] = target.name;
                    target = null;

                }
                else if (hit.collider.gameObject.CompareTag("evidence") && choosecounter >= 3)
                {
                    hit.collider.gameObject.tag = "chosen";
                    description.GetComponent<TextMeshPro>().text = "";
                    GameObject temp = GameObject.Find(chosen[0]);
                    temp.tag = "evidence";
                    //temp.GetComponent<Outline>().enabled = false;
                    dontHighlight(temp);
                    chosen[0] = chosen[1];
                    chosen[1] = chosen[2];
                    chosen[2] = target.name;
                    target = null;
                }
            }
        }
        else
        {
            //target.GetComponent<Outline>().enabled = false;
            dontHighlight(target);
            line.startColor = Color.red;
            line.endColor = Color.red;
            description.GetComponent<TextMeshPro>().text = "";
        }

        //)
        if (choosecounter == 3)
        {
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                laseron = hit.collider.gameObject;
                if (hit.collider.gameObject.name == "confirm")
                {
                    confirmUI.SetActive(true);
                    confrimRenderer = Confirm.GetComponent<Renderer>();
                    Material mat = confrimRenderer.material;
                    mat.EnableKeyword("_EMISSION");
                    mat.SetColor("_EmissionColor", Color.black * 0.055f);
                }
                else
                {
                    confirmUI.SetActive(false);
                    confrimRenderer = Confirm.GetComponent<Renderer>();
                    Material mat = confrimRenderer.material;
                    mat.DisableKeyword("_EMISSION");
                }
                if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Two) || UnityEngine.Input.GetKeyDown(KeyCode.B))
                {
                    if (hit.collider.gameObject.name == "confirm")
                    {
                        Debug.Log("bbb");
                        global.eviarray = chosen;
                        SceneManager.LoadScene("EviStrengthen");
                    }
                }
            }
            else
            {
                confirmUI.SetActive(false);
                confrimRenderer = Confirm.GetComponent<Renderer>();
                Material mat = confrimRenderer.material;
                mat.DisableKeyword("_EMISSION");
            }
        }
    }

    public void highlight(GameObject evi)
    {
        GameObject child = evi.transform.Find("shade").gameObject;
        if (child == null)
        {
            Debug.Log("cannot find");
        }
        child.SetActive(true);

    }

    public void dontHighlight(GameObject evi)
    {
        GameObject child = evi.transform.Find("shade").gameObject;
        if (child != null)
        {
            child.SetActive(false);
        }
    }
}

