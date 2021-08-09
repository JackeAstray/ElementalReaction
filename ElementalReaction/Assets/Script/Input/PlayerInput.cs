using Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class PlayerInput : SingleToneManager<PlayerInput>
    {
        [Header("数值")]
        public float moveSpeed;         //移动速度
        //public float rotateSpeed;       //旋转速度
        //public float burstSpeed;        //移动速度
        private Vector2 m_Rotation;

        private InputConfig m_Controls;

        public void Awake()
        {
            m_Controls = new InputConfig();
            InitInput();
        }

        public void OnEnable()
        {
            m_Controls.Enable();
        }

        public void OnDisable()
        {
            m_Controls.Disable();
        }

        public void Update()
        {
            var move = m_Controls.Player.Move.ReadValue<Vector2>();

            Move(move);
        }

        private void Move(Vector2 direction)
        {
            if (direction.sqrMagnitude < 0.01)
                return;

            if(direction.x > 0 && direction.y == 0)
            {
                Debug.Log("右");
            }
            else if (direction.x == 0 && direction.y > 0)
            {
                Debug.Log("上");
            }
            else if (direction.x < 0 && direction.y == 0)
            {
                Debug.Log("左");
            }
            else if (direction.x == 0 && direction.y < 0)
            {
                Debug.Log("下");
            }
            else if (direction.x > 0 && direction.y > 0)
            {
                Debug.Log("右上");
            }
            else if (direction.x > 0 && direction.y < 0)
            {
                Debug.Log("右下");
            }
            else if (direction.x < 0 && direction.y > 0)
            {
                Debug.Log("左上");
            }
            else if (direction.x < 0 && direction.y < 0)
            {
                Debug.Log("左下");
            }

            var scaledMoveSpeed = moveSpeed * Time.deltaTime;
            var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, direction.y, 0);
            transform.position += move * scaledMoveSpeed;
        }

        private void Skill(Vector2 direction)
        {
            if (direction.sqrMagnitude < 0.01)
                return;
            var scaledMoveSpeed = moveSpeed * Time.deltaTime;
            var move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, direction.y, 0);
            transform.position += move * scaledMoveSpeed;
        }

        private void InitInput()
        {
            //普通攻击----------------------------
            m_Controls.Player.NormalAttack.performed += ctx =>
            {
                //执行
                Debug.Log("NormalAttack performed");
            };

            m_Controls.Player.NormalAttack.started += ctx =>
            {
                //按下
                //Debug.Log("NormalAttack started");
            };

            m_Controls.Player.NormalAttack.canceled += ctx =>
            {
                //抬起
                //Debug.Log("NormalAttack canceled");
            };
            //------------------------------------

            //元素战技----------------------------
            m_Controls.Player.ElementalWarfare.performed += ctx =>
            {
                //执行
                Debug.Log("ElementalWarfare performed");
            };

            m_Controls.Player.ElementalWarfare.started += ctx =>
            {
                //按下
                //Debug.Log("ElementalWarfare started");
            };

            m_Controls.Player.ElementalWarfare.canceled += ctx =>
            {
                //抬起
                //Debug.Log("ElementalWarfare canceled");
            };
            //------------------------------------

            //元素爆发----------------------------
            m_Controls.Player.ElementalExplosion.performed += ctx =>
            {
                //执行
                Debug.Log("ElementalExplosion performed");
            };

            m_Controls.Player.ElementalExplosion.started += ctx =>
            {
                //按下
                //Debug.Log("ElementalExplosion started");
            };

            m_Controls.Player.ElementalExplosion.canceled += ctx =>
            {
                //抬起
                //Debug.Log("ElementalExplosion canceled");
            };
            //------------------------------------

            //加速-------------------------------
            m_Controls.Player.Accelerate.performed += ctx =>
            {
                //执行
                Debug.Log("Accelerate performed");
            };

            m_Controls.Player.Accelerate.started += ctx =>
            {
                //按下
                //Debug.Log("Accelerate started");
            };

            m_Controls.Player.Accelerate.canceled += ctx =>
            {
                //抬起
                //Debug.Log("Accelerate canceled");
            };
            //------------------------------------

            //跳跃-------------------------------
            m_Controls.Player.Jump.performed += ctx =>
            {
                //执行
                Debug.Log("Jump performed");
            };

            m_Controls.Player.Jump.started += ctx =>
            {
                //按下
                //Debug.Log("Jump started");
            };

            m_Controls.Player.Jump.canceled += ctx =>
            {
                //抬起
                //Debug.Log("Jump canceled");
            };
            //------------------------------------
        }
    }
}