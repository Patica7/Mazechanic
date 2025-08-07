using UnityEngine;

public class PickaxeController : MonoBehaviour
{
    public bool HasBeenHittingLasFrame;
    public bool IsHitting;

    public SpriteRenderer spriteRenderer;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Rock") && !HasBeenHittingLasFrame)
        {
            collision.GetComponent<RockController>().Hp -= 1;
            HasBeenHittingLasFrame = true;
        }
        else
        {
            HasBeenHittingLasFrame = false;
        }
    }

    private void Update()
    {
        animator.SetBool("IsHitting", IsHitting);

        if (transform.parent.GetComponent<PickableObject>().PickedUp)
        {
            if (transform.parent.GetComponent<PickableObject>().Player.GetComponent<SpriteRenderer>().flipX)
            {
                animator.SetFloat("flip", 1);
            }
            else
            {
                animator.SetFloat("flip", 0);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !transform.parent.GetComponent<PickableObject>().HasBeenPicked)
            {
                IsHitting = true;
            }
        }

        if (IsHitting)
        {
            spriteRenderer.sortingOrder = 4;
        }
        else
        {
            spriteRenderer.sortingOrder = 1;
        }
    }

    void StopHitting()
        {
                IsHitting = false;
        }
}
