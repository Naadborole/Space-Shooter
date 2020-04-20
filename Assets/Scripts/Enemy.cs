using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _enemySpeed = 4.0f;
    private Player _player;
    private UiManager manager;
    private Animator _ani;
    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        manager = GameObject.Find("Canvas").GetComponent<UiManager>();
        _ani = GetComponent<Animator>();
        _enemySpeed = _player._enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down *_enemySpeed* Time.deltaTime);
        if(transform.position.y < -3.9f)
        {
            transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 6, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
                _ani.SetTrigger("onEnemyDeath");
                _enemySpeed = 0;
                Destroy(this.gameObject, 2.38f);
            }            
        }
        else if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            if(_player != null)
            {
                _player.AddScore();
                manager.ScoreUpdate();
            }
            _ani.SetTrigger("onEnemyDeath");
            _enemySpeed = 0;
            Destroy(this.gameObject, 2.38f);
        }
    }
}
