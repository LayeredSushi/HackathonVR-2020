using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorInformation
{
    public Material material;
    public Color color;
    public string name;

    public ColorInformation(Material material, Color color, string name) {
        this.material = material;
        this.color = color;
        this.name = name;
    }
}
