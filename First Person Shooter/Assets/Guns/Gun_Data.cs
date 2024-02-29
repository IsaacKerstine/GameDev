using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Gun_Data", menuName = "Gun Data")]
public class Gun_Data : ScriptableObject
{
    public float range = 1000f;
    public int ammo_per_clip = 12;
    public bool automatic = false;
    public float primary_fire_delay = 0.5f;
    [Range(0f, 90f)] public float spread = 0.0f;
}
