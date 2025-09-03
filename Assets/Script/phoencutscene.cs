using System;
using UnityEditor.ProjectWindowCallback;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Video;

public class phoencutscene : MonoBehaviour
{
    public PlayableDirector bfr;
    public PlayableDirector after;
    public int num;
    public GameObject Ui;
    void Start()
    {
        if (GlobalInventoryManagerScript.Instance.phase == 0)
        {
        bfr.Play();
        num = 0;
        Ui.SetActive(false);
        bfr.stopped += OnCutsceneFinished1;
        after.stopped += OnCutsceneFinished2;
        }
    }

    // Update is called once per frame
    void Update()
    {

   

    }


    public void End()
    {
        after.Play();
        Ui.SetActive(false);
    }

    void OnCutsceneFinished1(PlayableDirector director)
    {
        num = 1;
        Ui.SetActive(true);
        Debug.Log("shld activate ui");

    }

    void OnCutsceneFinished2(PlayableDirector director) {
        if (num == 2)
        {

            GlobalInventoryManagerScript.Instance.phase = 1;
        }

    }
}
