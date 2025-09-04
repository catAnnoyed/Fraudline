using UnityEngine;
using TiltFive;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;
using UnityEngine.Playables;

public class startglasses : MonoBehaviour
{
    public LineRenderer line;
    public float rayDistance = 5f;
    public GameObject target;
    public Renderer[] renderers;
    public GameObject[] buttons;
    public LayerMask interactLayer;
    public GameObject menu;
    public GameObject option;
    public PlayableDirector splash;

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
                renderers = target.GetComponentsInChildren<Renderer>();
                for (int j = 0; j < renderers.Length; j++)
                {
                    Material mat = renderers[j].material;
                    mat.EnableKeyword("_EMISSION");
                    mat.SetColor("_EmissionColor", Color.white * 0.1f);
                }

                if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.E))
                {
                    if (target.name == buttons[0].name)
                    {
                        SceneManager.LoadScene("police");
                    }
                    else if (target.name == buttons[1].name)
                    {
                        changeToOption();
                    }
                    else if (target.name == buttons[2].name)
                    {
                        back();
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                renderers = buttons[i].GetComponentsInChildren<Renderer>();
                for (int k = 0; k < renderers.Length; k++)
                {
                    Material mat = renderers[k].material;
                    mat.DisableKeyword("_EMISSION");
                }
            }

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
