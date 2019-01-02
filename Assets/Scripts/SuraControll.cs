using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraControll : MonoBehaviour
{
	
	// Movement Section
	public float moveSpeed;
	private Animator anim;
	
	private bool SuraMoving;
	private bool SuraAttack;
	private Vector2 lastMoveX;
	private Vector2 lastMoveY;
	
	private Rigidbody2D myRigidbody;
	
	public float attackTimeDuration;
	private float attackTimeCounter;
	
	// attack effect
	public GameObject db_0;
	public Animator db_animator;
	public Transform db_transform;
	
	// evil emoji effect
	public GameObject evil_emoji_0;
	public Animator evil_emoji_animator;
	
	// CombatSection
	public GameObject camera;
	public TurnBaseCombat combat;
	private bool SuraTurn;
	
	// RK character
	public GameObject opponent;
	public RKControll RK;
	
	private int MaxHP;
	private int CurHP;
	

    // Start is called before the first frame update
    void Start()
    {
		MaxHP = 5000;
		CurHP = MaxHP;
		combat = camera.GetComponent<TurnBaseCombat>();
		SuraTurn = false;
		
        anim = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
		db_animator = db_0.GetComponent<Animator>();
		db_transform = db_0.GetComponent<Transform>();
		evil_emoji_animator = evil_emoji_0.GetComponent<Animator>();
		
		
		RK = opponent.GetComponent<RKControll>();
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(CurHP);
	
		SuraMoving = false;
		
		// Check if it is sura turn
		if (combat.currentState == TurnBaseCombat.BattleStates.SURATURN){
			SuraTurn = true;
		}else{
			SuraTurn = false;
		}
		
		// only allow attack or movement when it is its turn
		if (!SuraAttack && SuraTurn){
			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") <- 0.5f)
			{
					Debug.Log("horiztonal pressed");
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
				

				// land the attack effect where RK currently is
				db_transform.position = RK.GetComponent<Transform>().position;
				db_animator.Play("db");
				evil_emoji_animator.Play("evil_emoji");
				RK.Attack(true);
				
			
			}
		}
		if (attackTimeCounter > 0){
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0){
			SuraAttack = false;
			anim.SetBool("SuraAttack",false);
			db_animator.Play("db_empty");
			evil_emoji_animator.Play("evil_emoji_empty");
			RK.Attack(false);
		}
		
		// you don't want it to automatically turn when you are walking
		if (!SuraTurn){
			UpdateFacingDirection();
		}

		anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
		anim.SetBool("SuraMoving", SuraMoving);
		anim.SetFloat("LastMoveX", lastMoveX.x);
		anim.SetFloat("LastMoveY", lastMoveY.y);
		
		
        
    }
	
	public void Attack(bool begin){
	// call when opportent hit sura, do the animation and calculation

		if (begin){
			
			CurHP -= 1000;
			anim.SetBool("SuraOnHit", true);
		}else{
			anim.SetBool("SuraOnHit", false);
			
			if (CurHP <= 0){
				anim.SetBool("Dead", true);
			}
		}
	}
	
	// update facing direction according to opponent's movement
	void UpdateFacingDirection(){
		
		Vector3 RK_current_position = RK.GetComponent<Transform>().position;
		
		lastMoveX = RK_current_position;
		lastMoveY = RK_current_position;
		
		
	}
}
