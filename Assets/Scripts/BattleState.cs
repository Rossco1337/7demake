using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleState : MonoBehaviour {
    public Text stateText;
    public enum State { Active, Wait, Turn, Win, Loss }
    //Active - Time flowing normally
    //Wait - Time stops moving, no timers increment
    //Turn - Time flowing normally but characters cannot act
    //Win - Battle is complete (yield to menu scene or draw new spoils UI?)
    //Loss - Battle failed, return to menu
    public static State currentState = State.Wait;
    private readonly Tick battleTicks = new Tick ();

    public void Awake () {

    }

    public void Start () {
        StartCoroutine (ActivateBattle);
    }
    public void Update () {
        switch (currentState) {
            case State.Active:
                battleTicks.StartTicking ();
                //Debug.Log(GlobalTimer.BattleSpeed);
                break;
            case State.Win:
                Debug.Log ("Win");
                break;
        }

    }

    IEnumerator ActivateBattle {
        get {
            //Begin battle flow
            currentState = State.Active;
            Debug.Log ("Battle Activated");
            yield return new WaitForSeconds (1f);
        }

    }

}