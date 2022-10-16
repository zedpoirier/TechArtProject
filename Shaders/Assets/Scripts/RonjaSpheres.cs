using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RonjaSpheres : MonoBehaviour
{
    public int sphereAmount = 20;
    public ComputeShader computeShader;
    public GameObject prefab;

    ComputeBuffer posBuffer;
    int kernelID;
    uint threadGroupSize;
    public Vector3[] output;

    Transform[] instances;

    private void Start()
    {
        kernelID = computeShader.FindKernel("Spheres");
        computeShader.GetKernelThreadGroupSizes(kernelID, out threadGroupSize, out _, out _); // _ value discards data

        posBuffer = new ComputeBuffer(sphereAmount, sizeof(float) * 3);
        output = new Vector3[sphereAmount];

        instances = new Transform[sphereAmount];
        for (int i = 0; i < sphereAmount; i++)
        {
            instances[i] = Instantiate(prefab, transform).transform;
        }
    }

    private void Update()
    {
        computeShader.SetBuffer(kernelID, "posBuffer", posBuffer);
        computeShader.SetFloat("Time", Time.time);
        int threadGroups = (int) ((sphereAmount + threadGroupSize - 1) / threadGroupSize);
        computeShader.Dispatch(kernelID, threadGroups, 1, 1);
        posBuffer.GetData(output);

        for (int i = 0; i < instances.Length; i++)
        {
            instances[i].localPosition = output[i];
        }
    }

    private void OnDestroy()
    {
        posBuffer.Dispose();
    }
}
