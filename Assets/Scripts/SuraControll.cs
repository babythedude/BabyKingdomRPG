using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraControll : MonoBehaviour
{
	
	public float moveSpeed;
	private Animator anim;
	
	private bool SuraMoving;
	private bool SuraAttack;
	private Vector2 lastMoveX;
	private Vector2 lastMoveY;
	
	private Rigidbody2D myRigidbody;
	
	public float attackTimeDuration;
	private float attackTimeCounter;
	
	
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		
		SuraMoving = false;
		if (!SuraAttack){
			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") <- 0.5f)
			{
					transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
					SuraMoving = true;
					lastMoveX = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			}	
			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") <- 0.5f)
			{
					transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,0f));
					SuraMoving = true;
					lastMoveY = new Vector2(0f,Input.GetAxisRaw("Vertical"));
			}
			
			if (Input.GetKeyDown(KeyCode.X))
			{
				attackTimeCounter = attackTimeDuration;
				SuraAttack = true;
				myRigidbody.velocity = Vector2.zero;
				anim.SetBool("SuraAttack", true);
					
			
			}
		}
		if (attackTimeCounter > 0){
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0){
			SuraAttack = false;
			anim.SetBool("SuraAttack",false);
		}
		
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("SuraMoving", SuraMoving);
		anim.SetFloat("LastMoveX", lastMoveX.x);
		anim.SetFloat("LastMoveY", lastMoveY.y);
		
        
    }
}
