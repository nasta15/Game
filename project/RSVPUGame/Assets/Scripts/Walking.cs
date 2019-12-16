using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    
    Rigidbody2D rigidbody; //создаем переменную для перемещения объекта
    private Animator animator;//анимация
    public float maxSpeed = 10f;//максимальная скорость персонажа
    private bool direction = true;//определение направление персонажа

    public float minY;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); //в переменную определяем компонент Rigidbody2D
        animator = GetComponent<Animator>();   
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");//-1 при нажатии влево, 1 при нажатии в право
        float moveY = Input.GetAxis("Vertical");//-1 при нажатии влево, 1 при нажатии в право
        animator.SetFloat("Speed", Mathf.Abs(moveX));//изменяем значение параметра speed на значение оси Х
        rigidbody.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);//задаем скорость по оси Х, равную значению оси Х умноженное на значение макс. скорости

        if (moveX > 0 && !direction) Turn();//если нажали вправо, а персонаж повернут влево, отразить персонажа
        else if (moveX < 0 && direction) Turn();//обратная ситуация

        //transform.localScale = transform.localScale * Mathf.Abs((transform.position.y - minY));
    }

    private void Turn()//поворот песонажа
    {
        direction = !direction;//меняем направление движения персонажа
        Vector3 theScale = transform.localScale;//размеры персонажа
        theScale.x *= -1;//зеркально их отражаем по оси Х
        transform.localScale = theScale;
    }
}
