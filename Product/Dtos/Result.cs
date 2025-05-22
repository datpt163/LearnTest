
namespace Product.Dtos
{
    public class Result
    {
        public bool isSuccess {  get; set; }
        public string? errorMessage { get; set; }
        public object? data { get; set; }

        public Result() { }

        public Result(object? data)
        {
            this.isSuccess = true;
            this.data = data;
        }

        public Result(string? errorMessage)
        {
            this.isSuccess = false;
            this.errorMessage = errorMessage;
        }
    }
}
