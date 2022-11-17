namespace CDCNfinal.API.Data
{
    public class ResponseData
    {
        public bool IsSuccess { get; set; }
        public List<object> Data { get; set; }

        public ResponseData()
        {
            IsSuccess = false;
            Data = new List<object>();
        }
    }
}