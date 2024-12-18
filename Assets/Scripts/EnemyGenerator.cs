﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    #region generate
    [Header("敵の生成リスト")] [SerializeField] GameObject[] enemies;
    [Header("敵生成の時間")] [SerializeField] float genDelay = 2f;
    [Header("敵生成の間隔")] [SerializeField] float genInterval = 2f;
    [Header("画面の余白（x軸方向）")] [SerializeField] float marginX = 1f;
    [Header("画面の余白（y軸方向）")] [SerializeField] float marginY = 1f;
    Vector2 min, max;       // 画面サイズ取得用
    #endregion

    void Start()
    {
        // 画面サイズの最小値・最大値を取得
        min = Camera.main.ViewportToWorldPoint(Vector2.zero);
        max = Camera.main.ViewportToWorldPoint(Vector2.one);
        // 敵生成の関数を一定間隔でリピート
        //InvokeRepeating("EnemyGenarate", (float)(Random.Range(1, 3)), Random.Range(0.0f, 5.0f));
        InvokeRepeating("EnemyGenarate", genDelay, genInterval);
    }
    void EnemyGenarate()    // 敵を生成する
    {
        // 敵を生成
        Instantiate(enemies[Random.Range(0, enemies.Length)],                                           // GameObjectの配列enemiesからランダムで生成する敵を選択
                    new Vector2(Random.Range(min.x + marginX, max.x - marginX), transform.position.y),  // x座標：EnemyGeneratorオブジェクトのpositionのx,y座標：取得した画面サイズの最小値+余白から最大値-余白までの間
                    Quaternion.identity);                                                               // 回転しない
        //// 敵を生成
        //Instantiate(enemies[Random.Range(0, enemies.Length)],                                           // GameObjectの配列enemiesからランダムで生成する敵を選択
        //            new Vector2(transform.position.x, Random.Range(min.y + marginY, max.y - marginY)),  // x座標：EnemyGeneratorオブジェクトのpositionのx,y座標：取得した画面サイズの最小値+余白から最大値-余白までの間
        //            Quaternion.identity);                                                               // 回転しない
    }
}
