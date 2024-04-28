using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform vrCamera;

    void Start()
    {
        vrCamera = Camera.main.transform;
    }

    void Update()
{
    transform.position = new Vector3(vrCamera.position.x, vrCamera.position.y, vrCamera.position.z);
    transform.rotation = Quaternion.Euler(0, vrCamera.eulerAngles.y, 0);

    if (Input.GetButtonDown("Fire1")) // Произвольная кнопка для взаимодействия, можно изменить на нужную
    {
        RaycastHit hit;
        if (Physics.Raycast(vrCamera.position, vrCamera.forward, out hit, 10f))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                interactable.PickUp();
            }
        }
    }

    if (Input.GetButtonUp("Fire1")) // Произвольная кнопка для отпускания предмета, можно изменить
    {
        InteractableObject[] interactables = FindObjectsOfType<InteractableObject>();
        foreach (InteractableObject interactable in interactables)
        {
            interactable.Drop();
        }
    }
}
}