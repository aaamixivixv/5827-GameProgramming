using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float JumpPadForce = 13f;
    [SerializeField] private float additionalSleepJumpTime = 0.3f;
    private static readonly int Bounce = Animator.StringToHash("Bounce");
    public float GetJumpPadForce() => JumpPadForce;
    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;

    public void TriggerJumpPad()
    {
        animator.SetTrigger(Bounce);
    }
}
