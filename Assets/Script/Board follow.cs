using System.Numerics;
using UnityEngine;

public class Boardfollow : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.transform.localScale = new UnityEngine.Vector3(0.49f, 0.49f, 0.49f);
    }

    // Update is called once per frame
    void Update()
    {
        if (safe_show_ui.showing == false){gameObject.transform.position = new UnityEngine.Vector3(player.transform.position.x, -0.057f, player.transform.position.z);
       }
    }
}
