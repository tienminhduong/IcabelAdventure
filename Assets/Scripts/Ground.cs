using UnityEngine;

public class Ground : PooledObject
{
    [SerializeField] private SpriteRenderer[] childSpriteRenderer = null;

    protected override void Awake()
    {
        base.Awake();
        childSpriteRenderer = GetComponentsInChildren<SpriteRenderer>();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    private void SetLength(float length)
    {
        childSpriteRenderer[(int)PartIndex.Middle].size = new Vector2(length, childSpriteRenderer[(int)PartIndex.Middle].size.y);
        childSpriteRenderer[(int)PartIndex.LowerMiddle].size = new Vector2(length, childSpriteRenderer[(int)PartIndex.LowerMiddle].size.y);

        for (int i = 0; i < childSpriteRenderer.Length; i++)
        {
            if (i == (int)PartIndex.Middle || i == (int)PartIndex.LowerMiddle)
                continue;

            int partDirection = i == (int)PartIndex.Head || i == (int)PartIndex.LowerHead ? -1 : 1;
            childSpriteRenderer[i].transform.localPosition
                = new Vector3(length / 2f * partDirection,
                childSpriteRenderer[i].transform.localPosition.y,
                childSpriteRenderer[i].transform.localPosition.z);
        }

        boxCollider.size = new Vector2(length + 1 /* Middle part + Head (0.5) + Tail (0.5) */, boxCollider.size.y);
    }

    public override void ResetObject()
    {
        base.ResetObject();

        float randomLength = groundLengths[Random.Range(0, groundLengths.Length)];
        SetLength(randomLength);
    }

    private readonly float[] groundLengths = { 15f, 25f, 35f };
    private enum PartIndex
    {
        Head,
        Middle,
        Tail,
        LowerHead,
        LowerMiddle,
        LowerTail
    }
}
