using UnityEngine;
using TiltFive;
using UnityEngine.SceneManagement;

public class MainDoor : MonoBehaviour
{
    public ScenePreloader scenePreloader;
    public GameObject UI;
    public AudioSource soundEffect;
    void Start()
    {
        //cenePreloader.PreloadScene("house");
        if (GlobalInventoryManagerScript.Instance.phase == 2)
        {
            soundEffect.Play();
        }
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
                soundEffect.Play();
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
