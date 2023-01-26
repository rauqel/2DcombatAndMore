using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieArm : MonoBehaviour
{
    public Vector2 partOffSet = Vector2.zero;
    public float lerpSpeed = 20f;

    [SerializeField] private Transform[] armParts;

    private Transform shoulderAnchor;

    private void Awake()
    {
        shoulderAnchor = GetComponent<Transform>();
        armParts = GetComponentsInChildren<Transform>();
    }

    private void Update()
    {
        Transform pieceToFollow = shoulderAnchor;

        foreach(Transform armPart in armParts)
        {
            if (!armPart.Equals(shoulderAnchor))
            {
                Vector2 targetPosition = (Vector2)pieceToFollow.position + partOffSet;
                Vector2 newPosLerped = Vector2.Lerp(armPart.position, targetPosition, Time.deltaTime * lerpSpeed);

                armPart.position = newPosLerped;
                pieceToFollow = armPart;
            }
        }
    }
}
