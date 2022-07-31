using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [Header("重叠检测遮罩层")]
    [SerializeField] LayerMask mask;
    [Header("重叠检测半径")]
    [SerializeField]  float detectionRadius;
    [Header("检测位置")]
    [SerializeField] Transform detector;
    //必须初始化碰撞体数组对象，否则无法检测
    private Collider[] colliderResults = new Collider[2];

    public bool isGround => Physics.OverlapSphereNonAlloc(detector.position,
        detectionRadius, colliderResults, mask) > 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detector.position, detectionRadius);
    }
}
