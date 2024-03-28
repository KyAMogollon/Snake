using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public Vector2 direcction=Vector2.zero;
    public float speed;
    private List<Transform> _segments = new List<Transform>();
    public Transform segmentPrefab;
    public int initialSize = 4;
    public ScoreManager scoreManager;
    public AudioClip audioComer;
    // Start is called before the first frame update
    void Start()
    {
        _segments.Add(transform);
        for (int i = 1;i< initialSize; i++)
        {
            _segments.Add(Instantiate(segmentPrefab));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W) && direcction != Vector2.down)
        {
            direcction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && direcction != Vector2.up)
        {
            direcction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && direcction != Vector2.left)
        {
            direcction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && direcction != Vector2.right)
        {
            direcction = Vector2.left;
        }
    }
    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
    }
    private void FixedUpdate()
    {
        for(int i =_segments.Count - 1; i > 0; i--) 
        {
            _segments[i].position = _segments[i - 1].position;
        }
        transform.position = new Vector2(
            Mathf.Round(transform.position.x) + speed * direcction.x, 
            Mathf.Round(transform.position.y) + speed * direcction.y
            );
    }
    public void ResetState()
    {
        for(int i=1;i<_segments.Count;i++)
        {
            Destroy(_segments[i].gameObject);
        }
        _segments.Clear();
        _segments.Add(transform);
        for (int i = 1; i < initialSize; i++)
        {
            _segments.Add(Instantiate(segmentPrefab));
        }
        transform.position = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            scoreManager.UpdateScore(1);
            Grow();
            AudioManager.Instance.PlayAudio(audioComer);
            GameManager.Instance.GenerarComida();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Wall")
        {
            ResetState();
            scoreManager.ResetActualScore();
        }
    }
}
