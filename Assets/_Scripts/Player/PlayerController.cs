using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;
    Rigidbody rigid;
    GroundDetector groundDetector;

    private bool canAirJump = false;
    public bool CanAirJump
    {
        get { return canAirJump; }
        set { canAirJump = value; }
    }

    private void Start()
    {
        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody>();
        groundDetector = GetComponent<GroundDetector>();

        input.SetPlayerInputEnable();
    }

    public Vector2 MoveSpeed => rigid.velocity;


    public void SetHorizontalVelocity(float x)
    {
        rigid.velocity = new Vector2(x, rigid.velocity.y);
    }

    public void SetVerticalVelocity(float y)
    {
        rigid.velocity = new Vector2(rigid.velocity.x, y);
    }

    public void FlipX()
    {
        transform.localScale = new Vector3(-1, 1, 1);
    }

    public void NoFlipX()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public bool isGround()
    {
        return groundDetector.isGround;
    }

    public void SetGravity(bool enable)
    {
        rigid.useGravity = enable;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
            if (other.CompareTag("Gem"))
            {
                canAirJump = true;
                other.GetComponent<GemController>()?.Disappear();
            }
    }

}
