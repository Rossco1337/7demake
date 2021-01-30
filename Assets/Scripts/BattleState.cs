using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BattleState : MonoBehaviour
{
    [SerializeField]
    public enum State
    {
        Active,
        Wait,
        Turn,
        Win,
        Loss
    }

    //Active - Time flowing normally
    //Wait - Time stops moving, no timers increment
    //Turn - Time flowing normally but characters cannot act
    //Win - Battle is complete (yield to menu scene or draw new spoils UI?)
    //Loss - Battle failed, return to menu
    public static State currentState = State.Wait;
    public Text stateText;
    private readonly Tick battleTicks = new Tick();

    private IEnumerator ActivateBattle
    {
        get
        {
            //Begin battle flow
            currentState = State.Active;
            Debug.Log("Battle Activated");
            yield return new WaitForSeconds(1f);
        }
    }

    public void Awake()
    {
    }

    public void Start()
    {
        StartCoroutine(ActivateBattle);
    }

    public void Update()
    {
        switch (currentState)
        {
            case State.Active:
                battleTicks.StartTicking();
                //Debug.Log(GlobalTimer.BattleSpeed);
                break;
            case State.Win:
                Debug.Log("Win");
                break;
        }
    }
}