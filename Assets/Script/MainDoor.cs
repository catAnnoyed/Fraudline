using UnityEngine;
using TiltFive;
using UnityEngine.SceneManagement;

public class MainDoor : MonoBehaviour
{
    public ScenePreloader scenePreloader;
    public GameObject UI;
    void Start()
    {
        scenePreloader.PreloadScene("house");
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            UI.SetActive(true);
            Debug.Log("is player");

            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A) || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                // animation?
                Debug.Log("Should be changing scene");
                SceneManager.LoadScene("house");
                //scenePreloader.ActivateScene("house");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        UI.SetActive(false);
    }
}
