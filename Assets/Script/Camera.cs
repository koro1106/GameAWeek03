using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform player; // プレイヤー
    [SerializeField] private float speed = 5f;
    [SerializeField] private float offsetY = 5f; // 固定Y
    [SerializeField] private Vector3 offset = new Vector3(0, 5, -10); // プレイヤーとの距離

    //カメラ限界値
    public float minX = 5f;
    public float maxX = -85f;

    void LateUpdate()
    {
        // 追従したい位置計算
        Vector3 targetPos = player.position + offset;

        // Y座標固定
        targetPos.y = offsetY;

        //X座標を範囲内に制限
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);

        // 追従
        transform.position =Vector3.Lerp(transform.position, targetPos,speed * Time.deltaTime);
    }

}
