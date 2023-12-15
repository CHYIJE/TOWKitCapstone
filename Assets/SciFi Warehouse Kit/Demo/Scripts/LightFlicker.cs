﻿ using UnityEngine;
 using System.Collections;
 
 public class LightFlicker : MonoBehaviour
 {
     public float maximumDim;
     public float maximumBoost;
     public float speed;
     public float strength;

     private bool noFlicker;
     private Light source;
     private float initialIntensity;
 
     public void Reset()
     {
         maximumDim = 0.2f;
         maximumBoost = 0.2f;
         speed = 0.1f;
         strength = 250;
     }
 
     public void Start()
     {
         source = GetComponent<Light>();
         initialIntensity = source.intensity;
         StartCoroutine(Flicker());
     }
 
 
     private IEnumerator Flicker()
     {
         while (!noFlicker)
        {
            // source.intensity를 변경하지 않고 initialIntensity로 유지
            yield return new WaitForSeconds(speed);
        }
     }
 }



