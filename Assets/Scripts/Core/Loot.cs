using UnityEngine;

public class Loot : MonoBehaviour, ILootable
{
   [SerializeField] private int coinValue = 1;
  
   public void OnLoot()
   {
      this.OnEvent(eEventType.CoinPicked, coinValue);
      gameObject.SetActive(false);
   }
}
