using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour

{
     [SerializeField] float destroyDelay = 0.1f;
     [SerializeField] Color32 hasPackageColor = new Color32 (18, 255, 0, 255);
     [SerializeField] Color32 hasNoPackageColor = new Color32 (255, 255, 255, 255);
     bool hasPackage;

     SpriteRenderer spriteRenderer;

     void Start() {
          spriteRenderer = GetComponent<SpriteRenderer>();     
     }
   void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Bump@!$!$!$@"); 
   }

   void OnTriggerEnter2D(Collider2D other) {

        if (!hasPackage && other.tag == "Package") {
          spriteRenderer.color = hasPackageColor;
          Destroy(other.gameObject, destroyDelay);
          Debug.Log("Package Collected!");
          hasPackage = true;
        } else if (hasPackage && other.tag == "Package") {
          Debug.Log("You already have one package!");
        }
        
        if (hasPackage && other.tag == "Customer") {
          spriteRenderer.color = hasNoPackageColor;
          Debug.Log("Package Delivered!");
          hasPackage = false;
        } else if (!hasPackage & other.tag == "Customer") {
          Debug.Log("You forgot the package!");
        }
   }
}
