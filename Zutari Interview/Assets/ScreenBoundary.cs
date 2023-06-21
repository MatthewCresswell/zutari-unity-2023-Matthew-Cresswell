using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//checks to see if Box Collider is attached to any item with this script attached. If no box collider detected, adds collider.
[RequireComponent(typeof(BoxCollider2D))]
public class ScreenBoundary : MonoBehaviour
{
    public Camera mainCamera;
    BoxCollider2D boxCollider;

    public UnityEvent<Collider2D> ExitColliderEvent;
    
    [SerializeField] private float teleportOffset = 0.2f;
    [SerializeField] private float cornerOffset = 1f;

    private void Awake()
    {
        this.mainCamera.transform.localScale = Vector3.one; //fixes cameras scale to 1
        boxCollider = GetComponent<BoxCollider2D>(); //finds the collider component of the boundary and sets it to our boxCollider variable.
        boxCollider.isTrigger = true; //makes sure the collider is set to trigger
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;
        UpdateBoundarySize();
    }

    public void UpdateBoundarySize()
    {
        float cameraHeight = mainCamera.orthographicSize * 2;
        Vector2 boxColliderSize = new Vector2(cameraHeight * mainCamera.aspect, cameraHeight);
        boxCollider.size = boxColliderSize;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ExitColliderEvent?.Invoke(collision);
    }

    public bool IsOutOfBounds(Vector3 worldPos)
    {
        return
            Mathf.Abs(worldPos.x) > Mathf.Abs(boxCollider.bounds.min.x) || 
            Mathf.Abs(worldPos.y) > Mathf.Abs(boxCollider.bounds.min.y);
    }

    public Vector2 CalculateWrappedPosition(Vector2 worldPosition)
    {
        bool xBoundResult = Mathf.Abs(worldPosition.x) > (Mathf.Abs(boxCollider.bounds.min.x) - cornerOffset);
        bool yBoundResult = Mathf.Abs(worldPosition.y) > (Mathf.Abs(boxCollider.bounds.min.y) - cornerOffset);
        Vector2 signWorldPosition = new Vector2(Mathf.Sign(worldPosition.x), Mathf.Sign(worldPosition.y));

        if(xBoundResult && yBoundResult) // corner
        {
            return Vector2.Scale(worldPosition, Vector2.one * -1) + Vector2.Scale(new Vector2(teleportOffset, teleportOffset), signWorldPosition);
        }
        else if (xBoundResult) // x-axis
        {
            return new Vector2(worldPosition.x * -1, worldPosition.y)
             + new Vector2(teleportOffset * signWorldPosition.x, teleportOffset);
        }
        else if (yBoundResult)
        {
            return new Vector2(worldPosition.x, worldPosition.y * -1)
            + new Vector2(teleportOffset, teleportOffset * signWorldPosition.y);
        }
        else
        {
            return worldPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
