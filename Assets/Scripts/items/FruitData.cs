using UnityEngine;

[CreateAssetMenu(fileName = "FruitData", menuName = "Scriptable Objects/FruitData")]
public class FruitData : ScriptableObject
{
    public string fruitName;
    public float weight;
    public RuntimeAnimatorController animationController;
}
