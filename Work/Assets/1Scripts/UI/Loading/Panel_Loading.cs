using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Panel_Loading : MonoBehaviour
{
    // Random Change Balloon
    [SerializeField] GameObject _gbjBalloon = null;
    [SerializeField] Image      _imgBalloon = null;
   
    [SerializeField] Sprite[] _spriteBalloons;

    // Change Animal
    [SerializeField] GameObject _gbjAnimal = null;
    [SerializeField] Image      _imgAnimal = null;

    [SerializeField] Sprite[] _spriteAnimals;

    int _animalNum = 0;

    //
    void OnEnable()
    {
        ChangeCharacter();

        _animalNum++;

        if (_animalNum == _spriteAnimals.Length)
            _animalNum = 0;
    }

    //
    void Start()
    {
        _imgBalloon = _gbjBalloon.GetComponent<Image>();
        _imgAnimal  = _gbjAnimal .GetComponent<Image>();
    }

    //
    void ChangeCharacter()
    {
        // Change Random Balloon 
        int balloonIdx = Random.Range(0, _spriteBalloons.Length);

        _imgBalloon.sprite = _spriteBalloons[balloonIdx];

        // Change Animal
        _imgAnimal.sprite = _spriteAnimals[_animalNum];
    }
}

/*
 활성화 될 때마다 차례대로 보여주기
리스트에서 
 */
