
public abstract class Destroys : NCKHMonoBehaviour
{

    public void Update()
    {
        this.Destroying();
    }
    public virtual void Destroying()
    {
        if (!CanDestroy()) return;
        this.destroyObject();

    }
    public virtual void destroyObject()
    {
        Destroy(transform.gameObject);
    }
    public abstract bool CanDestroy();

}
