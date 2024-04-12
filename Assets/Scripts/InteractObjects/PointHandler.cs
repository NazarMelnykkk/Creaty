using UnityEngine;

public class PointHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private float _rayDistance = 50f;

    private Vector3 _direction;

    private void Update()
    {
        Debug.DrawRay(transform.position, _direction * _rayDistance, Color.red);
    }

    public Vector3 GetPoint(Vector2 direction)
    {
        _direction = new Vector3(direction.x, 0f, direction.y); 
        RaycastHit hit;
        if (Physics.Raycast(transform.position, _direction, out hit, _rayDistance, _targetLayer))
        {
            Vector3 hitPoint = hit.point - _direction /2; 
            return new Vector3(hitPoint.x, transform.position.y, hitPoint.z);
        }
        else
        {
            return transform.position;
        }
    }
}
