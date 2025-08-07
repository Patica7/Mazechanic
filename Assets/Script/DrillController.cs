using UnityEngine;

public class DrillController : MonoBehaviour
{
    public GameObject ArivalPos;
    public GameObject StartingPos;
    public float Radius;
    public Sprite CoalSprite;
    private GameObject Coal;
    public LayerMask LayerMask;

    private void Update()
    {
        Coal = Physics2D.OverlapCircle(StartingPos.transform.position, Radius, LayerMask) != null ? Physics2D.OverlapCircle(StartingPos.transform.position, Radius, LayerMask).gameObject : null;

        if (Coal != null && Coal.transform.parent == null)
        {
            Coal.transform.position = ArivalPos.transform.position;
            Coal.GetComponent<SpriteRenderer>().sprite = CoalSprite;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(StartingPos.transform.position, Radius);
    }
}
