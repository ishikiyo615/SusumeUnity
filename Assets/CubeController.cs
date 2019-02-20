using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    private AudioSource sound;

    // Use this for initialization
    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cube" || collision.gameObject.tag == "Ground")
        {
            // 音を鳴らす
            sound.PlayOneShot(sound.clip);
        }
    }
}