namespace ML
{
    public class Result
    {
        public bool Correct { get; set; } // nos dice si se hizo o no la accion 
        public string ErrorMessage { get; set; }
        public Exception Ex { get; set; }



        public object Object { get; set; }
        public List<object> Objects { get; set; }

    }
}