using System.Numerics;
using UnityEngine;

public class Boardfollow : MonoBehaviour
{
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new UnityEngine.Vector3(player.transform.position.x, -0.057f, player.transform.position.z);
        gameObject.transform.localScale = new UnityEngine.Vector3(0.49f, 0.49f, 0.49f);
    }
}
