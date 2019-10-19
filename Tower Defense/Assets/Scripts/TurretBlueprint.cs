using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    [Header("Building")]
    public GameObject prefab;
    public int cost;
    [Header("Upgrading")]
    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellCost()
    {
        return cost / 2;
    }
}