using System.ComponentModel.DataAnnotations;

namespace Website.Validation
{
    public class IntLength : ValidationAttribute
    {
        public int Length;
        public override bool IsValid(object value)
        {
            if (value.GetType() == typeof(int))
            {
                return (int)value.ToString().Length == Length;
            }

            return false;
        }
        public IntLength(int len)
        {
            Length = len;
        }
    }    
}