using UnityEngine;
using TiltFive;
using System.Collections;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using TMPro;
using NUnit.Framework.Internal;
using UnityEngine.Playables;


public class cursorHighlight : MonoBehaviour
{
    public GameObject openbook;
    public GameObject usbfolder;
    public GameObject letterpage;
    public static int cursor = 1;
    public GameObject aim;
    public GameObject Gameboard;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public static GameObject platform1Obj;
    public static GameObject platform2Obj;
    public static GameObject platform3Obj;
    public Vector3 platform1ObjOriginalLocation;
    public Vector3 platform2ObjOriginalLocation;
    public Vector3 platform3ObjOriginalLocation;
    private bool IsObj1inspectable = false;
    private bool IsObj2inspectable = false;
    private bool IsObj3inspectable = false;
    public GameObject base1;
    public GameObject base2;
    public GameObject base3;
    private bool joystickCentered = true;
    public static bool isinspceting = false;
    private Vector3 originalGameboardLocation;
    public UnityEngine.Vector2 joystick;
    public Vector3 originalgameboardscale;
    public GameObject location;
    private int cursorTemp;
    public Material materialOri;
    public Material materialSelected;
    public GameObject present;
    public Renderer renderer;
    public TextMeshPro UItext;
    public PlayableDirector win;
    public PlayableDirector lose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        originalGameboardLocation = Gameboard.transform.position;
        originalgameboardscale = Gameboard.transform.localScale;
        StartCoroutine(startdelay());
        renderer = present.GetComponent<Renderer>();
        materialOri = renderer.material;
    }

    IEnumerator startdelay()
    {
        yield return new WaitForSeconds(0.3f);
        foreach (Transform child in platform1.transform)
        {
            if (child.gameObject.activeSelf)
            {
                platform1Obj = child.gameObject;
                platform1ObjOriginalLocation = platform1Obj.transform.position;
            }
        }
        foreach (Transform child in platform2.transform)
        {
            if (child.gameObject.activeSelf)
            {
                platform2Obj = child.gameObject;
                platform2ObjOriginalLocation = platform2Obj.transform.position;
            }
        }
        foreach (Transform child in platform3.transform)
        {
            if (child.gameObject.activeSelf)
            {
                platform3Obj = child.gameObject;
                platform3ObjOriginalLocation = platform3Obj.transform.position;
            }
        }
        if (platform1Obj.name == "Diario" || platform1Obj.name == "whiteboard" || platform1Obj.name == "Letter" || platform1Obj.name == "USB" || platform1Obj.name == "usd")
        {
            IsObj1inspectable = true;
        }
        if (platform2Obj.name == "Diario" || platform2Obj.name == "whiteboard" || platform2Obj.name == "Letter" || platform2Obj.name == "USB" || platform2Obj.name == "usd")
        {
            IsObj2inspectable = true;
        }
        if (platform3Obj.name == "Diario" || platform3Obj.name == "whiteboard" || platform3Obj.name == "Letter" || platform3Obj.name == "USB" || platform3Obj.name == "usd")
        {
            IsObj3inspectable = true;
        } 
    }
    // Update is called once per frame
    void Update()
    {
        joystick = TiltFive.Input.GetStickTilt();
        if (!isinspceting)
        {
            if ((UnityEngine.Input.GetKeyDown(KeyCode.RightArrow) || (joystick.x > 0.5f && joystickCentered)) && cursor !=0)
            {
                if (cursor != 3)
                {
                    cursor += 1;
                    joystickCentered = false;
                }

            }
            else if ((UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow) || (joystick.x < -0.5f && joystickCentered))&& cursor !=0)
            {
                if (cursor != 1)
                {
                    cursor -= 1;
                    joystickCentered = false;
                }
            }
            else if ((UnityEngine.Input.GetKeyDown(KeyCode.DownArrow) || (joystick.x < -0.5f && joystickCentered))&& cursor !=0)
            {
                cursorTemp = cursor;
                cursor = 0;
                renderer.material = materialSelected;
                joystickCentered = false;
                UItext.text = "Press 'B' to confirm";
            }
            else if ((UnityEngine.Input.GetKeyDown(KeyCode.UpArrow) || (joystick.x < -0.5f && joystickCentered)) && cursor == 0)
            {
                renderer.material = materialOri;
                cursor = cursorTemp;
                UItext.text = "Press 'B' to analyse evidence";
            }
        }

        if (cursor == 0)
        {
            Debug.Log("Selecting");
            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B) || UnityEngine.Input.GetKeyDown(KeyCode.F))
            {
                if ((rating.score == 100 && rating2.score == 100) || (rating.score == 100 && rating3.score == 100) || (rating3.score == 100 && rating2.score == 100))
                {
                    win.Play();
                    Debug.Log("Win");
                }
                else
                {
                    lose.Play();
                    Debug.Log("lose");
                }
            }
        }

        if (joystick.x < 0.2f && joystick.x > -0.2f && joystick.y < 0.2f && joystick.y > -0.2f)
        {
            joystickCentered = true;
        }

        if (cursor == 1)
        {
            base1.GetComponent<Outline>().enabled = true;
            base2.GetComponent<Outline>().enabled = false;
            base3.GetComponent<Outline>().enabled = false;
        }
        else if (cursor == 2)
        {
            base2.GetComponent<Outline>().enabled = true;
            base1.GetComponent<Outline>().enabled = false;
            base3.GetComponent<Outline>().enabled = false;
        }
        else if (cursor == 3)
        {
            base3.GetComponent<Outline>().enabled = true;
            base2.GetComponent<Outline>().enabled = false;
            base1.GetComponent<Outline>().enabled = false;
        }
        else
        {
            base3.GetComponent<Outline>().enabled = false;
            base2.GetComponent<Outline>().enabled = false;
            base1.GetComponent<Outline>().enabled = false;
        }

        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B) || UnityEngine.Input.GetKeyDown(KeyCode.F))
        {
            if (IsObj1inspectable)
            {
                if (cursor == 1)
                {
                    if (!isinspceting)
                    {
                        isinspceting = true;
                        platform1Obj.transform.position = location.transform.position;
                        Gameboard.transform.position = platform1Obj.transform.position - new Vector3(0, 1, 0);
                        Gameboard.transform.localScale = originalgameboardscale * 0.5f;
                        //newcode
                        aim.SetActive(true);
                        if (platform1Obj.name == "Diario")
                        {
                            platform1Obj.SetActive(false);
                            openbook.SetActive(true);
                        }
                        if (platform1Obj.name == "USB")
                        {
                            platform1Obj.SetActive(false);
                            usbfolder.SetActive(true);
                        }
                        if (platform1Obj.name == "Letter")
                        {
                            platform1Obj.SetActive(false);
                            letterpage.SetActive(true);
                        }
                        //newcode
                    }
                    else
                    {
                        isinspceting = false;
                        platform1Obj.transform.position = platform1ObjOriginalLocation;
                        Gameboard.transform.position = originalGameboardLocation;
                        Gameboard.transform.localScale = originalgameboardscale;
                        //newcode
                        aim.SetActive(false);
                        if (platform1Obj.name == "Diario")
                        {
                            platform1Obj.SetActive(true);
                            openbook.SetActive(false);
                        }
                        if (platform1Obj.name == "USB")
                        {
                            platform1Obj.SetActive(true);
                            usbfolder.SetActive(false);
                        }
                        if (platform1Obj.name == "Letter")
                        {
                            platform1Obj.SetActive(true);
                            letterpage.SetActive(false);
                        }
                        //newcode
                    }
                }
            }
            if (IsObj2inspectable)
            {
                if (cursor == 2)
                {
                    if (!isinspceting)
                    {
                        isinspceting = true;
                        platform2Obj.transform.position = location.transform.position;
                        Gameboard.transform.position = platform2Obj.transform.position - new Vector3(0, 1, 0);
                        Gameboard.transform.localScale = originalgameboardscale * 0.5f;
                        //newcode
                        aim.SetActive(true);
                        if (platform2Obj.name == "Diario")
                        {
                            platform2Obj.SetActive(false);
                            openbook.SetActive(true);
                        }
                        if (platform2Obj.name == "USB")
                        {
                            platform2Obj.SetActive(false);
                            usbfolder.SetActive(true);
                        }
                        if (platform2Obj.name == "Letter")
                        {
                            platform2Obj.SetActive(false);
                            letterpage.SetActive(true);
                        }
                        //newcode
                    }
                    else
                    {
                        isinspceting = false;
                        platform2Obj.transform.position = platform2ObjOriginalLocation;
                        Gameboard.transform.position = originalGameboardLocation;
                        Gameboard.transform.localScale = originalgameboardscale;
                        //newcode
                        aim.SetActive(false);
                        if (platform2Obj.name == "Diario")
                        {
                            platform2Obj.SetActive(true);
                            openbook.SetActive(false);
                        }
                        if (platform2Obj.name == "USB")
                        {
                            platform2Obj.SetActive(true);
                            usbfolder.SetActive(false);
                        }
                        if (platform2Obj.name == "Letter")
                        {
                            platform2Obj.SetActive(true);
                            letterpage.SetActive(false);
                        }
                        //newcode
                    }
                }
            }
            if (IsObj3inspectable)
            {
                if (cursor == 3)
                {
                    if (!isinspceting)
                    {
                        isinspceting = true;
                        platform3Obj.transform.position = location.transform.position;
                        Gameboard.transform.position = platform3Obj.transform.position - new Vector3(0, 1, 0);
                        Gameboard.transform.localScale = originalgameboardscale * 0.5f;
                        //newcode
                        aim.SetActive(true);
                        if (platform3Obj.name == "Diario")
                        {
                            platform3Obj.SetActive(false);
                            openbook.SetActive(true);
                        }
                        if (platform3Obj.name == "USB")
                        {
                            platform3Obj.SetActive(false);
                            usbfolder.SetActive(true);
                        }
                        if (platform3Obj.name == "Letter")
                        {
                            platform3Obj.SetActive(false);
                            letterpage.SetActive(true);
                        }
                        //newcode
                    }
                    else
                    {
                        isinspceting = false;
                        platform3Obj.transform.position = platform3ObjOriginalLocation;
                        Gameboard.transform.position = originalGameboardLocation;
                        Gameboard.transform.localScale = originalgameboardscale;
                        //newcode
                        aim.SetActive(false);
                        if (platform3Obj.name == "Diario")
                        {
                            platform3Obj.SetActive(true);
                            openbook.SetActive(false);
                        }
                        if (platform3Obj.name == "USB")
                        {
                            platform3Obj.SetActive(true);
                            usbfolder.SetActive(false);
                        }
                        if (platform3Obj.name == "Letter")
                        {
                            platform3Obj.SetActive(true);
                            letterpage.SetActive(false);
                        }
                        //newcode
                    }
                }
            }
        }
          
    }
}
