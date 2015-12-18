using UnityEngine;
using System.Collections;

public class MyRigid2D {
    public parameter parameter;
    public Vector2 Accell = new Vector2();
    public Vector2 Velocity = new Vector2();
    public Vector2 Position = new Vector2();
    public float myMass = 1;

    // Use this for initialization
    public void Start () {
	    
	}
    public void Update()
    {
        this.Velocity += this.Accell ;
        this.Position += this.Velocity;
    }

    public void AddForce(Vector2 vec2)
    {
        this.Velocity += vec2/parameter.Mass/myMass ;   
    }

    public void CalcGravity()
    {
        this.Velocity += new Vector2(0, -parameter.gravity);
    }

}
