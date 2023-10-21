using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyAttack : PhongMonobehaviour
{
    [Header("==Boss Attacking==")]
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float attackTime = 0f;
    [SerializeField] protected bool isAttacking = false;
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
}
