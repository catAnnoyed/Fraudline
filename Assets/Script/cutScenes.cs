using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class cutScenes : MonoBehaviour
{

    public GameObject player;
    public GameObject scammer;
    public GameObject board;
    public GameObject aim;
    public PlayerInput playerInput;
    public GameObject door;
    private Vector3 Scale;
    private bool follow;

    void Start()
    {
        follow = false;
    }

    void Update()
    {
        if (follow == true)
        {
            board.transform.position = new UnityEngine.Vector3(scammer.transform.position.x, -0.01f, scammer.transform.position.z);
        }
    }


    void generalShit()
    {
        //aim.SetActive(false);
        playerInput.actions.Disable();  
    }

    public void cutScene3()
    {
        follow = true;
        generalShit();
        Scale = new UnityEngine.Vector3(0.8f, 0.8f, 0.8f);
        transform.DOScale(Scale, 0.3f);
        door.SetActive(false);
        scammer.transform.DOMove(door.transform.position, 0.07f);
            // .OnComplete(() => {
            //     aim.SetActive(true);
            // });
    }
}
