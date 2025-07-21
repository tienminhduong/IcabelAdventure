using UnityEngine;

public class FruitBasket : MonoBehaviour
{
    [SerializeField] private FruitButton fruitButtonPrefab;
    [SerializeField] private Transform contentTransform;
    public void AddFruit(Fruit fruit)
    {
        FruitButton newButton = Instantiate(fruitButtonPrefab, contentTransform);
        newButton.SetFruit(fruit);
    }
}
