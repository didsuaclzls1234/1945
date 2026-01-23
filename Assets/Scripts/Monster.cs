using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int HP=100;
    public float Speed=3f;
    public float Delay=1f;
    public Transform missile1;
    public Transform missile2;
    public GameObject bulletPrefab;
    //아이템 가져오기
    [SerializeField]
    private GameObject Item_Power;
    
    [SerializeField]
    private GameObject Effect;
    void Start()
    {
        Invoke("CreateBullet",  Delay);
    }

    void CreateBullet()
    {
        Instantiate(bulletPrefab, missile1.position, Quaternion.identity);
        Instantiate(bulletPrefab, missile2.position, Quaternion.identity);
        Invoke("CreateBullet",  Delay);
    }

    // Update is called once per frame
    void Update()
    {
        //아래 방향으로 이동
        transform.Translate(Vector3.down*Speed*Time.deltaTime);
    }

    //미사일에 따른 데미지
    public void Damage(int attack)
    {
        HP -= attack;
        if(HP <= 0)
        {
            //아이템 드롭
            GameObject go=Instantiate(Effect,transform.position,Quaternion.identity);
            Destroy(go,1f);
            
            ItemDrop();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player_Bullet"))
        {
            //미사일 데미지 받기
            int attack = collision.gameObject.GetComponent<Player_Bullet>().Attack;
            Damage(attack);
            // Destroy(collision.gameObject);
        }

        if(collision.gameObject.CompareTag("Player_Bomb"))
        {
            //폭탄 충돌 시 체력만큼 데미지
            Damage(HP);
            Destroy(gameObject);
        }
    }

    public void ItemDrop()
    {
        Instantiate(Item_Power, transform.position, Quaternion.identity);
    }
}
