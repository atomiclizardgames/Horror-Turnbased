using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private GridManager gridManager;
    private Vector3Int targetGridPosition;
    private bool isMoving = false;
    public float moveSpeed = 5f;

    private void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        targetGridPosition = gridManager.GetGridPosition(transform.position);
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveToTarget();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        }
    }

    void SetTargetPosition()
    {
        // Get the mouse position and convert it to a ray
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3Int clickedGridPosition = gridManager.GetGridPosition(hit.point);

            // Check if the title is walkable
            if (gridManager.IsTileWalkable(clickedGridPosition))
            {
                targetGridPosition = clickedGridPosition;
                isMoving = true;
            }

        }
    }

    void MoveToTarget()
    {
        Vector3 targetWorldPosition = gridManager.GetWorldPosition(targetGridPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetWorldPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWorldPosition) < 0.1f)
        {
            transform.position = targetWorldPosition;
            isMoving = false;
        }
    }

}
