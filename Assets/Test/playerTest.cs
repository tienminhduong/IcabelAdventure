using System;
using UnityEngine;

public class playerTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float Hp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(Hp);
    }

    public void DecreaseHp(float hp)
    {
        if (Hp > hp)
        {
            Hp = hp;
        }

        hp -= Hp;
    }

    public void KnockOut()
    {
        Hp = 0;
    }    

    public bool IsAlive()
    {
        return Hp > 0;
    }
}
