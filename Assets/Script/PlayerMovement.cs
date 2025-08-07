using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public string ActiveScene;

    public GameObject ActiveObject;

    public float MoveSpeed;
    public bool isMoving;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(ActiveScene);
        }

        if (horizontalMovement != 0 || verticalMovement != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        animator.SetFloat("moveY", verticalMovement);
        animator.SetFloat("moveX", horizontalMovement);
        animator.SetBool("isMoving", isMoving);
        MovePlayer(horizontalMovement, verticalMovement);
        Flip(rb.linearVelocityX);
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = true;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = false;
        }
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        targetVelocity.Normalize();
        targetVelocity = targetVelocity * MoveSpeed * Time.deltaTime;
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .03f);
    }
}
