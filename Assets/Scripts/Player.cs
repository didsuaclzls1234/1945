using System.Runtime.CompilerServices;
using UnityEngine;
//using System.Collections.Generic; //리스트 사용 위해 추가

public class Player : MonoBehaviour
{
   public float moveSpeed=5f;
   Animator animator;//애니메이터 컴포넌트

    public GameObject[] bulletPrefab;
    //public List<GameObject> bulletPrefab=new List<GameObject>();
    
    public Transform pos;

    public int power=0;//높아질수록 무기 강화
    [SerializeField]
    GameObject Powerup;//파워업이펙트

    public GameObject Bomb;
   

   void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //이동
        Vector2 input=new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        if(input.sqrMagnitude>1f)
        {
            input.Normalize();
        }
        Vector3 move=new Vector3(input.x,input.y,0)*moveSpeed*Time.deltaTime;
        transform.Translate(move,Space.World);

        //애니메이션 -1,0,1
        if (Input.GetAxis("Horizontal") <= -0.5f)
        {
            animator.SetBool("left",true);
        }
        else
        {
            animator.SetBool("left",false);
        }

        if(Input.GetAxis("Horizontal") >= 0.5f)
        {
            animator.SetBool("right",true);
        }
        else
        {
            animator.SetBool("right",false);
        }

        if(Input.GetAxis("Vertical") >= 0.5f)
        {
            animator.SetBool("up",true);
        }
        else
        {
            animator.SetBool("up",false);
        }

         //미사일 발사
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab[power],pos.position,Quaternion.identity);
        }
        //폭탄 발사
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            GameObject go=Instantiate(Bomb,Vector3.zero,Quaternion.identity);
            Destroy(go,2f);
        }

        //화면 밖으로 나가지 않도록 월드 좌표를 뷰포트 좌표로 변환
        Vector3 viewPos=Camera.main.WorldToViewportPoint(transform.position);
        //뷰포트 x,y좌표를 0~1사이로 클램프
        viewPos.x=Mathf.Clamp01(viewPos.x);
        viewPos.y=Mathf.Clamp01(viewPos.y);
        //클램프 된 뷰포트 좌표를 다시 월드 좌표로 변환하여 적용
        Vector3 worldPos=Camera.main.ViewportToWorldPoint(viewPos);
        transform.position=worldPos;

       
    }

    //파워업 아이템 획득
    private void OnTriggerEnter2D(Collider2D collision)
       {
           if(collision.gameObject.CompareTag("Item"))
           {
                
                if(power<3)
                {
                    power++;
                    GameObject go=Instantiate(Powerup,transform.position,Quaternion.identity);
                    Destroy(go,1f);
                }

                
               Destroy(collision.gameObject);
           }
       }
}
