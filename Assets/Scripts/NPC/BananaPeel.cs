using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Villager villager))
        {
            villager.FallOnBanana();
            Destroy(this.gameObject);
        }
    }
}
