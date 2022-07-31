using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    [Header("旋转速度")]
    [SerializeField] [Range(0, 10)] float rotateSpeed;
    [Header("消失时间")]
    [SerializeField] [Range(0, 10)] float disappearTime;

    Collider col;
    MeshRenderer meshRenderer;

    WaitForSeconds waitFor;
    private void Start()
    {
        waitFor = new WaitForSeconds(disappearTime);
        col = GetComponent<Collider>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.fixedDeltaTime * 10);
    }

    public void Disappear()
    {
        StartCoroutine(nameof(DisappearLater));
    }

    IEnumerator DisappearLater()
    {
        SetDisappear(false);
        yield return waitFor;
        SetDisappear(true);
       
    }

    private void SetDisappear(bool enable)
    {
        col.enabled = enable;
        meshRenderer.enabled = enable;
    }
}
