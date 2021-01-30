using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCommands : MonoBehaviour
{
    public UnityEvent m_playerCommand;
    public PlayerStats player;

    // Start is called before the first frame update
    private void Start()
    {
        player = gameObject.GetComponent<PlayerStats>();
        if (m_playerCommand == null)
            m_playerCommand = new UnityEvent();

        m_playerCommand.AddListener(Attack);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    [ContextMenu("Attack")]
    public void Attack()
    {
        throw new NotImplementedException();
    }
}