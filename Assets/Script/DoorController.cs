using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool MotorWorking;
    public Animator animator;
    public float Toggle;

    void Update()
    {
        animator.SetFloat("Toggle", Toggle);

        if (MotorWorking)
        {
            Toggle = 1;
        }
        else
        {
            Toggle = 0;
        }
    }
}
