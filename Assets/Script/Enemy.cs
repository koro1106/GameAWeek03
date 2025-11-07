using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;// エネミースピード
    [SerializeField] private PlayerCtrl player;

    void Update()
    {
        if (!player.isDead && !player.isGoal)
        {
          transform.position -= Vector3.left * speed * Time.deltaTime;
        }
    }
}
