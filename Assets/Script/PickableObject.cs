using UnityEngine;

public class PickableObject : MonoBehaviour
{
    public bool PickedUp;
    public bool IsInRange;
    public bool HasBeenPicked;

    public LayerMask LayerMask;
    public float RangeRadius;
    public GameObject Player;

    void Update()
    {
        IsInRange = Physics2D.OverlapCircle(transform.position, RangeRadius, LayerMask);

        if (PickedUp)
        {
            Player.GetComponent<PlayerMovement>().ActiveObject = gameObject;
            transform.parent = Player.transform;
            transform.position = Player.transform.position;
            HasBeenPicked = false;

            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                PickedUp = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsInRange && Player.GetComponent<PlayerMovement>().ActiveObject == null)
            {
                PickedUp = true;
                HasBeenPicked = true;
            }

            Player.GetComponent<PlayerMovement>().ActiveObject = null;
            transform.parent = null;
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RangeRadius);
    }
}
