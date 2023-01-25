using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private float zomSpeed;
    private Rigidbody2D zomRB;

    private float distance;

    [SerializeField] private Rigidbody2D hookRB;
    [SerializeField] private Rigidbody2D shoulderRB;

    void Start()
    {
        
    }

    void Update()
    {

        ZombieToPlayer();
    }

    private void ZombieToPlayer()
    {
        distance = Vector2.Distance(transform.position, playerObject.transform.position);
        Vector2 direction = playerObject.transform.position - transform.position;
        direction.Normalize();

        transform.position = Vector2.MoveTowards
            (this.transform.position, playerObject.transform.position, zomSpeed * Time.deltaTime);

        
    }
}
