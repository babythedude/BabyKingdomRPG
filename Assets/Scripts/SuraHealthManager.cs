using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuraHealthManager : MonoBehaviour
{
	
	public int MaxHP;
	public int CurHP;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        CurHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurHP <= 0){
			//dead
		}
    }
	
	public void GetHit(int damage){
		
		CurHP -= damage;
	}
}
