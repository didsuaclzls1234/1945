using UnityEngine;

public class Homing : MonoBehaviour
{
    public GameObject target;//플레이어
    public float Speed=3f;
    Vector2 dir;
    Vector2 dirNo;

   void Start()
   {
      target=GameObject.FindGameObjectWithTag("Player");

      //플레이어를 바라보는 벡터
      dir=target.transform.position-transform.position;
      //방향 벡터만 구하기-단위벡터로 정규화
      //dir.Normalize();
      dirNo=dir.normalized;   
   }

   void Update()
    {
      //적이 날 쫒아오는 경우
      //     target=GameObject.FindGameObjectWithTag("Player");

      // //플레이어를 바라보는 벡터
      // dir=target.transform.position-transform.position;
      // //방향 벡터만 구하기-단위벡터로 정규화
      
      // dirNo=dir.normalized;   

        transform.Translate(dirNo*Speed*Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
