using UnityEngine;

public class Arm : MonoBehaviour
{
    bool isRoot;
    float seed;
    Quaternion targetRot;

    public float degrees = 60.0f;
    public float timer;
    public float timeLimit = 2.0f;
    public bool rotX;
    public bool rotY;
    public bool rotZ = true;

    private void Start()
    {
        seed = Random.Range(-0.5f, 0.5f);
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        timer += Time.deltaTime;
        if (timer > timeLimit + seed)
        {
            timer = 0.0f;
            float x = Random.Range(-degrees, degrees) * System.Convert.ToSingle(rotX);
            float y = Random.Range(-degrees, degrees) * System.Convert.ToSingle(rotY);
            float z = Random.Range(-degrees, degrees) * System.Convert.ToSingle(rotZ);
            Vector3 targetRots = new Vector3(x, y, z);
            targetRot = Quaternion.Euler(targetRots);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, timer / (timeLimit + seed));
    }
}

public enum axis
{
    x, y, z
}
