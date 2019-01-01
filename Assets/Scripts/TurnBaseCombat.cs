using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBaseCombat : MonoBehaviour
{
	
	public enum BattleStates{
		START,
		RKTURN,
		SURATURN,
		LOSE,
		WIN
	}
	
	public BattleStates currentState;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
        currentState = BattleStates.START;
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(currentState);

        switch(currentState){
			
			case (BattleStates.START):
				break;
			case (BattleStates.RKTURN):
				break;
			case (BattleStates.SURATURN):
				break;
			case (BattleStates.LOSE):
				break;
			case (BattleStates.WIN):
				break;
		}
    }
	
	void OnGUI(){
		if (GUILayout.Button("NEXT STATE")){
			if (currentState == BattleStates.START){
				currentState = BattleStates.RKTURN;
			}else if (currentState == BattleStates.RKTURN){
				currentState = BattleStates.SURATURN;
			}else if (currentState == BattleStates.SURATURN){
				currentState = BattleStates.RKTURN;
			}
		}
		
		
		
	}
}
