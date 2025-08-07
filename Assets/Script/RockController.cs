using UnityEngine;

public class RockController : MonoBehaviour
{
    public int Hp;

    void Update()
    {
        if ( Hp == 0)
        {
            Destroy(gameObject);
        }
    }
}
