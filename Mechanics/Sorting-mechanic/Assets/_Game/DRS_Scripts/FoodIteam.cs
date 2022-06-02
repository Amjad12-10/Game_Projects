using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FoodIteam : MonoBehaviour
{
    // Target Number 
    public int TargetNumber;
    // Positions
    private Vector3 CurrentPosition, Position1;
    [SerializeField]private Vector3 OffsettoAdd = new Vector3(0,0,21.75f);
    // RayCast
    [SerializeField] private LayerMask layer;
    [SerializeField] private Collider GroundCollider;
    // Data
    private Collider OtherObject;
    private Vector3 MousePosition;
    private bool inSheel, isGrap;
    private void Update()
    {
        if (isGrap) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, layer))
            {
                MousePosition = hit.point;
                this.transform.position = MousePosition;
            }
        }
    }
    private void OnMouseDown()
    {
        CurrentPosition = this.transform.position;
        Position1 = this.transform.position;
        GroundCollider.enabled = true;
        isGrap = true;
    }
    private void OnMouseUp()
    {
        isGrap = false;
        GroundCollider.enabled = false;
        
        // PositionSetUP
        if (!inSheel) 
        {
            this.transform.position = CurrentPosition;
        }
        else
        {
            this.transform.position = Position1;
            OtherObject.transform.DOJump(CurrentPosition,4, 1, 0.5f, false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Holder")) 
        {
            OtherObject = other;
            inSheel = true;
            other.transform.DOScale(0.6f, 0.25f);
            if (isGrap) 
            {
                Position1 = other.transform.position;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Holder"))
        {
            if (OtherObject != null)
            {
                OtherObject = null;
            }
            other.transform.DOScale(1, 0.25f);
            inSheel = false;
            Position1 = CurrentPosition;
        }
    }
}
