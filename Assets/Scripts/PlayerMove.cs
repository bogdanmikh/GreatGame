using UnityEngine;

public class PlayerMove : MonoBehaviour {
    
    // скорость игрока
    public int horisontalSpeed;
    public int verticalSpeed;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public Rigidbody2D rigidbody;

    // направление игрока
    public bool isFacingRight = true;

    private float direction;

    private bool flipActive = false;

    private float jumpPower = 0;
    private int jumpCount = 0;

    private Animator anim;

    private void Awake() {
        anim = GetComponent<Animator>();
    }

    private States State {
        get { return (States)anim.GetInteger("State"); }
        set { anim.SetInteger("State", (int)value); }
    }


    private void FixedUpdate() {
        if (!isGrounded() && rigidbody.velocity.y >= 0.2f || rigidbody.velocity.y <= -0.2f) {
            State = States.Jump;
        } else if (rigidbody.velocity.x >= -0.5f && rigidbody.velocity.x <= 0.5f) {
            State = States.Idle;
        } else {
            State = States.Run;
        }

        if (isGrounded() && jumpCount != 0) jumpCount = 0;

        Flip();

        if (jumpPower > 0) { 
            rigidbody.velocity = new Vector2(direction * horisontalSpeed * Time.deltaTime, jumpPower);
            jumpPower = 0; 
        } else {
            rigidbody.velocity = new Vector2(direction * horisontalSpeed * Time.deltaTime, rigidbody.velocity.y);
        }
    }

    public void OnJumpButton() {
        if (isGrounded()) {
            jumpCount++;
            jumpPower = verticalSpeed * Time.fixedDeltaTime;
        } else if (jumpCount + 1 <= 1) {
            jumpCount++;
            jumpPower = verticalSpeed * Time.fixedDeltaTime;
        }
    }

    public void OnLeftButton() {
        isFacingRight = false;
        flipActive = true;
        direction = -1;
    }
    public void OnRightButton() {
        isFacingRight = true;
        flipActive = true;
        direction = 1;
    }

    public void OnButtonUp() {
        direction = 0;
    }

    private bool isGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

    private void Flip() {
        if (flipActive) {
            if ((isFacingRight && transform.localScale.x < 0) ||
                (!isFacingRight && transform.localScale.x > 0)) {
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
            flipActive = false;
        } 
    }

    public void jumpKill() {
        jumpPower = verticalSpeed * 0.9f * Time.fixedDeltaTime;
    }
}

public enum States {
    Idle,
    Run,
    Jump
}