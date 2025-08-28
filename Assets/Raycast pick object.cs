using UnityEngine;
using TiltFive;
using UnityEngine.InputSystem.Interactions;
using JetBrains.Annotations;
using Unity.VisualScripting;
[RequireComponent(typeof(LineRenderer))]
public class RaycastpickItem : MonoBehaviour
{
    public GameObject pickedItem;
    public AudioSource audiosource;
    public inventoryHouseIM inventorylist;

    // Maximum ray distance
    public float rayDistance = 5f;
    private LineRenderer line;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2; // start and end point
        line.startWidth = 0.02f;
        line.endWidth = 0.02f;
        line.material = new Material(Shader.Find("Sprites/Default")); // simple visible shader
        line.startColor = Color.red;
        line.endColor = Color.red;

    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.origin + ray.direction * rayDistance);
        // Create a ray starting from this object's position going forward
        RaycastHit hit;

        // Draw the ray in the Scene view (red line for debugging)
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            GameObject target = hit.collider.gameObject;

            // If the ray hits a pickable item
            if (pickedItem == null)
            {

                if (target.CompareTag("pickable"))
                {
                    if (TiltFive.Input.GetTrigger() > 0.5f || UnityEngine.Input.GetKeyDown(KeyCode.F))
                    {

                        // Parent the object to the wand
                        pickedItem = target;
                        pickedItem.transform.SetParent(transform);
                        pickedItem.transform.localPosition = Vector3.forward * rayDistance;
                        pickedItem.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }
            }

            // If holding something, check for release
            if (pickedItem != null && pickedItem.CompareTag("pickable"))
            {
                if (TiltFive.Input.GetTrigger() <= 0.5f && !UnityEngine.Input.GetKey(KeyCode.F))
                {
                    // Un-parent the object when released
                pickedItem.GetComponent<Rigidbody>().isKinematic = false;
                    pickedItem.transform.SetParent(null);
                    pickedItem = null;
                }
            }

            // If the ray hits evidence
            if (target.CompareTag("evidence"))
            {
                if (Physics.Raycast(ray, out hit, rayDistance))
                {
                    line.startColor = Color.green;
                    line.endColor = Color.green;
                }
                else
                {
                    line.startColor = Color.red;
                    line.endColor = Color.red;
                }
                if (TiltFive.Input.GetButtonDown(TiltFive.Input.WandButton.Y) || UnityEngine.Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("F pressed on evidence");

                    for (int i = 0; i < inventorylist.items.Length; i++)
                    {
                        if (target.name == inventorylist.items[i].name)
                        {
                            GlobalInventoryManagerScript.Instance.addToInventory(i);
                            audiosource.Play();
                        }
                    }
                }
            }
        }
    }
}
