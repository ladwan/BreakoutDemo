using UnityEngine;

public class Ball : MonoBehaviour {

    public GameObject Tooltip;

    private float _horizontal = 8.65f;
    private float _veritcal = 4.8f;

    public Vector2 speed = new Vector2(4, -4);

    Rigidbody2D _rigid;

    bool _ballInPlay;

	void Start ()
    {

        _rigid = GetComponent<Rigidbody2D>();

	}
	
	void Update ()
    {
        if(_ballInPlay == false)
        {
            Tooltip.SetActive(true);
            gameObject.transform.position = new Vector2(GameObject.Find("Paddle").transform.position.x, -4);
        }

        if (Input.anyKeyDown && _ballInPlay == false)
        {
            Tooltip.SetActive(false);
            _ballInPlay = true;

        }
	}

// Move the Ball
    private void FixedUpdate()
    {

        if(_ballInPlay == true)
        {
            Vector3 delta = speed * Time.deltaTime;
            Vector3 UpdatedPos = transform.position + delta;

            if (UpdatedPos.x < -_horizontal)
            {
                UpdatedPos.x = -_horizontal;
                speed.x *= -1;
            }
            else if (UpdatedPos.x > _horizontal)
            {
                UpdatedPos.x = _horizontal;
                speed.x *= -1;
            }

            else if (UpdatedPos.y < -_veritcal)
            {
                UpdatedPos.y = -_veritcal;
                LifeLost();
            }
            else if (UpdatedPos.y > _veritcal)
            {
                UpdatedPos.y = _veritcal;
                speed.y *= -1;
            }

            _rigid.MovePosition(UpdatedPos);



        }

    }


// Takes a life away from player if ball goes below threshold;
    public void LifeLost()
    {
        if(_ballInPlay == true)
        {
            _ballInPlay = false;
            GameManager.Lives -= 1;
        }

    }


// OnCollision changes the balls direction, if ball collides with a brick destroy the brick + add score
    private void OnCollisionEnter2D(Collision2D collision)
    {
        speed.y *= -1;

        if (collision.gameObject.tag == "Brick")
        {
             GameManager.Score += collision.gameObject.GetComponent<BrickValue>().Value;

            Destroy(collision.gameObject);
        }
    }
}
