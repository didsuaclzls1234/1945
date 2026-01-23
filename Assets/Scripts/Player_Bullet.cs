using UnityEngine;

public class Player_Bullet : MonoBehaviour
{
    //속도
    public float Speed=5f;
    
    //공격력
    public int Attack=10;
    //이펙트
    GameObject effect;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //위 방향으로 이동
        transform.Translate(Vector3.up*Speed*Time.deltaTime);
    }

    //gameObject가 화면 밖으로 나가면 삭제
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //적과 충돌했을 때
        if(collision.CompareTag("Monster"))
        {
           //collision.GetComponent<Monster>().Damage(Attack);

           //미사일 삭제
              Destroy(gameObject);
        }
    }
}
