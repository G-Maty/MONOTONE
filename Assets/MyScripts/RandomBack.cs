using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBack : MonoBehaviour
{
    [SerializeField]
    private GameObject backObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 30�t���[�����ɃV�[���Ƀv���n�u�𐶐�
        if (Time.frameCount % 120 == 0)
        {
            // �v���n�u�̈ʒu�������_���Őݒ�
            float x = Random.Range(-9f, 9f);
            Vector3 pos = new Vector3(x, 7f, 0);

            // �v���n�u�𐶐�
            Instantiate(backObj, pos, Quaternion.identity);
        }
    }
}
