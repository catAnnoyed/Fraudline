using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class inspect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 originalposition;
    public Vector3 originalboardrotation;
    public Quaternion originalrotation;
    public GameObject ObjectToInspect;
    public GameObject board;
    public bool inspectormode = false;

    void Start()
    {
        board = GameObject.Find("Tilt Five Game Board");
        originalboardrotation = board.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (inspectormode)
        {
            if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Y))
            {
                inspectormode = false;
                ObjectToInspect.transform.position = originalposition;
                ObjectToInspect.transform.rotation = originalrotation;
                ObjectToInspect.GetComponent<Rigidbody>().isKinematic = false;
                board.transform.position = originalboardrotation;
                board.transform.localScale = new Vector3(1.39f, 1.39f, 1.39f);
            }
            if (TiltFive.Input.GetStickTilt().x > 0.5)
            {
                ObjectToInspect.transform.rotation *= quaternion.Euler(1.2f * Time.deltaTime, 0, 0);
            }
            if (TiltFive.Input.GetStickTilt().x < -0.5)
            {
                ObjectToInspect.transform.rotation *= quaternion.Euler(0, -1.2f * Time.deltaTime, 0);
            }
            if (TiltFive.Input.GetStickTilt().y > 0.5)
            {
                ObjectToInspect.transform.rotation *= quaternion.Euler(1.2f * Time.deltaTime, 0, 0);
            }
            if (TiltFive.Input.GetStickTilt().y < -0.5)
            {
                ObjectToInspect.transform.rotation *= quaternion.Euler(-1.2f * Time.deltaTime, 0, 0);
            }
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Y) && inspectormode == false)
        {
            inspectormode = true;
            originalposition = collision.transform.position;
            originalrotation = collision.transform.rotation;
            ObjectToInspect = collision.gameObject;
            ObjectToInspect.transform.position = originalposition + new Vector3(0, 3f, 0);
            ObjectToInspect.GetComponent<Rigidbody>().isKinematic = true;
            board.transform.position = ObjectToInspect.transform.position + new Vector3(0, -0.3f, 0);
            board.transform.localScale = new Vector3(0.42f, 0.42f, 0.42f);
        }

    }
}