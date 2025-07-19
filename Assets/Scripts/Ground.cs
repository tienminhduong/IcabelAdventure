using System.Collections;
using UnityEngine;

public class Ground : PooledObject
{
    [SerializeField] private float groundLength;

    [SerializeField] private SpriteRenderer middleGroundPartRender;

    private readonly float[] groundLengths = { 15f, 25f, 35f };

    protected override void Start()
    {
        base.Start();
        StartCoroutine(DestroyAfter(5f));
    }

    IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ReturnPool();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void SetLength(float length)
    {
        middleGroundPartRender.size = new Vector2(length, middleGroundPartRender.size.y);
        boxCollider.size = new Vector2(length + 1 /* Middle part + Head (0.5) + Tail (0.5) */, boxCollider.size.y);
    }

    public override void ResetObject()
    {
        base.ResetObject();

        float randomLength = groundLengths[Random.Range(0, groundLengths.Length)];
        SetLength(randomLength);
    }
}
