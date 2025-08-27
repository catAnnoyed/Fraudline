using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using System.Numerics;
using Unity.VisualScripting;
using TiltFive;
using UnityEditor.Animations;

public class boardScript : MonoBehaviour
{
    private UnityEngine.Vector3 Scale = new UnityEngine.Vector3(0.8f, 0.8f, 0.8f);
    private UnityEngine.Vector3 Position = new UnityEngine.Vector3(0, 0, 0);
    public GameObject phone;
    public GameObject[] jails;
    [SerializeField] private int i = 0;
    private bool isMoving = false;
    public GameObject player;
    public GameObject callUI;
    public GameObject doorUI;
    public GameObject arrow;

    void Start()
    {
        transform.position = phone.transform.position;
        transform.localScale = Scale;
        player.SetActive(false);
        arrow.SetActive(false);
    }

    void Update()
    {
        if (GlobalInventoryManagerScript.Instance.phase == 1)
        {
            if (i < 3)
            {
                if ((UnityEngine.Input.GetKeyDown(KeyCode.Space) || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A)) && !isMoving)
                {
                    callUI.SetActive(false);
                    MoveJail();
                }
            }
            else
            {
                if (UnityEngine.Input.GetKeyDown(KeyCode.Space) || TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.A))
                {
                    GlobalInventoryManagerScript.Instance.phase = 2;
                    doorUI.SetActive(false);
                    
                }
            }
            
        }

        if (GlobalInventoryManagerScript.Instance.phase == 2)
        {
            player.SetActive(true);
            arrow.SetActive(true);
            callUI.SetActive(false);
            Scale = new UnityEngine.Vector3(0.8f, 0.8f, 0.8f);
            transform.DOScale(Scale, 0.8f);
            gameObject.transform.position = new UnityEngine.Vector3(player.transform.position.x,-0.01f, player.transform.position.z);


        }
    }

    void MoveJail()
    {
        isMoving = true;
        Scale = new UnityEngine.Vector3(0.3f, 0.3f, 0.3f);
        transform.DOScale(Scale, 0.5f);
        transform.DOMove(jails[i].transform.position, 0.8f)
            .OnComplete(() => {
                isMoving = false;
                i++;
            });
    }
}
