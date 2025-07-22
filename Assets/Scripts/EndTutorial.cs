using UnityEngine;

public class EndTutorial : PooledObject
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(ConstValue.PLAYER_TAG))
        {
            GameManager.Instance.RestartGame();
        }
    }
}
