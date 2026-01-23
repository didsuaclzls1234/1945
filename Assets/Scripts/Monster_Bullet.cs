using UnityEngine;

public class Monster_Bullet : MonoBehaviour
{
  public float Speed=3f;
  //공격력
    public int Attack=10;
  void Update()
  {
      //아래 방향으로 이동
      transform.Translate(Vector3.down*Speed*Time.deltaTime);
  }

  private void OnBecameInvisible()
  {
      Destroy(gameObject);
  }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //미사일 지우기

            Destroy(gameObject);
        }
    }
}
