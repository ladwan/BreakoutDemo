using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float _speed = 12f;
    private float screenEdge = 7.8f;

	void Update () {

        Vector3 pos = transform.position;

        float delta = Input.GetAxis("Horizontal") * Time.deltaTime * _speed;

        pos.x += delta;

        if(pos.x < -screenEdge)
        {
            pos.x = -screenEdge;
        }

        if (pos.x > screenEdge)
        {
            pos.x = screenEdge;
        }
        transform.position = pos;
	}
}
