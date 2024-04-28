using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool isBeingHeld = false;
    private Transform vrCamera;

    void Start()
    {
        vrCamera = Camera.main.transform;
    }

    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 newPosition = vrCamera.position + vrCamera.forward * 2f; // Расстояние, на котором держится предмет
            transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
        }
    }

    public void PickUp()
    {
        isBeingHeld = true;
    }

    public void Drop()
    {
        isBeingHeld = false;
    }
}