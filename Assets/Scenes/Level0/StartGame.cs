using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private FloatSO scoreSO;
    [SerializeField] private PlayerSO _playerSo;

    public Sprite[] sprites;
    private int _spriteIndex = 0;

    public RectTransform LesPaulDisabled;
    public RectTransform FlyingVDisabled;
    public RectTransform EVHDisabled;

    public Button[] buttons;

    private Dictionary<String, int> _playerSkins = new Dictionary<string, int>
    {
        {"Sg", 0},
        {"Les Paul", 1},
        {"FlyingV", 2},
        {"EVH", 3}
    };

    // Start is called before the first frame update
    void Start()
    {
        _playerSo.Health = 3;

        UIManager.instance.scoreValue.text = scoreSO.Value + "";

        if (scoreSO.Value >= 2000) {
            LesPaulDisabled.gameObject.SetActive(false);
        }

        if (scoreSO.Value >= 4000) {
            FlyingVDisabled.gameObject.SetActive(false);
        }



        if (_playerSo.Complete) {
            EVHDisabled.gameObject.SetActive(false);
        }

        buttons[_playerSkins[_playerSo.Sprite.name]].interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSkin(int index)
    {
        buttons[_spriteIndex].interactable = true;
        _spriteIndex = index >= sprites.Length ? 0 : index;
        _playerSo.Sprite = sprites[_spriteIndex];
        buttons[_spriteIndex].interactable = false;
    }

    public void onClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
