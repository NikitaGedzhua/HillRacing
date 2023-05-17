using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private List<GameObject> lootable; 
    
    private void OnEnable()
    {
        foreach (var loot in lootable)
        {
            loot.SetActive(true);
        }
    }
}
