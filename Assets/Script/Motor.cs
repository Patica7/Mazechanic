using UnityEngine;

public class Motor : MonoBehaviour
{
    public bool IsWorking;
    public Sprite CoalSprite;
    public Animator animator;
    public GameObject Door;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SpriteRenderer>().sprite == CoalSprite && !IsWorking)
        {
            Destroy(collision.gameObject);
            IsWorking = true;
            Door.GetComponent<DoorController>().MotorWorking = true;
        }
    }

    void Update()
    {
        animator.SetBool("IsWorking", IsWorking);
    }
}
