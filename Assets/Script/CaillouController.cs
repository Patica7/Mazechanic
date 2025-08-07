using UnityEngine;

public class CaillouController : MonoBehaviour
{
    public PickableObject pickableObject;
    public SpriteRenderer spriteRenderer;

    void Update()
    {

        if (pickableObject.PickedUp)
        {
            spriteRenderer.sortingOrder = 4;
        }
        else
        {
            spriteRenderer.sortingOrder = 1;
        }
    }
}