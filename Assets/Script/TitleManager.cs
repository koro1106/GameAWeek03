using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private float targetZ = -1f;
    [SerializeField] private float speed = 5f;

    [SerializeField] private GameObject title;
    [SerializeField] private GameObject space;

    private bool moveCamera = false;
    private Vector3 startPos; // 最初の位置
    void Start()
    {
        startPos =  transform.position;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            moveCamera = true;
            title.SetActive(true);
            space.SetActive(true);
        }
        if(moveCamera)
        {
            Vector3 currentPos = transform.position; // 現在位置取得

            //　Zだけ近づける
            float newZ = Mathf.Lerp(currentPos.z, targetZ, speed * Time.deltaTime);

            //　新しい位置セット
            transform.position = new Vector3(currentPos.x, currentPos.y, newZ);

            //目的地に付いたらシーン遷移
            if(Mathf.Abs(targetZ - currentPos.z) < 0.01f)
            {
                SceneManager.LoadScene("PlayScene");
                moveCamera = false;
            }
        }
    }
}
