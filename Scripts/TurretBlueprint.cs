using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public GameObject upgradePrefab;
    public int cost;
    public int upgradeCost;
    public int GetSellCost()
    {
        return cost / 2;
    }
}