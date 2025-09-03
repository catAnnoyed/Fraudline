using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using TiltFive;
using UnityEngine.SceneManagement;
using UnityEditor.Experimental.GraphView;

public class buttons : MonoBehaviour
{
    public PlayableDirector splash;
    public GameObject button1;
    public GameObject button2;
    public GameObject menu;
    public int choosen;
    private Renderer[] renderers;
    void Start()
    {
        splash.stopped += finishedSplash;
        choosen = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (choosen == 1 && menu.activeSelf)
        {
            renderers = button1.GetComponentsInChildren<Renderer>();
            for (int j = 0; j < renderers.Length; j++)
            {
                Material mat = renderers[j].material;
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", Color.white * 0.1f);
            }

            if (TiltFive.Input.GetStickTilt().y < -0.5 || UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
            {
                choosen = 2;
            }

            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A) || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("police");
            }
        }
        else
        {
            renderers = button1.GetComponentsInChildren<Renderer>();
            for (int k = 0; k < renderers.Length; k++)
            {
                Material mat = renderers[k].material;
                mat.DisableKeyword("_EMISSION");
            }
        }

        if (choosen == 2 && menu.activeSelf)
        {
            renderers = button2.GetComponentsInChildren<Renderer>();
            for (int j = 0; j < renderers.Length; j++)
            {
                Material mat = renderers[j].material;
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", Color.white * 0.1f);
            }
            
             if (TiltFive.Input.GetStickTilt().y > 0.5 || UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
            {
                choosen = 1;
            }

            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A) || UnityEngine.Input.GetKeyDown(KeyCode.E)) {
                // add for option?
            }
        } else
        {
            renderers = button2.GetComponentsInChildren<Renderer>();
            for (int k = 0; k < renderers.Length; k++)
            {
                Material mat = renderers[k].material;
                mat.DisableKeyword("_EMISSION");
            }
        }
    }

    void finishedSplash(PlayableDirector director)
    {
        menu.gameObject.SetActive(true);
    }
}
