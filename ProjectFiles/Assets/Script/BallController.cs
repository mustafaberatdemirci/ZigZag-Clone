using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float ballAccelerate;
    [SerializeField] private float fallDealy = 3f;
    [SerializeField] private bool isDead = false;

    GameManager _manager;

    MenuManager _menuManager;
    //MenuManager refref=MenuManager._reference;

    Vector3 direction;
    public static bool ballDrop;
    public Spawner spawnerScript;
    public GameObject _particleSystem, textpre;

    public int clickScore = 0;
    //GameManager _clickscore;

    private void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        //_clickscore=GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = Vector3.zero;
        ballDrop = false;
    }

    void Update()
    {
        if (transform.position.y <= 0.5f)
        {
            ballDrop = true;
            isDead = true;
            _manager.gameover = true;
        }

        if (ballDrop == true)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            _menuManager.uiMenu.SetActive(false);
            _menuManager.rightframe.SetActive(false);
            //_menuManager.buttonEnabled = true;
            clickScore++;
            //_clickscore.cscore++;
            _manager.score++;
            if (direction.x == 0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
            speed = speed + ballAccelerate * Time.deltaTime;
        }

        //speed = speed + ballAccelerate * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * (Time.deltaTime * speed);
        transform.position += movement;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Diamond")
        {
            GameObject deactive = GameObject.FindGameObjectWithTag("Diamond");
            deactive.GetComponent<BoxCollider>().isTrigger = true;
            _manager.score = _manager.score + 2;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Path")
        {
            //_manager.score=_manager.score+2;
            collision.gameObject.AddComponent<Rigidbody>();
            spawnerScript.PathGeneration();
            StartCoroutine(PathRemove(collision.gameObject));
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        GameObject collectDiamond = GameObject.FindGameObjectWithTag("Diamond");
        if (collectDiamond)
        {
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
            //Instantiate(, transform.position, Quaternion.identity);
            _manager.CollectDiamond();
            Destroy(other.gameObject);
        }
    }

    IEnumerator PathRemove(GameObject pathremove) 
    {
        yield return new WaitForSeconds(fallDealy);
        Destroy(pathremove);
    }
}