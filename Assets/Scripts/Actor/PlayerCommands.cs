﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCommands : MonoBehaviour
{
    public UnityEvent m_playerCommand;
    public PlayerStats player;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<PlayerStats>();
        if (m_playerCommand == null)
            m_playerCommand = new UnityEvent();

        m_playerCommand.AddListener(Attack);
    }
    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("Attack")]
    public void Attack()
    {
        throw new NotImplementedException();
    }


}
