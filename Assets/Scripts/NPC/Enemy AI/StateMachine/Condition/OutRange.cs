using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutRange : Condition
{
    [SerializeField] private LayerMask whatIsTarget;
    [SerializeField] private float radius = 1f;
    [SerializeField] private Transform _center;
    public override bool IsMet()
    {
        if (Physics.OverlapSphere(_center.position, radius,whatIsTarget).Length>0)
        {
            return false;
        }

        return true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_center.position, radius);
    }
}
