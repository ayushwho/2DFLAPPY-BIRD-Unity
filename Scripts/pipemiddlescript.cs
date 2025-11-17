using UnityEngine;

public class pipemiddlescript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public logicscript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicscript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.layer == 3){
            logic.addscore(1);
        }
        
    }
}
