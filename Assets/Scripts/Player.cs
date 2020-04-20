using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float speed = 1.0f;
    public GameObject laserPrefab;
    [SerializeField]
    private float _fireRate = 0.1f;
    private float _nextFire = 0.0f;
    [SerializeField]
    private int _lives = 3;
    [SerializeField]
    private int _score = 0;
    private UiManager m;
    private gameManager g;
    [SerializeField]
    private GameObject _rightFire;
    [SerializeField]
    private GameObject _leftFire;
    public float _enemySpeed = 4.0f;
        void Start()
    {
        m = GameObject.Find("Canvas").GetComponent<UiManager>();
        transform.position = new Vector3(0, 0, 0);
        g = GameObject.Find("Game_Manager").GetComponent<gameManager>();
        _rightFire.SetActive(false);
        _leftFire.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        fire();
    }

    void playerMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * HorizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, (float)-3.6, 0), 0);
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            if (transform.position.x < -10)
            {
                transform.position = new Vector3(10, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(-10, transform.position.y, transform.position.z);
            }
        }
    }

    void fire()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
        playerMovement();
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(laserPrefab, pos, Quaternion.identity);
        }
    }
    public void Damage()
    {
        _lives--;
        if(_lives == 2)
        {
            _rightFire.SetActive(true);
        }
        else if(_lives == 1)
        {
            _leftFire.SetActive(true);
        }

        m.LivesUpdate(_lives);
        if(_lives == 0)
        {
            SpawnManager temp = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            if(temp != null)
            { 
                temp.stop_spawning();
            }
            g.GameOver();
            Destroy(this.gameObject);
        }
    }
    public void AddScore()
    {
        _score += 10;
        if(_score%50 == 0)
        {
            _enemySpeed += 0.3f;
        }
    } 

    public int GetScore()
    {
        return _score;
    }
}
