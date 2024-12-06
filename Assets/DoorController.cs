using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f; // Angle to open the door
    public float openSpeed = 2f; // Speed of opening
    private bool isOpen = false; // Is the door currently open
    private bool isPlayerNear = false; // Is the player near the door
    private Quaternion closedRotation; // Initial rotation of the door
    private Quaternion openRotation; // Target rotation of the door

    public GameObject ui;

    

    void Start()
    {
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + openAngle, transform.eulerAngles.z);
        ui.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            isOpen = !isOpen; // Toggle the door state
        }

        // Smoothly rotate the door
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, openRotation, Time.deltaTime * openSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, closedRotation, Time.deltaTime * openSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Make sure the player has the "Player" tag
        {
            isPlayerNear = true;
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            ui.SetActive(false);
        }
    }
}