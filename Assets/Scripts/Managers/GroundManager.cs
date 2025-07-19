using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] private Ground groundPrefab;

    // The size of the hole, there are 2 sizes: size and double size
    [SerializeField] private float holeBaseSize;
    private float HoleSize => holeBaseSize;

    [Header("For debugging")]
    [SerializeField] private float holeSizeCounter;
    [SerializeField] private bool hasSpawnedNewGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        holeSizeCounter = -1;
        hasSpawnedNewGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleSpawnNewGround();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ConstValue.GROUND_TAG))
        {
            // Start spawning new ground
            holeSizeCounter = HoleSize;
        }
    }

    private void SpawnNewGround()
    {
        var newGround = ObjectPoolManager.SpawnObject(
            groundPrefab,
            transform.position,
            Quaternion.identity
        );

        newGround.transform.position += new Vector3(newGround.ObjectWidth / 2, 0, 0);
        hasSpawnedNewGround = true;
    }

    private void HandleSpawnNewGround()
    {
        if (holeSizeCounter > 0)
        {
            holeSizeCounter -= GameManager.Instance.GameSpeed * Time.deltaTime;
            if (holeSizeCounter <= 0)
            {
                if (!hasSpawnedNewGround)
                    SpawnNewGround();
                else if (Random.Range(0, 2) == 0)
                    SpawnNewGround();
                else {
                    hasSpawnedNewGround = false;
                    holeSizeCounter = HoleSize;
                }
            }
        }
    }
}
