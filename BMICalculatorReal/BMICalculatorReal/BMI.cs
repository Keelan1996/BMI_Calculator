using System;
using System.Collections.Generic;
using System.Text;

//namespace BMICalculatorReal  // current solution - be careful of the namespace
namespace HealthUtilities
{
    class BMI  // constructer 
    {
        // add our methods for what we need 
        // need one method to calculate the bmi value based on 
        // height and weight

        public float CalculateBMIValue(float height, float weight)
        {
            float fBMI = 0;
            
            if(height > 0)
            {
                return weight / (height * height);
            }
            return fBMI; 
        }
    }

    public class BodyFatCalculator
    { 
        public float CalculateBodyFat()
        {
            return 10;
        }
    }

  
}
