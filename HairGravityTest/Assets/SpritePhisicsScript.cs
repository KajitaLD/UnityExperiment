using UnityEngine;
using System.Collections;

public class SpritePhisicsScript : MonoBehaviour
{

    public SpritePhisicsScript parent;
    public SpritePhisicsScript child;
    public MyRigid2D myrigid = new MyRigid2D();
    public float m_initLengthToParent;
    public float m_currentLengthToParent;

    public parameter parameter;

    // Use this for initialization
    void Start()
    {
        this.myrigid.Position = new Vector2(this.transform.position.x, this.transform.position.y);
        this.myrigid.parameter = parameter;
        if (this.parent != null)
        {
            this.m_initLengthToParent = this.LengthToParent();
            this.m_currentLengthToParent = this.LengthToParent();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (this.parent != null)
        {
            this.transform.position = new Vector3(this.myrigid.Position.x, this.myrigid.Position.y, 0);

        }
        this.myrigid.Position = new Vector2(this.transform.position.x, this.transform.position.y);
        calc();
        this.myrigid.Update();
    }

    float LengthToParent()
    {

        return (this.transform.position - this.parent.transform.position).magnitude;
    }

    void calc()
    {

        if (this.parent != null)
        {
            this.m_currentLengthToParent = this.LengthToParent();

            myrigid.AddForce((this.parent.myrigid.Position - this.myrigid.Position).normalized * this.parameter.K * (this.m_currentLengthToParent - this.m_initLengthToParent) - this.myrigid.Velocity * this.parameter.Fliction);
        }
    }
}
