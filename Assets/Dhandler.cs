using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Dhandler : MonoBehaviour
{
    public Text maintext; // UI Text for displaying the main text
    public Text mainname; // UI Text for displaying the NPC name
    public GameObject main; // UI panel or object to show the text
    public float interactionDistance = 5f; // Distance for raycasting

    private Camera playerCamera;
    private bool isInRange = false; // Flag to check if the player is in range
    public Npc currentNPC; // Reference to the current NPC

    void Start()
    {
        playerCamera = Camera.main; // Get the main camera
    }

    public IEnumerator WriteText(string text, string name, float time) 
    {
        main.SetActive(true); // Show the UI panel
        maintext.text = text; // Set the main text
        mainname.text = name; // Set the NPC name
        yield return new WaitForSeconds(time); // Wait for the specified time
        main.SetActive(false); // Hide the UI panel
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) // Check if the player is in range and presses "E"
        {
            if (currentNPC != null)
            {
                StartCoroutine(WriteText(currentNPC.npcText, currentNPC.npcName, 5f)); // Display the text and name for the NPC
            }
        }
    }

    // Trigger methods to detect player entering and exiting the collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            isInRange = true; // Set the flag to true
            currentNPC = GetComponent<Npc>(); // Get the NPC component attached to this GameObject
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the object is the player
        {
            isInRange = false; // Set the flag to false
            currentNPC = null; // Clear the current NPC reference
        }
    }
}
