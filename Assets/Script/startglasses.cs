using UnityEngine;
using TiltFive;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;
using UnityEngine.Playables;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine.UI;

public class startglasses : MonoBehaviour
{
    public LineRenderer line;
    public float rayDistance = 5f;
    public GameObject target;
    public GameObject buttoncollider;
    public LayerMask interactLayer;
    public GameObject menu;
    public GameObject option;
    public PlayableDirector splash;

    public UnityEngine.UI.Image StartButton;
    public string hexColor = "#a0a0a0ff";

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2; // start and end point
        line.startWidth = 0.02f;
        line.endWidth = 0.02f;
        line.material = new Material(Shader.Find("Sprites/Default")); // simple visible shader
        line.startColor = Color.red;
        line.endColor = Color.red;
        splash.stopped += finishedSplash;
    }


    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.origin + ray.direction * rayDistance);
        // Create a ray starting from this object's position going forward
        RaycastHit hit;

        // Draw the ray in the Scene view (red line for debugging)
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance, interactLayer))
        {
            target = hit.collider.gameObject;
            if (target.CompareTag("button"))
            {
                line.startColor = Color.green;
                line.endColor = Color.green;
                StartButton.color = Color.gray;
                // if (ColorUtility.TryParseHtmlString(hexColor, out Color newColor)){
                //     StartButton.color = Color.newColor;
                // }


                if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Pressed");
                    if (target.name == buttoncollider.name)
                    {
                        SceneManager.LoadScene("police");
                    }
                    // else if (target.name == buttons[1].name)
                    // {
                    //     changeToOption();
                    // }
                    // else if (target.name == buttons[2].name)
                    // {
                    //     back();
                    // }
                }
            }
        }
        else
        {
            StartButton.color = Color.white;
                

            line.startColor = Color.red;
            line.endColor = Color.red;

        }
    }

    void finishedSplash(PlayableDirector director)
    {
        menu.gameObject.SetActive(true);
    }
    
    
    void changeToOption()
    {
        menu.SetActive(false);
        option.SetActive(true);
    }

    void back()
    {
        menu.SetActive(true);
        option.SetActive(false);
    }
}
