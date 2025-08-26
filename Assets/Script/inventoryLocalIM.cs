using UnityEngine;

public class inventoryLocalIM : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject[] items;
    private Rigidbody rb;
    private bool inspect = false;
    private bool dragObject = false;
    private UnityEngine.Vector3 offset;
    private GameObject objectDrag;
    private GameObject objectSelect;
    private bool isDragging;
    public float rotationSpeed = 5f;
   // public GlobalInventoryManagerScript globalInventoryManagerScript;
    void Start()
    {
        offset = transform.position - GetMouseWorldPosition();


        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(false);

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if ((items[i] != null) && GlobalInventoryManagerScript.Instance.itemStatus[i] && !items[i].activeSelf)
            {
                items[i].SetActive(true);
                Debug.Log($"Item {i} activated.");
            }
        }


        // Detect left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit is THIS object
                for (int i = 0; i < items.Length; i++)
                {
                    if ((hit.transform == items[i].transform) && inspect == false)
                    {
                        objectSelect = items[i];
                        Debug.Log("Object clicked: " + items[i]);
                        EvidenceClicked(items[i]);
                    }
                }
            }
        }



        // Detect left mouse button click
        if (Input.GetMouseButtonDown(1))
        {
            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit is THIS object
                for (int i = 0; i < items.Length; i++)
                {
                    if ((hit.transform == items[i].transform) && inspect == false)
                    {
                        objectDrag = items[i];
                        dragObject = true;
                        Debug.Log("right clicked");
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            dragObject = false;
            Debug.Log("mouse is released");
        }



        if ((Input.GetKeyDown(KeyCode.D)) && inspect == true)
        {
            inspect = false;
            gameObject.transform.position += UnityEngine.Vector3.down * 4;
            rb.useGravity = true;
        }

        if (dragObject == true)
        {
            objectDrag.transform.position = GetMouseWorldPosition() + offset;
        }

        if (inspect == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
            }

            // Mouse button up = stop dragging
            if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
            }

            // If dragging, rotate based on mouse movement
            if (isDragging)
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                // Rotate around Y (horizontal drag) and X (vertical drag)
                objectSelect.transform.Rotate(UnityEngine.Vector3.up, -mouseX * rotationSpeed, Space.World);
                objectSelect.transform.Rotate(UnityEngine.Vector3.right, mouseY * rotationSpeed, Space.World);
            }
        }
    }
    private UnityEngine.Vector3 GetMouseWorldPosition()
    {
        // Get mouse position and convert it to world space
        UnityEngine.Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
    void EvidenceClicked(GameObject gameObject)
    {
        isDragging = false;
        inspect = true;
        rb = gameObject.GetComponent<Rigidbody>();
        gameObject.transform.position += UnityEngine.Vector3.up * 4;
        rb.useGravity = false;
    }

}