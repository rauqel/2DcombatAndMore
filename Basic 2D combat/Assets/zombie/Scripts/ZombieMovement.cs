using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [Header("Arm Offsets")]
    [SerializeField] private Vector2 walkOffset;
    [SerializeField] private Vector2 fallOffSet;

    [Header("Shoulder Anchor")]
    [SerializeField] private ZombieArm armScript;

    [Header("Track Player")]
    [SerializeField] private GameObject playerObject;
    private bool isFacingRight;

    [SerializeField] private float zomSpeed;
    private float distance;


    private Rigidbody2D zombieRB;

    private void Awake()
    {
        zombieRB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ZombieToPlayer();
        ZombieFlip();

        UpdateArmOffset();
    }

    private void ZombieToPlayer()
    {
        distance = Vector2.Distance(transform.position, playerObject.transform.position);
        Vector2 direction = playerObject.transform.position - transform.position;
        direction.Normalize();

        transform.position = Vector2.MoveTowards
            (zombieRB.transform.position, playerObject.transform.position, zomSpeed * Time.deltaTime);
    }

    private void ZombieFlip()
    {
        if(playerObject.transform.position.x < gameObject.transform.position.x)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 0, this.transform.eulerAngles.z);
            isFacingRight = false;
        }
        if(playerObject.transform.position.x > gameObject.transform.position.x)
        {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, 180, this.transform.eulerAngles.z);
            isFacingRight = true;
        }
    }

    private void UpdateArmOffset()
    {
        Vector2 currentOffSet = Vector2.zero;

        //falling
        /*if(zombieRB.velocity.y < 0)
        {
            currentOffSet = fallOffSet;
        }
        else*/
        currentOffSet.y = walkOffset.y;
        currentOffSet.x = armScript.partOffSet.x;

        if (!isFacingRight)
        {
            currentOffSet.x *= -1f;
        }

        armScript.partOffSet = currentOffSet;
    }
}
