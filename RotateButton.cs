using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateButton : MonoBehaviour
{
    public Vector3 minRotationSpeed = new Vector3(0f, 0f, 1400f); // �ŏ���]���x
    public Vector3 maxRotationSpeed = new Vector3(0f, 0f, 1700f); // �ő��]���x
    public float minDecelerationRate = 0.996f; // �ŏ�������
    public float maxDecelerationRate = 0.999f; // �ő匸����
    public float minRotationSpeedThreshold = 5f; // ��]���~���邽�߂̍ŏ����x
    private Vector3 rotationSpeed; // ���݂̉�]���x���i�[����ϐ�
    private float decelerationRate; // ���݂̌��������i�[����ϐ�
    private bool isRotating = false; // ��]�����ǂ����̃t���O

    void Start()
    {
        rotationSpeed = Vector3.zero; // ������Ԃł͉�]���x���[���ɐݒ�
    }

    void Update()
    {
        if (isRotating)
        {
            // �I�u�W�F�N�g����]������
            transform.Rotate(rotationSpeed * Time.deltaTime);

            // ���X�ɉ�]���x������������
            rotationSpeed *= decelerationRate;

            // ��]���x�����l�ȉ��ɂȂ������~����
            if (rotationSpeed.magnitude < minRotationSpeedThreshold)
            {
                rotationSpeed = Vector3.zero; // ��]���~
                isRotating = false; // ��]�t���O������
            }
        }
    }

    // �X�^�[�g�{�^�����������Ƃ��ɌĂяo�����\�b�h
    public void StartRotation()
    {
        if (!isRotating)
        {
            // z���̏�����]���x�������_���ɐݒ�
            float randomZ = Random.Range(minRotationSpeed.z, maxRotationSpeed.z);
            rotationSpeed = new Vector3(0f, 0f, randomZ);

            // �������������_���ɐݒ�
            decelerationRate = Random.Range(minDecelerationRate, maxDecelerationRate);

            isRotating = true; // ��]�t���O���Z�b�g
        }
    }
}