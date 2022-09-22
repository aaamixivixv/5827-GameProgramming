using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private Collider2D _playerCollider;
    private void Start()
    {
        _playerCollider = GetComponent<Collider2D>();
    }
    private void OntriggerEnter2D(Collider2D col)
    {
        if (_playerCollider.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            Debug.Log("Die");
        }
    }
}
