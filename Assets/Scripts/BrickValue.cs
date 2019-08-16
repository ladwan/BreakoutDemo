using UnityEngine;

public class BrickValue : MonoBehaviour {

    [SerializeField] public int Value;
    GameObject _brick;


 // The higher the "Y" axis value, the more the brick's value.
    void Start ()
    {
        _brick = gameObject;

        if (_brick.transform.position.y == 1)
        {
            Value = 1;
        }
        if (_brick.transform.position.y == 2)
        {
            Value = 2;
        }
        else if (_brick.transform.position.y == 3)
        {
            Value = 3;
        }
        else if (_brick.transform.position.y == 4)
        {
            Value = 5;
        }
    }
	
}
