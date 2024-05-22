using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SC_CountdownTimer : MonoBehaviour
{
    public enum CountdownFormatting { DaysHoursMinutesSeconds, HoursMinutesSeconds, MinutesSeconds, Seconds };
    public CountdownFormatting countdownFormatting = CountdownFormatting.MinutesSeconds; //Controla a forma como a string do temporizador será formatada
    public bool showMilliseconds = true; //Se deve mostrar milissegundos na formatação de contagem regressiva
    public double countdownTime = 90; //Deixa o contador em segundos
    Text countdownText;
    double countdownInternal;
    bool countdownOver = false;

    // Start is called before the first frame update
    void Start()
    {
        countdownText = GetComponent<Text>();
        countdownInternal = countdownTime; //Inicia o Contador no começo da cena
    }

    void FixedUpdate()
    {
        if (countdownInternal > 0)
        {
            countdownInternal -= Time.deltaTime;

            //Deixa o contador fixado em 0 para que ele não fique negativo
            if (countdownInternal < 0)
            {
                countdownInternal = 0;
            }

            countdownText.text = FormatTime(countdownInternal, countdownFormatting, showMilliseconds);
        }
        else
        {
            //aqui faz com que quando o contador chegue a 0 a tela troque para a tela de Game Over
            if (!countdownOver)
            {
                countdownOver = true;

                SceneManager.LoadScene("GameOver");

                Debug.Log("Countdown has finished running...");

            }
        }
    }

    //essa parte faz com que o contador apareça da seguinte maneira Horas:Minutor:segundos:milésimos
    string FormatTime(double time, CountdownFormatting formatting, bool includeMilliseconds)
    {
        string timeText = "";

        int intTime = (int)time;
        int days = intTime / 86400;
        int hoursTotal = intTime / 3600;
        int hoursFormatted = hoursTotal % 24;
        int minutesTotal = intTime / 60;
        int minutesFormatted = minutesTotal % 60;
        int secondsTotal = intTime;
        int secondsFormatted = intTime % 60;
        int milliseconds = (int)(time * 100);
        milliseconds = milliseconds % 100;

        if (includeMilliseconds)
        {
            if (formatting == CountdownFormatting.DaysHoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}:{4:00}", days, hoursFormatted, minutesFormatted, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.HoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", hoursTotal, minutesFormatted, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.MinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}", minutesTotal, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.Seconds)
            {
                timeText = string.Format("{0:00}:{1:00}", secondsTotal, milliseconds);
            }
        }
        else
        {
            if (formatting == CountdownFormatting.DaysHoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hoursFormatted, minutesFormatted, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.HoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}", hoursTotal, minutesFormatted, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.MinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}", minutesTotal, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.Seconds)
            {
                timeText = string.Format("{0:00}", secondsTotal);
            }
        }

        return timeText;
    }
}