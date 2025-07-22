using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FruitButton : MonoBehaviour
{
    [SerializeField] Image fruitImage;

    [SerializeField] FruitEventPublisher throwAwayPublisher;
    [SerializeField] private Fruit fruit;

    public void SetFruit(Fruit fruit)
    {
        this.fruit = fruit;
        fruitImage.sprite = fruit.FruitData.fruitSprite;
    }

    public void ThrowAway()
    {
        if (fruit != null)
        {
            throwAwayPublisher.RaiseEvent(fruit);
            ObjectPoolManager.ReturnToPool(fruit.gameObject);
            Destroy(gameObject);
            Debug.Log($"Fruit {fruit.gameObject.name} thrown away.");
        }
    }

    public void OnThrowRandom(Fruit fruit)
    {
        if (fruit == this.fruit)
            ThrowAway();
    }
}
