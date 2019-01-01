using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RKControll : MonoBehaviour
{
	public float moveSpeed;
	private Animator anim;
	
	private bool RKMoving;
	private bool RKAttack;
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
        RKMoving = false;
		
		if (!RKAttack){
			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") <- 0.5f)
			{
					transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
					RKMoving = true;
					lastMoveX = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			}	
			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") <- 0.5f)
			{
					transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,0f));
					RKMoving = true;
					lastMoveY = new Vector2(0f,Input.GetAxisRaw("Vertical"));		
			}
		
			if (Input.GetKeyDown(KeyCode.C))
			{
					attackTimeCounter = attackTimeDuration;
					RKAttack = true;
					myRigidbody.velocity = Vector2.zero;
					anim.SetBool("RKAttack", true);
					RKTurn = false;
					
			}
		}
	
		if (attackTimeCounter > 0){
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0){
			RKAttack = false;
			anim.SetBool("RKAttack",false);
			
		}
		
		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetFloat("LastMoveX", lastMoveX.x);
		anim.SetFloat("LastMoveY", lastMoveY.y);
		anim.SetBool("RKMoving", RKMoving);
		
		
    }
}
