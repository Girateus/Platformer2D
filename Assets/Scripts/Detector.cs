using System;
using TMPro;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Vector2 _offset;
    [SerializeField] private Vector2 _size;
    [SerializeField] private LayerMask _mask;
    public bool Touched = false;

    private void Update()
    {
        Touched = Physics2D.OverlapBox(transform.position , _size, 0, _mask);
    }

    private void OnDrawGizmos()
    {
        if(Touched)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,  new Vector3(_size.x, _size.y, 0));
    }
    
}
