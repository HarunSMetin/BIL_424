using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public float interactionDistance = 2f; // Karakterin kutuya olan etkile�im mesafesi
    private bool isHolding = false;
    public GameObject interactableCube;
    private Vector3 initialOffset;

    private void Update()
    {
        // Raycast ile etkile�ime ge�ilecek kutuyu tespit etme
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("InteractableCube"))
            {
                interactableCube = hit.collider.gameObject;
            }
            else
            {
                interactableCube = null;
            }
        }
        else
        {
            interactableCube = null;
        }

        // E tu�una bas�ld���nda kutuyu ta��mak veya b�rakmak
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isHolding && interactableCube != null)
            {
                isHolding = true;
                initialOffset = interactableCube.transform.position - GetMouseWorldPosition();
            }
            else if (isHolding)
            {
                isHolding = false;
            }
        }

        // Kutuyu ta��ma i�lemi
        if (isHolding && interactableCube != null)
        {
            Vector3 targetPosition = GetMouseWorldPosition() + initialOffset;
            interactableCube.transform.position = new Vector3(targetPosition.x, targetPosition.y, interactableCube.transform.position.z);
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(interactableCube.transform.position).z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
