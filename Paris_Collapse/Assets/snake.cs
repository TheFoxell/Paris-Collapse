using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class snake : MonoBehaviour
{
    public GameObject tempFruit, fruitPrefab, tailPrefab;
    public List<Transform> tail = new List<Transform>();
    public Vector2 direction;
    public Player player;

    void Start()
    {
        tempFruit = Instantiate(fruitPrefab, new Vector2(Random.Range(-215, 215),Random.Range(-140, 125)), Quaternion.identity);
        InvokeRepeating("Move",0,.001f);
    }

    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (vertical == 0 && horizontal != 0 || vertical != 0 && horizontal == 0)
            direction = new Vector2(horizontal, vertical);
    }

    void Move()
    {
        Vector2 lastPosition = transform.position;
        transform.Translate(direction);

        if (!tempFruit)
        {
            tempFruit = Instantiate(fruitPrefab, new Vector2(Random.Range(0, 1) + .5f,Random.Range(0, 1) + .5f), Quaternion.identity);
            GameObject t = Instantiate(tailPrefab, lastPosition, Quaternion.identity);
            tail.Insert(0,t.transform);
        }
        if (tail.Count > 0)
        {
            tail.Last().position = lastPosition;
            tail.Insert(0,tail.Last());
            tail.RemoveAt(tail.Count-1);
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject == tempFruit)
            Destroy(tempFruit);
        else
        {
            player.coin += tail.Count;
            SceneManager.LoadScene("Chargement");
        }
        
    }
    
}
