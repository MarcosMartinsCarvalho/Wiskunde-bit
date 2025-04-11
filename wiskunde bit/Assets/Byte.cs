using UnityEngine;

public class Byte : MonoBehaviour
{
    [SerializeField] Bit[] bits = new Bit[8]; 
    [SerializeField] private int value = 0; 

    
    public void SetValue(int newValue)
    {
       
        if (newValue > 255)
        {
            newValue = 255;
        }

        this.value = newValue;

        
        for (int i = 0; i < 8; i++)
        {
            int bitValue = 1 << (7 - i); 

            if (newValue >= bitValue)
            {
                bits[i].state = true; 
                newValue -= bitValue;
            }
            else
            {
                bits[i].state = false; 
            }
        }
    }
}
