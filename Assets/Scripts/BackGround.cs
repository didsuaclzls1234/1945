using UnityEngine;

public class BackGround : MonoBehaviour
{
   public float scrollSpeed = 0.01f;
   Material mymaterial;

   void Start()
    {
        mymaterial=GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        float newOffsetY=mymaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;        
        Vector2 newOffset=new Vector2(0f,newOffsetY);
        mymaterial.mainTextureOffset=newOffset;
    }
}
