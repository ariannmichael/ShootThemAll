using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerSO : ScriptableObject
{
    [SerializeField]
    private Sprite _sprite;

    public Sprite Sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
    }
}
