using UnityEngine;
using TiltFive;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering.PostProcessing;
using TMPro;

public class dialog2 : MonoBehaviour

{

    public GameObject glassesCamera;
    public int select;
    public Material OriMaterial;
    public Material SelectedMaterial;
    public GameObject[] buttons;
    public GameObject answer;
    public String[] answers;
    private bool held;
    public Vector2 stick;
    public Vector3 location;
    private Vector2 lastStick;
    public bool stickDown;
    public bool stickLeft;
    public bool stickRight;
    public bool stickUp;
    public TextMeshPro answertext;


    void Start()
    {
        select = 1;
        answers = new string[] {
            "Lora",
            "US 7",
            "empty",
            "Different time each day"
        };

        answer.SetActive(false);
        //Debug.Log(glassesCamera);
    }

    void Update()
    {
        // if (glassesCamera == null)
        // {
        //     glassesCamera = GameObject.Find("Left Eye Camera").transform.parent.gameObject;
        // }
        // else
        // {
        //     // //transform.rotation = 
        //     Transform cam = glassesCamera.transform;
        //     transform.LookAt(
        //         transform.position + cam.rotation * Vector3.forward,
        //         cam.rotation * Vector3.up
        //     );
        //     // Vector3 toCamera = glassesCamera.transform.position - transform.position;
        //     // transform.rotation = Quaternion.LookRotation(-Vector3.forward, toCamera);

        // }
        Vector2 stick = TiltFive.Input.GetStickTilt();
        stickRight = stick.x > 0.5f && lastStick.x <= 0.5f;
        stickLeft  = stick.x < -0.5f && lastStick.x >= -0.5f;
        stickUp    = stick.y > 0.5f && lastStick.y <= 0.5f;
        stickDown  = stick.y < -0.5f && lastStick.y >= -0.5f;
        Debug.Log(glassesCamera);
        HandleInput();
        HighlightSelected();
        Debug.Log(stick);
        lastStick = stick;
    }

    // Update is called once per frame
    void HandleInput()
    {
        switch (select)
        {
            case 0:
                if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow) || stickLeft || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A)) select = 1;
                else if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow) || stickDown || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B)) select = 2;
                break;

            case 1:
                if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow) || stickRight || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Y)) select = 0;
                else if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow) || stickDown || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B)) select = 3;
                break;

            case 2:
                if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow) || stickLeft || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A)) select = 3;
                else if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow) || stickUp || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.X)) select = 0;
                break;

            case 3:
                if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow)|| stickRight || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Y)) select = 2;
                else if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow) || stickUp || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.X)) select = 1;
                break;
        }
        
        if ((TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.Space))&& !held)
        {
            Debug.Log("Trigger pressed down!");
            held = true;
        }

        if ((TiltFive.Input.GetTrigger() < 0.5f || UnityEngine.Input.GetKeyUp(KeyCode.Space)) && held)
        {
            if (!answer.activeSelf)
            {
                if (select == 2)
                {
                    SceneManager.LoadScene("police");
                }
                else
                {
                    answer.SetActive(true);
                    answertext.text = answers[select];
                    foreach (GameObject button in buttons)
                        button.SetActive(false);
                }
            }
            else
            {
                answer.SetActive(false);
                foreach (GameObject button in buttons)
                    button.SetActive(true);
            }
            held = false;
        }
    }

    void HighlightSelected()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            var renderer = buttons[i].GetComponent<MeshRenderer>();
            if (i == select)
            {
                renderer.material = SelectedMaterial;
            }
            else
            {
                renderer.material = OriMaterial;
            }
        }
    }
}

