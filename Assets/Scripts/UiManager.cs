using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Text _score_text;
    private Player _player;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Sprite[] _sprites;
    [SerializeField]
    private Text _GameOverText;
    [SerializeField]
    private Text RtoR;
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        _score_text.text = "Score: " + 0;   
        _GameOverText.gameObject.SetActive(false);
        RtoR.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LivesUpdate(int Current_lives)
    {
        _LivesImg.sprite = _sprites[Current_lives];
        if(Current_lives == 0)
        {
            RtoR.gameObject.SetActive(true);
            _GameOverText.gameObject.SetActive(true);
            StartCoroutine(GameOverFlicker());
        }
    }
    public void ScoreUpdate()
    {
        _score_text.text = "Score: " + _player.GetScore();
    }
    IEnumerator GameOverFlicker()
    {
        while (true)
        {
            _GameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _GameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
