using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityStandardAssets._2D
{
    //basic code taken from https://youtu.be/gGUtoy4Knnw
    public class characterInteract : MonoBehaviour
    {
        public PlatformerCharacter2D character;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("interObject"))
            {
                if (other.name == "lowGrav")
                {
                    character.setGravityLow();
                }
                else if (other.name == "highGrav")
                {
                    character.setGravityHigh();
                }
                else if (other.name == "lowSpeed")
                {
                    character.setVelocityLow();
                }
                else if (other.name == "highSpeed")
                {
                    character.setVelocityHigh();
                }
            }
        }
    }
}
