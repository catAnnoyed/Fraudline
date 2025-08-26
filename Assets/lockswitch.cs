using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using TiltFive;
using System.Numerics;
using UnityEngine.InputSystem;
using System.Security.Cryptography.X509Certificates;
using DG.Tweening;

public class lockswitch : MonoBehaviour
{
    public GameObject safe;
    public int cursor = 1;
    private bool joystickCentered = true;
    public int lock1cursor = 0;
    public int lock2cursor = 0;
    public int lock3cursor = 0;
    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject num1;
    public GameObject num2;
    public GameObject num3;
    public string password;

    public UnityEngine.Vector2 joystick;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        cursor = 1;
        lock1 = GameObject.Find("lock 1");
        lock2 = GameObject.Find("lock 2");
        lock3 = GameObject.Find("lock 3");
        num1 = GameObject.Find("num 1");
        num2 = GameObject.Find("num 2");
        num3 = GameObject.Find("num 3");
        


    }

    // Update is called once per frame
    void Update()
    {
        password = num1.GetComponent<TextMeshPro>().text + num2.GetComponent<TextMeshPro>().text + num3.GetComponent<TextMeshPro>().text;

        joystick = TiltFive.Input.GetStickTilt();
        if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow) || (joystick.x > 0.5f && joystickCentered))
        {
            if (cursor != 3)
            {
                cursor += 1;
                joystickCentered = false;
            }

        }
        else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow) || (joystick.x < -0.5f && joystickCentered))
        {
            if (cursor != 1)
            {
                cursor -= 1;
                joystickCentered = false;
            }
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow) || joystick.y > 0.5f && joystickCentered)
        {
            if (cursor == 1)
            {
                lock1cursor += 1;
            }
            else if (cursor == 2)
            {
                lock2cursor += 1;
            }
            else if (cursor == 3)
            {
                lock3cursor += 1;
            }
            if (lock1cursor == 10)
            {
                lock1cursor = 0;
            }
            if (lock2cursor == 10)
            {
                lock2cursor = 0;
            }
            if (lock3cursor == 10)
            {
                lock3cursor = 0;
            }
            joystickCentered = false;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow) || joystick.y < -0.5f && joystickCentered)
        {
            if (cursor == 1)
            {
                lock1cursor -= 1;
            }
            else if (cursor == 2)
            {
                lock2cursor -= 1;
            }
            else if (cursor == 3)
            {
                lock3cursor -= 1;
            }
            if (lock1cursor == -1)
            {
                lock1cursor = 9;
            }
            if (lock2cursor == -1)
            {
                lock2cursor = 9;
            }
            if (lock3cursor == -1)
            {
                lock3cursor = 9;
            }
            joystickCentered = false;
        }
        if (cursor == 1)
        {
            lock1.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1.1f);
            lock2.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1f);
            lock3.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1f);
        }
        else if (cursor == 2)
        {
            lock2.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1.1f);
            lock1.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1f);
            lock3.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1f);
        }
        else if (cursor == 3)
        {
            lock3.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1.1f);
            lock2.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1f);
            lock1.GetComponent<Renderer>().materials[1].SetFloat("_scale", 1f);
        }
        num1.GetComponent<TextMeshPro>().text = lock1cursor.ToString();
        num2.GetComponent<TextMeshPro>().text = lock2cursor.ToString();
        num3.GetComponent<TextMeshPro>().text = lock3cursor.ToString();
        if (joystick.x < 0.2f && joystick.x > -0.2f && joystick.y < 0.2f && joystick.y > -0.2f)
        {
            joystickCentered = true;
        }
    }

}