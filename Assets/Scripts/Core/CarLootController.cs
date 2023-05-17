using UnityEngine;

public class CarLootController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out ILootable loot))
            loot.OnLoot();
    }
}
