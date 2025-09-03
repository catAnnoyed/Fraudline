using UnityEngine;
using TiltFive;
public class Zoom : MonoBehaviour
{
    public GameObject board;
    public bool zoomedin = false;
    public bool zoomeout = true;
    public int bclicked = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.B))
        {
            if (bclicked <= 2)
            {
                bclicked++;
            } 
        }
        if (TiltFive.Input.GetButton(TiltFive.Input.WandButton.B) && bclicked == 2)
        {
            board.GetComponent<Boardfollow>().enabled = true;
            bclicked = 0;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if ((TiltFive.Input.GetButton(TiltFive.Input.WandButton.B) && bclicked == 1) || UnityEngine.Input.GetKey(KeyCode.Q))
        {
            board.GetComponent<Boardfollow>().enabled = false;
            board.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            board.transform.position = new Vector3(other.transform.position.x, -0.057f, other.transform.position.z);

        }
    }


}
