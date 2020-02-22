namespace Echo.Input
{
    public class InputMethod
    {
        /// <summary>
        /// always check for this property if you want the input method to be toggled
        /// </summary>
        public bool Enabled { get; set; }

        protected InputMethod() => Enabled = false;
    }
}