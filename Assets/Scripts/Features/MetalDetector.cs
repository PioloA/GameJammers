using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalDetector : MonoBehaviour
{
    [SerializeField]
    private float _detectionRadius = 3.0f;
    private int _score = 0;
    public LayerMask _metalObjectLayer;
    public GameObject DetectionIndicator;
    
    void Update()
    {
        Collider[] metalObjects = Physics.OverlapSphere(transform.position, _detectionRadius, _metalObjectLayer);

        if (metalObjects.Length > 0)
        {
            DetectionIndicator.SetActive(true);

            // Player input to get Metals
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (Collider metalObject in metalObjects)
                {
                    // check if metal object has the component "MetalPickUp"
                    MetalPickUp metalPickUp = metalObject.GetComponent<MetalPickUp>();
                    if (metalPickUp != null)
                    {
                        _score += metalPickUp.pointValue;
                        GameManager.instance.IncreaseScore(metalPickUp.pointValue);
                        Destroy(metalPickUp.gameObject);
                    }
                }
            }
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
