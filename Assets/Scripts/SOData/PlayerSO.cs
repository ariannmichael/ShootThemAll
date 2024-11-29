using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSO : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;

    [SerializeField]
    private int _health;

    [SerializeField]
    private bool _complete;

    public Sprite Sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
    }

    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public bool Complete
    {
        get { return _complete; }
        set { _complete = value; }
    }
}
