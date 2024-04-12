using UnityEngine;

public class InteractableObject : MonoBehaviour
{

    private InteractableObjectsControlller _interactableObjectsControlller;

    public void Init(InteractableObjectsControlller interactableObjectsControlller)
    {
        _interactableObjectsControlller = interactableObjectsControlller;
    }

    private void Interact()
    {
        _interactableObjectsControlller.ObjectInteract(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Interact();
    }





}
