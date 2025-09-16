using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class cutscenetimeline : MonoBehaviour

{


    public bool cutScenePlaying;
    public GameObject aim;
    public GameObject arrow;
    public MonoBehaviour playerController;
    public PlayableDirector cutScene1;
    public PlayableDirector cutScene2;
    public PlayableDirector cutScene3;
    public PlayableDirector evidence;
    public GameObject prisoner2;
    public GameObject prisoner3;
    void Start()
    {
        if (cutScene2 != null && cutScene2.playableGraph.IsValid())
        {
            cutScene2.playableGraph.GetRootPlayable(0).SetSpeed(0.8f);
        }

        if (GlobalInventoryManagerScript.Instance.opened[1])
        {
            prisoner2.SetActive(false);
        }

        if (GlobalInventoryManagerScript.Instance.opened[2])
        {
            prisoner3.SetActive(false);
        }

        evidence.stopped += EvidenceFinish;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalInventoryManagerScript.Instance.phase == 2 && playerController.enabled)
        {
            arrow.SetActive(true);
        }
    }

    public void doorOpened(int i)
    {
        aim.SetActive(false);
        playerController.enabled = false;
        arrow.SetActive(false);

        if (i == 0)
        {
            // cutScene1.time = 0; // restart
            cutScene1.Play();
            Debug.Log("Timeline started: " + cutScene1.playableAsset.name);
            cutScene1.stopped += OnCutsceneFinished;
        }
        else if (i == 1)
        {
            if (cutScene2 != null)
            {
                // cutScene2.time = 0; // restart
                cutScene2.Play();
                Debug.Log("Timeline started: " + cutScene2.playableAsset.name);
                cutScene2.stopped += OnCutsceneFinished;
            }
            else
            {
                Debug.LogError("Cutscene2 PlayableDirector is not assigned!");
            }
        }
        else if (i == 2)
        {
            cutScene3.Play();
            Debug.Log("Timeline started: " + cutScene3.playableAsset.name);
            cutScene3.stopped += OnCutsceneFinished;
        }
    }

    void OnCutsceneFinished(PlayableDirector director)
    {
        aim.SetActive(true);
        playerController.enabled = true;

        if (GlobalInventoryManagerScript.Instance.opened[1])
        {
            prisoner2.SetActive(false);
        }

        if (GlobalInventoryManagerScript.Instance.opened[2])
        {
            prisoner3.SetActive(false);
        }

        if (GlobalInventoryManagerScript.Instance.opened[0])
        {
            // lose scene
            Debug.Log("lose");
        }
        else if (GlobalInventoryManagerScript.Instance.opened[1] && GlobalInventoryManagerScript.Instance.opened[2])
        {
            evidence.Play();
            aim.SetActive(false);
        }
    }

    void EvidenceFinish(PlayableDirector director)
    {
        //add evidence chosing scene here
        SceneManager.LoadScene("Evidence scene");
        Debug.Log("Evidence choosing scene");
    }

}
