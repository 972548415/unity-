using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * �Ժ�ű���������һ������������ʹ���շ�������
 */
public class SphereManager : MonoBehaviour
{
    /*
     * ������Ҳ����ʹ���շ�������
     */
    public GameObject spherePrefab;
    public int gridSize = 5;
    public float spacing = 2.0f;

    void Start()
    {
        for (int x = 0; x < gridSize; x++)
        {
            for (int z = 0; z < gridSize; z++)
            {
                Vector3 position = new Vector3(x * spacing, 0, z * spacing);
                /*
                 * ������һ��������ʱ����
                 * �ڳ�ʼ���߼��У�Ӧ��ӱ����������Դ�ļ�Ϊ�գ���ʱ����������־
                 */
                GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
                sphere.name = "Sphere_" + x + "_" + z;
            }
        }
    }

    /*
     * ����IEnumeratorû�������������Խ��Unity�ĵ��ʹ�ģ�ͼ����о���
     */
    private IEnumerator MoveSphereRandomly(GameObject sphere)
    {
        while (true)
        {
            Vector3 newPosition = sphere.transform.position;
            newPosition.x = Random.Range(-5f, 5f);
            newPosition.z = Random.Range(-5f, 5f);
            sphere.transform.position = newPosition;
            /*
             * ʱ������Ϊ�������Գ�����������н�������
             */
            yield return new WaitForSeconds(1f);
        }
    }

    private IEnumerator LogSpherePosition(GameObject sphere)
    {
        while (true)
        {
            Debug.Log(sphere.name + " Position: " + sphere.transform.position);
            /*
            * ʱ������Ϊ�������Գ�����������н�������
            */
            yield return new WaitForSeconds(0.5f);
        }
    }

    void Update()
    {
        
    }
}
