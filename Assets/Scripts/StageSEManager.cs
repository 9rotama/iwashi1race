using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KanKikuchi.AudioManager;
using System;

/// <summary>
/// このゲームのレース中のSE用の音声再生を管理する
/// </summary>
public class StageSEManager : MonoBehaviour
{
    const float XViewRange = 0.5f;
    const float cpuVolumeRate = 0.4f;
    
    /// <summary>
    /// レーサーの座標、タグなど基づいてSEを再生する。
    /// </summary>
    public static void Play(Racer racer, string audioPath, float baseVolumeRate = 1, float delay = 0, float pitch = 1, bool isLoop = false, Action callback = null)
    {   
        var viewX = Camera.main.WorldToViewportPoint(racer.transform.position).x;
        var volumeTagRate = racer.CompareTag("CPU") ? cpuVolumeRate : 1;
        var volumeRangeRate = 1f;
        
        // 画面内にいるとき
        if(0 <= viewX && viewX <= 1){
            
        }
        // 画面外で画面の1+XViewRange倍の範囲にいるとき
        else if(-XViewRange <= viewX && viewX <= 1+XViewRange) {
            volumeRangeRate = 1 - ((Mathf.Abs(viewX) % 1f) / XViewRange); 
        }
        // 画面の1.5倍の範囲外のとき
        else {
            return;
        }

        var volumeRate = baseVolumeRate * volumeRangeRate * volumeTagRate;
        SEManager.Instance.Play(audioPath, volumeRate, delay, pitch, isLoop, callback);
    }
}

