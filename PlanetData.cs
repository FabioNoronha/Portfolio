using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetData
{
    public string gravity;
    public string temperature;
    public bool plants;
    public bool animals;
    public string atmosphere;
    public bool water;
    public string rings;
    public bool habitable;

    public PlanetData(string gravity, string temperature, bool plants, bool animals, string atmosphere, bool water, string rings, bool habitable)
    {
        this.gravity = gravity;
        this.temperature = temperature;
        this.plants = plants;
        this.animals = animals;
        this.atmosphere = atmosphere;
        this.water = water;
        this.rings = rings;
        this.habitable = habitable;
    }
}
