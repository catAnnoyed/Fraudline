using TMPro;
using UnityEngine;
using TiltFive;
using StarterAssets;
using DG.Tweening;


public class safe_show_ui : MonoBehaviour
{
    public GameObject player;
    public GameObject safelockprefab;
    public GameObject safelock;
    public GameObject ui;
    public GameObject TFmanager;
    public GameObject TFgameboard;
    public GameObject safedoor;
    public lockswitch lockscript;
    public GameObject USB;
    public AudioSource audiosource;
    public static bool opened = false; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        safedoor = GameObject.Find("Small Safe Door");
        ui = GameObject.Find("safe_Ui");
        TFmanager = GameObject.Find("Tilt Five Manager");
        USB = GameObject.Find("USB");
        USB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("safeLock(Clone)") != null)
        {
            lockscript = GameObject.Find("safeLock(Clone)").GetComponent<lockswitch>();
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.One) || UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                if (safelock == null)
                {
                    if (!opened)
                    {
                        safelock = Instantiate(safelockprefab, new Vector3(TFgameboard.transform.position.x, 3f, TFgameboard.transform.position.y), Quaternion.identity);
                        player.GetComponent<ThirdPersonController>().enabled = false;
                    }
                }
                else if (lockscript.password == "319")
                {
                    if (!opened)
                    {
                        opened = true;
                        safedoor.transform.DORotate(new UnityEngine.Vector3(0, 90, 0), 1f, RotateMode.WorldAxisAdd);
                        Destroy(safelock);
                        player.GetComponent<ThirdPersonController>().enabled = true;
                        USB.SetActive(true);
                        audiosource.Play();
                    }
                }
                else
                {
                    Destroy(safelock);
                    player.GetComponent<ThirdPersonController>().enabled = true;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        ui.GetComponent<TextMeshPro>().text = "Press '1' to interact";
    }
    void OnTriggerExit(Collider other)
    {
        ui.GetComponent<TextMeshPro>().text = "";
    }

}


