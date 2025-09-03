
using TiltFive;
using UnityEngine;

public class arrow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject door;
    private Vector3 offset = new Vector3(0f,0.3f,-2f);
    private Vector3 rotationOffset = new Vector3(90f,90f,0); 
    private float rotationSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;

        Vector3 direction = door.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation *= Quaternion.Euler(rotationOffset);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        if (GlobalItemComplete.allItemsCollected) {
            gameObject.SetActive(false);
        }
    }
}
