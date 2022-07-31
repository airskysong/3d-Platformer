using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    [Header("旋转速度")]
    [SerializeField] [Range(0, 10)] float rotateSpeed;
    [Header("消失时间")]
    [SerializeField] [Range(0, 10)] float disappearTime;
    [Header("宝石特效")]
    [SerializeField] GameObject pickUpGemEffect;
    Collider col;
    MeshRenderer meshRenderer;
    GameObject effect;
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
        PlayEffect();
        yield return waitFor;
        DestroyEffect();
        SetDisappear(true);
       
    }

    private void SetDisappear(bool enable)
    {
        col.enabled = enable;
        meshRenderer.enabled = enable;
    }

    private void PlayEffect()
    {
        effect = Instantiate(pickUpGemEffect, transform.position, Quaternion.identity);
        effect.transform.SetParent(transform);
    }

    private void DestroyEffect()
    {
        if (effect != null)
            Destroy(effect);
    }
}
