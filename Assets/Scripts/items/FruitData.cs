using UnityEngine;

[CreateAssetMenu(fileName = "FruitData", menuName = "Scriptable Objects/FruitData")]
public class FruitData : ScriptableObject
{
    public float weight;
    public Sprite fruitSprite;
    public RuntimeAnimatorController animationController;
}
