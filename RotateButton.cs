using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateButton: MonoBehaviour
{
    public Vector3 initialRotationSpeed = new Vector3(0f, 0f, 1500f); // ������]���x
    public float decelerationRate = 0.994f; // �������i1�����̒l�j
    public float minRotationSpeed = 5f; // ��]���~���邽�߂̍ŏ����x
    private Vector3 rotationSpeed; // ���݂̉�]���x���i�[����ϐ�
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
            if (rotationSpeed.magnitude < minRotationSpeed)
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
            rotationSpeed = initialRotationSpeed; // ������]���x��ݒ�
            isRotating = true; // ��]�t���O���Z�b�g
        }
    }
}