using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{
    [SerializeField]
    private float _detectionRadius = 3.0f;
    public LayerMask _metalObjectLayer;

    public GameObject DetectionIndicator;
    
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _detectionRadius, _metalObjectLayer);

        if (colliders.Length > 0)
        {
            DetectionIndicator.SetActive(true);
        }
        else
        {
            DetectionIndicator.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}
